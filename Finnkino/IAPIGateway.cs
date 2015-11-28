using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finnkino
{
    public interface IAPIGateway
    {
        Movie[] getMovies(int theatre);
        Movie getMovieDetails(MovieBox movieBox);
        Show[] getMovieSchedules(MovieBox movieBox);
    }
}
