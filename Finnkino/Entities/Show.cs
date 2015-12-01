using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finnkino
{
    public class Show
    {
        public int Id { get; set; }
        public string Auditorium { get; set; }
        public DateTime ShowStart { get; set; }
        public DateTime ShowEnd { get; set; }
        public string ShowableString { get { return Auditorium + " / " + ShowStart.ToString("HH:mm") + " - " + ShowEnd.ToString("HH:mm"); } }
    }
}
