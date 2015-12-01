using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finnkino
{
    public class MockAPIGateway
    {
        // TODO Se saleittain filtteröinti vaatii sen että niihin movieboxeihin setataan ne showt heti siinä alussa kun ne haetaan näytettäväks eli se show pyörittely mikä tehtiin pitää siirtää toiseen kohtaan
        // TODO salin mukaan filettörinti
        // TODO  kun valitsee kaikki areat ni pitäs saaha tieto yhen eventin kaikista näytöksistä kaikkialla

        /*
        public List<MovieBox> getMovies(int theatre, DateTime day)
        {

            List<MovieBox> movies = new List<MovieBox>();
            DateTime dateTime = new DateTime(2015, 11, 28);
            DateTime dateTime2 = new DateTime(2015, 11, 30);
            DateTime dateTime3 = new DateTime(2015, 12, 05);
            for (int i = 0; i < 30; i++)
            {
                movies.Add(new MovieBox());
                movies[i].EventId = i;
                movies[i].AgeLimit = i.ToString();
                movies[i].Auditorium = "Auditorium " + i;
                movies[i].ImagePath = "www.tes.ti/images/" + i + ".png";
                movies[i].ReleaseDate = DateTime.Now;
                if (i % 3 == 0)
                {
                    movies[i].ShowDate = dateTime;
                    movies[i].Genre = new string[] {"Komedia","Toiminta"};
                }
                else if (i % 3 == 1)
                {
                    movies[i].ShowDate = dateTime2;
                    movies[i].Genre = new string[] {"Sci-fi","Toiminta"};
                }
                else
                {
                    movies[i].ShowDate = dateTime3;
                    movies[i].Genre = new string[] {"Sci-fi","Fantasia" };
                }
                movies[i].Theatre = i;
            }
            return movies;
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

        public Movie getMovieDetails(MovieBox movieBox)
        {
            return new Movie();
        }

        public List<Show> getMovieSchedules(MovieBox movieBox)
        {
            return new List<Show>();
        }
        */
    }
}
