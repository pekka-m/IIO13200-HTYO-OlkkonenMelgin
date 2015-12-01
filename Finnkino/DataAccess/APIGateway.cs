using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Finnkino.DataAccess;


namespace Finnkino
{
    public class APIGateway : IAPIGateway
    {

        public FinnkinoAPI finnkinoApi { get; set; }
        public OmdbAPI ratingsAPI { get; set; }
        public APIGateway() {
            finnkinoApi = new FinnkinoAPI();
            ratingsAPI = new OmdbAPI();
            
        }
        public Schedule getMovies(int theatre, DateTime day)
        {
            return finnkinoApi.getMovies(theatre, day);
        }

        public TheatreAreas getAreas()
        {
            return finnkinoApi.getAreas();
        }



        public Movie getMovieDetails(int eventId, int area, string date, string movieTitle)
        {
            Schedule movies = finnkinoApi.getMovieDetails(eventId, area, date);
            string rating = ratingsAPI.getMovieRating(movieTitle);
           // string rating = omdbAPI.getMovieRating(movieTitle);
            Movie movie = movies.Shows[0].Show[0];
            string[] jotain = finnkinoApi.getSynopsis(eventId);
            movie.Synopsis = jotain[0];
            movie.ImageBackground = jotain[1];
            movie.Shows = new List<Show>();
            movie.Rating = rating;
            for (int i = 0; i < movies.Shows[0].Show.Count; i++)
            {
                Show show = new Show();
                show.Id = int.Parse(movies.Shows[0].Show[i].ShowID);
                show.Auditorium = movies.Shows[0].Show[i].TheatreAuditorium;
                show.ShowStart = DateTime.ParseExact(movies.Shows[0].Show[i].dttmShowStart, "yyyy-MM-dd'T'HH:mm:ss", null);
                show.ShowEnd = DateTime.ParseExact(movies.Shows[0].Show[i].dttmShowEnd, "yyyy-MM-dd'T'HH:mm:ss", null);
                movie.Shows.Add(show);
            }

            return movie;
        }

    }
}
