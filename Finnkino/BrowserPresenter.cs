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
        private ObservableCollection<MovieCollection> movieCollectionList; //kuvat järjestetty päivittäin collectioneihin (oikea data)
        private List<DateTime> dateList;
        private List<MovieBox> movieBoxList;

        public BrowserPresenter(IAPIGateway APIGateway)
        {
            this.APIGateway = APIGateway;
        }

        public ObservableCollection<MovieCollection> getMovies(int theatre, Dictionary<string, string> filters)
        {
            //järjestetään kaikki movieboxit showdaten mukaan nousevaan järjestykseen
            Sorter sorter = new Sorter();
            Filter filter = new Filter();
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

            filter.filterByDay(movieCollectionList, filters["Day"]);
            filter.filterByGenre(movieCollectionList, filters["Genre"]);
            filter.filterByAgeLimit(movieCollectionList, filters["AgeLimit"]);

            return this.movieCollectionList;
        }
        /*
        public ObservableCollection<MovieCollection> getMovies(Dictionary<string, string> filters)
        {
            foreach (var filtteri in filters)
            {
                Debug.WriteLine("tässä filtteri: " + filtteri.Key.ToString() + " = " + filtteri.Value.ToString());
            }

            ObservableCollection<MovieCollection> tmp;
            Filter filter = new Filter();

            //tuolla noin tehään temppilista (filteröity lista) jota vielä filteröiään genren yäm mukaan...
            //tmp = filter.filterByDay(movieCollectionList, filters["Day"]);

            //filter.filterByGenre(tmp, filters["Genre"]);
            //filter.filterByAgeLimit(tmp, filters["AgeLimit"]);

            return tmp;
        }
        */
        /*
        public ObservableCollection<MovieCollection> filterByGenre(string genre)
        {
            if (genre == "Kaikki")
            {
                return movieCollectionList;
            }
            else
            {
                Filter filter = new Filter();          
                return filter.filterByGenre(movieCollectionList, genre);
            }
        }

        public ObservableCollection<MovieCollection> filterByAgeLimit(string ageLimit)
        {
            if (ageLimit == "Kaikki")
            {
                return movieCollectionList;
            }
            else
            {
                Filter filter = new Filter();
                return filter.filterByAgeLimit(movieCollectionList, ageLimit);
            }
        }
        */
        public List<Area> getAreas()
        {
            return this.APIGateway.getAreas();
        }

        public List<string> getAuditoriums(int area)
        {
            return this.APIGateway.getAuditoriums(area);
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
            this.movieCollectionList = new ObservableCollection<MovieCollection>();
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
