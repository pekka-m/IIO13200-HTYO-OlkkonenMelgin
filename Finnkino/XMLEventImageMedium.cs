using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Finnkino
{
    public class XMLEventImageMedium
    {
        [XmlElement]
        public string EventMediumImagePortrait { get; set; }
    }
}
