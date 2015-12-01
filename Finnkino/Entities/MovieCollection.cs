using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finnkino
{
    public class MovieCollection
    {
        public DateTime Day { get; set; }
        public List<Movie> Movies { get; set; }
    }
}
