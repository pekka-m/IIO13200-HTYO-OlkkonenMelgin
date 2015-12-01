using System;
using System.Collections.Generic;

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

        public Movie getMovieDetails(int eventId, int area, string date)
        {
            Schedule movies = finnkinoApi.getMovieDetails(eventId, area, date);
            Movie movie = movies.Shows[0].Show[0];
            string[] jotain = finnkinoApi.getSynopsis(eventId);
            movie.Synopsis = jotain[0];
            movie.ImageBackground = jotain[1];
            movie.Shows = new List<Show>();
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

        public List<Show> getMovieSchedules(Movie movieBox)
        {
            return new List<Show>();
        }
    }
}
