using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Finnkino
{
    [XmlRoot("Schedule")]
    public class Schedule
    {
        [XmlElement("Shows")]
        public List<Shows> Shows { get; set; }
    }
}
