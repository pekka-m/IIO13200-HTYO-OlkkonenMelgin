using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finnkino
{
    public class Sorter
    {
        private List<MovieBox> movieBoxList;
        private List<DateTime> dateList;
        private ObservableCollection<MovieCollection> movieCollectionList; //kuvat järjestetty päivittäin collectioneihin (oikea data)

        public ObservableCollection<MovieCollection> sortByDay(Schedule schedule)
        {
            //movies.Sort((x, y) => DateTime.Compare(DateTime.ParseExact(x.ShowStart, "yyyy-MM-dd'T'HH:mm:ss", null), DateTime.ParseExact(y.ShowStart, "yyyy-MM-dd'T'HH:mm:ss", null)));
            //return movies;

            if (schedule.Shows[0].Show.Count > 0)
            {
                this.movieBoxList = schedule.Shows[0].Show;
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

                return this.movieCollectionList;
            }
            return new ObservableCollection<MovieCollection>();

        }

        private string dateToString(DateTime date)
        {
            string format = "yyyy-MM-dd";
            return date.ToString(format);
        }

        //haetaan dateList-listaan kaikki eri showpäivät
        private void setDateList()
        {
            DateTime day = this.movieBoxList[0].getShowStart();
            this.dateList = new List<DateTime>();
            this.dateList.Add(this.movieBoxList[0].getShowStart());
            Debug.WriteLine("adataan datelistiin jotain: " + this.movieBoxList[0].getShowStart());
            //Debug.WriteLine(this.movieBoxList[0].ShowDate.ToString());
            for (int i = 1; i < this.movieBoxList.Count; i++)
            {
                if (dateToString(this.movieBoxList[i].getShowStart()) != dateToString(this.movieBoxList[i - 1].getShowStart()))
                {
                    dateList.Add(this.movieBoxList[i].getShowStart());
                    Debug.WriteLine("adataan datelistiin jotain: " + this.movieBoxList[i].getShowStart());
                    //Debug.WriteLine(this.movieBoxList[i].ShowStart.ToString());
                }
            }
        }

        //temppilistaan lisätään movieboxeja kunnes päivä on eri kun datelist-listassa oleva
        //lisätään temppilista collectioniin, tehään uus temppilista
        //ja siirrytään datelistassa seuraavaan päivään
        private void setMovieCollectionList()
        {
            this.movieCollectionList = new ObservableCollection<MovieCollection>();
            int dateListIndex = 0;
            List<MovieBox> movieBoxListTemp = new List<MovieBox>();
            MovieCollection movieCollectionTemp = new MovieCollection();
            Debug.WriteLine("tehään uus temppilista");
            int i;
            for (i = 0; i < this.movieBoxList.Count; i++)
            {
                if (dateToString(this.movieBoxList[i].getShowStart()) == dateToString(this.dateList[dateListIndex]))
                {
                    movieBoxListTemp.Add(this.movieBoxList[i]);
                    Debug.WriteLine("Lisätään listaan eventti: " + this.movieBoxList[i].EventID.ToString());
                }
                else
                {
                    movieCollectionTemp.Day = this.movieBoxList[i - 1].getShowStart();
                    //Debug.WriteLine("Lisätään isoon listaan päivä: " + this.movieBoxList[i - 1].ShowDate.ToString());
                    movieCollectionTemp.Movies = movieBoxListTemp;
                    this.movieCollectionList.Add(movieCollectionTemp);
                    movieCollectionTemp = new MovieCollection();
                    movieBoxListTemp = new List<MovieBox>();
                    Debug.WriteLine("tehään uus temppilista");
                    movieBoxListTemp.Add(this.movieBoxList[i]);
                    //Debug.WriteLine("Lisätään listaan eventti: " + this.movieBoxList[i].EventId.ToString());
                    dateListIndex++;
                }
            }

            //lisätään viimenen temppilista collectioniin
            movieCollectionTemp.Day = this.movieBoxList[i - 1].getShowStart();
            //Debug.WriteLine("Lisätään isoon listaan päivä: " + this.movieBoxList[i - 1].ShowDate.ToString());
            movieCollectionTemp.Movies = movieBoxListTemp;
            this.movieCollectionList.Add(movieCollectionTemp);
        }
    }
}
