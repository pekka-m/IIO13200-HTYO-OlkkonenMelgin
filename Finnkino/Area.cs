using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Finnkino
{
    [XmlType("TheatreArea")]
    public class Area
    {
        [XmlElement("ID")]
        public int AreaId { get; set; }
        [XmlElement("Name")]
        public string Theatre { get; set; }

    }
}
