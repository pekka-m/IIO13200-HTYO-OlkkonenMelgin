using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finnkino
{
    public class MockAPIGateway : IAPIGateway
    {
        public List<MovieBox> getMovies(int theatre)
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
                movies[i].Genre = new string[] {"Comedy", "Sci-fi" };
                movies[i].ImagePath = "www.tes.ti/images/" + i + ".png";
                movies[i].ReleaseDate = DateTime.Now;
                if (i % 3 == 0)
                {
                    movies[i].ShowDate = dateTime;
                }
                else if (i % 3 == 1)
                {
                    movies[i].ShowDate = dateTime2;
                }
                else
                {
                    movies[i].ShowDate = dateTime3;
                }
                movies[i].Theatre = i;
            }
            return movies;
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
