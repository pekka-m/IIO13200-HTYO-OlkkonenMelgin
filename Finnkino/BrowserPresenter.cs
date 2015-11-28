using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finnkino
{
    public class BrowserPresenter
    {
        private IAPIGateway APIGateway;
        private List<MovieCollection> movieCollectionList; //kuvat järjestetty päivittäin collectioneihin (oikea data)
        private List<DateTime> dateList;
        private List<MovieBox> movieBoxList;

        public BrowserPresenter(IAPIGateway APIGateway)
        {
            this.APIGateway = APIGateway;
        }

        public List<MovieCollection> initialize(int theatre)
        {
            //järjestetään kaikki movieboxit showdaten mukaan nousevaan järjestykseen
            Sorter sorter = new Sorter();
            this.movieBoxList = sorter.sortByDay(this.APIGateway.getMovies(theatre));
            sorter = null;

            if (this.movieBoxList.Count > 0)
            {
                //setataan kaikki showpäivät
                this.setDateList();

                //setataan iso lista
                //MovieCollection
                //- DateTime Day
                //- List<MovieBox>
                //jokaisessa MovieCollectionissa on yhden päivän movieboxit
                this.setMovieCollectionList();

                //nullataan kaikki mitä ei enää tarvita
                this.dateList = null;
                this.movieBoxList = null;
            }
            return this.movieCollectionList;
        }

        //haetaan dateList-listaan kaikki eri showpäivät
        private void setDateList()
        {
            this.dateList = new List<DateTime>();
            this.dateList.Add(this.movieBoxList[0].ShowDate);
            Debug.WriteLine(this.movieBoxList[0].ShowDate.ToString());
            for (int i = 1; i < this.movieBoxList.Count; i++)
            {
                if (this.movieBoxList[i].ShowDate != this.movieBoxList[i - 1].ShowDate)
                {
                    dateList.Add(this.movieBoxList[i].ShowDate);
                    Debug.WriteLine(this.movieBoxList[i].ShowDate.ToString());
                }
            }
        }

        //temppilistaan lisätään movieboxeja kunnes päivä on eri kun datelist-listassa oleva
        //lisätään temppilista collectioniin, tehään uus temppilista
        //ja siirrytään datelistassa seuraavaan päivään
        private void setMovieCollectionList()
        {
            this.movieCollectionList = new List<MovieCollection>();
            int dateListIndex = 0;
            List<MovieBox> movieBoxListTemp = new List<MovieBox>();
            MovieCollection movieCollectionTemp = new MovieCollection();
            Debug.WriteLine("tehään uus temppilista");
            int i;
            for (i = 0; i < this.movieBoxList.Count; i++)
            {
                if (this.movieBoxList[i].ShowDate == this.dateList[dateListIndex])
                {
                    movieBoxListTemp.Add(this.movieBoxList[i]);
                    Debug.WriteLine("Lisätään listaan eventti: " + this.movieBoxList[i].EventId.ToString());
                }
                else
                {
                    movieCollectionTemp.Day = this.movieBoxList[i - 1].ShowDate;
                    Debug.WriteLine("Lisätään isoon listaan päivä: " + this.movieBoxList[i - 1].ShowDate.ToString());
                    movieCollectionTemp.Movies = movieBoxListTemp;
                    this.movieCollectionList.Add(movieCollectionTemp);
                    movieCollectionTemp = new MovieCollection();
                    movieBoxListTemp = new List<MovieBox>();
                    Debug.WriteLine("tehään uus temppilista");
                    movieBoxListTemp.Add(this.movieBoxList[i]);
                    Debug.WriteLine("Lisätään listaan eventti: " + this.movieBoxList[i].EventId.ToString());
                    dateListIndex++;
                }
            }

            //lisätään viimenen temppilista collectioniin
            movieCollectionTemp.Day = this.movieBoxList[i - 1].ShowDate;
            Debug.WriteLine("Lisätään isoon listaan päivä: " + this.movieBoxList[i - 1].ShowDate.ToString());
            movieCollectionTemp.Movies = movieBoxListTemp;
            this.movieCollectionList.Add(movieCollectionTemp);
        }
    }
}
