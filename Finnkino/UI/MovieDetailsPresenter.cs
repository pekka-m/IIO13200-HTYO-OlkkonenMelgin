using System;

namespace Finnkino
{
    public class MovieDetailsPresenter
    {
        private IAPIGateway APIGateway;

        public MovieDetailsPresenter(IAPIGateway gateway)
        {
            this.APIGateway = gateway; 
        }

        public Movie getMovieDetails(int eventId, int area, string date, string movieTitle)
        {

            DateTime day = DateTime.ParseExact(date, "yyyy-MM-dd'T'HH:mm:ss", null);

            //Movie movie = APIGateway.getMovieDetails(eventId, area, day.ToString("dd.MM.yyyy"));
            return APIGateway.getMovieDetails(eventId, area, day.ToString("dd.MM.yyyy"), movieTitle);
        }
    }
}
