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
        //private List<DateTime> dateList;
        //private List<MovieBox> movieBoxList;

        public BrowserPresenter(IAPIGateway APIGateway)
        {
            this.APIGateway = APIGateway;
        }

        public ObservableCollection<MovieCollection> getMovies(int theatre, Dictionary<string, string> filters)
        {
            //järjestetään kaikki movieboxit showdaten mukaan nousevaan järjestykseen
            Sorter sorter = new Sorter();
            Filter filter = new Filter();
            DateTime date;
            if (filters["Day"] == "Kaikki")
            {
                date = DateTime.MinValue;
            }
            else
            {
                date = DateTime.ParseExact(filters["Day"], "d.M.yyyy H:mm:ss", null);
            }

            this.movieCollectionList = sorter.sortByDay(this.APIGateway.getMovies(theatre, date));
            sorter = null;

            

            filter.filterByDay(movieCollectionList, filters["Day"]);
            filter.filterByGenre(movieCollectionList, filters["Genre"]);
            filter.filterByAgeLimit(movieCollectionList, filters["AgeLimit"]);

            return this.movieCollectionList;
        }

        public List<Area> getAreas()
        {
            return this.APIGateway.getAreas();
        }

        public List<string> getAuditoriums(int area)
        {
            return this.APIGateway.getAuditoriums(area);
        }

        
    }
}
