using System;
using System.Collections.Generic;

namespace Finnkino
{
    public interface IAPIGateway
    {
        Schedule getMovies(int theatre, DateTime day);
        TheatreAreas getAreas();
        List<string> getAuditoriums(int area);
        Movie getMovieDetails(int eventId, int area, string date);
        List<Show> getMovieSchedules(Movie movieBox);
    }
}
