using System;
using System.Collections.Generic;

namespace Finnkino
{
    public interface IAPIGateway
    {
        Schedule getMovies(int theatre, DateTime day);
        TheatreAreas getAreas();
        Movie getMovieDetails(int eventId, int area, string date, string movieTitle);
        
    }
}
