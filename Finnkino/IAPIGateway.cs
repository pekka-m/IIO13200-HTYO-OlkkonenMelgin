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
        TheatreAreas getAreas();
        List<string> getAuditoriums(int area);
        Movie getMovieDetails(MovieBox movieBox);
        List<Show> getMovieSchedules(MovieBox movieBox);
    }
}
