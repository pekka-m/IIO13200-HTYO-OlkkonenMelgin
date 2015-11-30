using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finnkino
{
    public class FinnkinoAPI
    {
        public XMLMankeli mankeli { get; set; }
        public string url { get; set; }

        public FinnkinoAPI()
        {
            this.mankeli = new XMLMankeli();
        }

        public Schedule getMovies(int theatre, DateTime day)
        {
            List<MovieBox> movies = new List<MovieBox>();
            string date = "dd.MM.yyyy";
            try
            {
                if (day == DateTime.MinValue)
                {
                    date = "&nrOfDays=14";
                }
                else
                {
                    date = "&dt=" + day.ToString(date);
                }
            }
            catch (Exception)
            {
                date = null;
            }
            //this.url = "http://www.finnkino.fi/xml/Schedule/?area=" + theatre.ToString() + date;

            return this.mankeli.mankeloiMovieBox("http://www.finnkino.fi/xml/Schedule/?area=" + theatre.ToString() + date);

            //Debug.WriteLine("tässä ois vähän urlia: http://www.finnkino.fi/xml/Schedule/?area=" + theatre.ToString() + date);

            //return movies;
        }
    }
}
