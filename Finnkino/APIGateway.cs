using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finnkino
{
    public class APIGateway : IAPIGateway
    {
        public Schedule getMovies(int theatre, DateTime day)
        {
            List<MovieBox> movies = new List<MovieBox>();

            FinnkinoAPI api = new FinnkinoAPI();
            return api.getMovies(theatre, day);
        }

        public List<Area> getAreas()
        {
            List<Area> areas = new List<Area>();
            areas.Add(new Area(1015, "Jyväskylä"));
            areas.Add(new Area(1033, "Helsinki: Tennispalatsi"));
            areas.Add(new Area(1038, "Espoo: Sello"));
            return areas;
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

        public Movie getMovieDetails(int eventId, int area, string date)
        {

            return new Movie();
        }

        public List<Show> getMovieSchedules(MovieBox movieBox)
        {
            return new List<Show>();
        }
    }
}
