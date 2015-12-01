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
