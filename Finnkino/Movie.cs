using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finnkino
{
    public class Movie
    {
        public int EventId { get; set; }
        public string Title { get; set; }
        public string OriginalTitle { get; set; }
        public int LengthInMinutes { get; set; }
        public DateTime LocalReleaseDate { get; set; }
        public string RatingImagePath { get; set; }
        public string[] Genres { get; set; }
        public string ShortSynopsis { get; set; }
        public Show[] Shows { get; set; }
    }
}
