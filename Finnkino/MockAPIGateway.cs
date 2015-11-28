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
        public Movie[] getMovies(int theatre)
        {

            Movie[] movies = new Movie[10];
            for (int i = 0; i < 10; i++)
            {
                movies[i] = new Movie();
                movies[i].EventId = i;
                movies[i].Title = "Title " + i;
                movies[i].OriginalTitle = "OriginalTitle " + i;
                movies[i].LengthInMinutes = 100 + i;
                movies[i].LocalReleaseDate = DateTime.Now;
                movies[i].RatingImagePath = "www.tes.ti/images/" + i + ".png";
                movies[i].ShortSynopsis = "ShortSynopsis " + i + " is best synopsis...";
                movies[i].Shows = new Show[5];
                for (int j = 0; j < 5; j++)
                {
                    movies[i].Shows[j] = new Show();
                    movies[i].Shows[j].Id = j;
                    movies[i].Shows[j].Auditorium = "Auditorium " + j;
                    movies[i].Shows[j].ShowStart = new DateTime();
                    movies[i].Shows[j].ShowEnd = new DateTime();
                }
            Debug.WriteLine(movies[i].LocalReleaseDate.ToString());
            }
            return movies;
        }

        public Movie getMovieDetails(MovieBox movieBox)
        {
            return new Movie();
        }

        public Show[] getMovieSchedules(MovieBox movieBox)
        {
            return new Show[5];
        }
    }
}
