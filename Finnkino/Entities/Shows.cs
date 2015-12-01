using System.Collections.Generic;
using System.Xml.Serialization;

namespace Finnkino
{
    public class Shows
    {
        [XmlElement("Show")]
        public List<Movie> Show { get; set; }
    }
}
