using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finnkino
{
    public class MovieBox
    {
        public int EventId { get; set; }
        public string AgeLimit { get; set; }
        public string Auditorium { get; set; }
        public string[] Genre { get; set; }
        public string ImagePath { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime ShowDate { get; set; }
        public int Theatre { get; set; }
    }
}
