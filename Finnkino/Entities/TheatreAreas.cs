using System.Collections.Generic;
using System.Xml.Serialization;

namespace Finnkino
{
    [XmlRoot("TheatreAreas")]
    public class TheatreAreas
    {
   
           
        [XmlElement("TheatreArea")]
        public List<Area> TheatreArea { get; set; }
        }
    
}
