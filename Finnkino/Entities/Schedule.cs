﻿using System.Collections.Generic;
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
