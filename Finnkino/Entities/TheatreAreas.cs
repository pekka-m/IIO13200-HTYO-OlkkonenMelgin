using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
