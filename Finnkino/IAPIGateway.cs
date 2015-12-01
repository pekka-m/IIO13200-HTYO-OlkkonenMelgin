using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finnkino
{
    public interface IAPIGateway
    {
        Schedule getMovies(int theatre, DateTime day);
        List<Area> getAreas();
        List<string> getAuditoriums(int area);
        Movie getMovieDetails(int eventId, int area, string date);
        List<Show> getMovieSchedules(MovieBox movieBox);
    }
}
