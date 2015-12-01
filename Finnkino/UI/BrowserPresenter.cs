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
        private Filter filter;
        private IAPIGateway APIGateway;
        private ObservableCollection<MovieCollection> movieCollectionList; //kuvat järjestetty päivittäin collectioneihin (oikea data)
        //private List<DateTime> dateList;
        //private List<MovieBox> movieBoxList;

        public BrowserPresenter(IAPIGateway APIGateway)
        {
            this.APIGateway = APIGateway;
            filter = new Filter();
        }

        public ObservableCollection<MovieCollection> getMovies(int theatre, Dictionary<string, string> filters)
        {
            //järjestetään kaikki movieboxit showdaten mukaan nousevaan järjestykseen
            Sorter sorter = new Sorter();
            DateTime date;
            if (filters["Day"] == "Kaikki")
            {
                date = DateTime.MinValue;
            }
            else
            {
                date = DateTime.ParseExact(filters["Day"], "d.M.yyyy H:mm:ss", null);
            }
            // tässä on kaikki ne leffat
            Schedule schedule = this.APIGateway.getMovies(theatre: theatre, day: date);
            // kun täältä tulee ne leffat niin niissä pitää olla ne showssit lisättynä
            this.movieCollectionList = sorter.sortByDay(schedule);


            // lisää jokaseen 
            sorter = null;

            

            filter.filterByDay(movieCollectionList, filters["Day"]);
            filter.filterByGenre(movieCollectionList, filters["Genre"]);
            filter.filterByAgeLimit(movieCollectionList, filters["AgeLimit"]);
            filter.filterByAuditorium(movieCollectionList, filters["Auditorium"]);

            return this.movieCollectionList;
        }

        public List<Area> getAreas()
        {
            return this.APIGateway.getAreas().TheatreArea;
        }


       
        public List<string> getAuditoriums()
        {
          return filter.getTheaterAuditoriums(movieCollectionList);
        }

        
    }
}
