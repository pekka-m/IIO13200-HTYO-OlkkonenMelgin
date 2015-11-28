using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finnkino
{
    public class Sorter
    {
        public List<MovieBox> sortByDay(List<MovieBox> movies)
        {
            movies.Sort((x, y) => DateTime.Compare(x.ShowDate, y.ShowDate));
            return movies;
        }
    }
}
