using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finnkino
{
    public class APIGateway : IAPIGateway
    {

        public FinnkinoAPI finnkinoApi { get; set; }
        public APIGateway() {
            finnkinoApi = new FinnkinoAPI();
        }
        public Schedule getMovies(int theatre, DateTime day)
        {
        
            return finnkinoApi.getMovies(theatre, day);
        }

        public TheatreAreas getAreas()
        {
            return finnkinoApi.getAreas();
        }

        public List<string> getAuditoriums(int area)
        {
            List<string> auditoriums = new List<string>();
            auditoriums.Add("Kaikki");
            if (area == 1015)
            {
                auditoriums.Add("Fantasia 1");
                auditoriums.Add("Fantasia 2");
                auditoriums.Add("Fantasia 3");
                auditoriums.Add("Fantasia 4");
                auditoriums.Add("Fantasia 5");
            }
            else
            {
                auditoriums.Add("Sali X");
            }
            return auditoriums;
        }

        public Movie getMovieDetails(MovieBox movieBox)
        {
            return new Movie();
        }

        public List<Show> getMovieSchedules(MovieBox movieBox)
        {
            return new List<Show>();
        }
    }
}
