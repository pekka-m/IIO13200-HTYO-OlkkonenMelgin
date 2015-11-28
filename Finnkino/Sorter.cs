using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finnkino
{
    public class Sorter
    {
        public List<Movie> sortByDay(Movie[] movies)
        {
            List<Movie> movieList = new List<Movie>();
            foreach (var Movie in movies)
            {
                movieList.Add(Movie);
            }
            movieList.Sort((x, y) => DateTime.Compare(x.LocalReleaseDate, y.LocalReleaseDate));
            return movieList;
        }
    }
}
