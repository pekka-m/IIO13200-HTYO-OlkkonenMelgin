using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Finnkino
{
    public class Movie
    {
        [XmlElement]
        public int EventID { get; set; }

        [XmlElement]
        public string Title { get; set; }

        [XmlElement]
        public string OriginalTitle { get; set; }

        [XmlElement]
        public int LengthInMinutes { get; set; }

        [XmlElement]
        public string Rating { get; set; }

        [XmlElement]
        public string TheatreAuditorium { get; set; }

        [XmlElement]
        public string Genres { get; set; }
        
        [XmlElement("Images")]
        public XMLEventImageMedium Images { get; set; }

        [XmlElement]
        public string dtLocalRelease { get; set; }

        [XmlElement]
        public string dttmShowStart { get; set; }

        [XmlElement]
        public string dttmShowEnd{ get; set; }

        [XmlElement]
        public int TheatreID { get; set; }

        public string Synopsis { get; set; }

        public List<Show> Shows { get; set; }

        public string[] getGenres()
        {
            return Regex.Split(this.Genres, ", ");
        }

        public DateTime getShowStart()
        {
            //Debug.WriteLine("ASDFASDFSADFSADF" + this.ShowStart);
            return DateTime.ParseExact(this.dttmShowStart, "yyyy-MM-dd'T'HH:mm:ss", null);
        }
    }
}
