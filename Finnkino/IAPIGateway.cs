using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finnkino
{
    public interface IAPIGateway
    {
        List<MovieBox> getMovies(int theatre);
        Movie getMovieDetails(MovieBox movieBox);
        List<Show> getMovieSchedules(MovieBox movieBox);
    }
}
