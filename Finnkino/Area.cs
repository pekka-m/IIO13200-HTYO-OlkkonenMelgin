using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finnkino
{
    public class Area
    {
        public int AreaId { get; set; }
        public string Theatre { get; set; }

        public Area(int _areaId, string _theatre)
        {
            this.AreaId = _areaId;
            this.Theatre = _theatre;
        }
    }
}
