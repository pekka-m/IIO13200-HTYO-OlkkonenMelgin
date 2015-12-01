using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finnkino.DataAccess
{
   public class OmdbAPI
    {
        public string getMovieRating(string movieName)
        {
            string url = "http://www.omdbapi.com/?t=" + formatMovieTitle(movieName) +"&plot=short&r=xml";
            Debug.WriteLine("omdbapin movie title" + formatMovieTitle(movieName));
            XMLMankeli mankeli = new XMLMankeli();
          return  mankeli.mankeloiRatings(url);
        }


        // TODO ei toimi ihan täysin jos on 3D stringissä, toisin sanoen ei poista niitä
        private string formatMovieTitle(string title)
        {
            string[] splitted = title.Split(' ');
            List<string> stripped = new List<string>();
            string formattedTitle="";
            for (int i = 0; i < splitted.Length; i++)
            {
               
                if ((!splitted[i].Contains("(dub)") || !splitted[i].Contains("2D")) || !splitted[i].Contains("3D")) {
                    stripped.Add(splitted[i]);
                }
            }

            for (int i = 0; i < stripped.Count; i++)
            {
                formattedTitle += stripped[i]+"+";
            }
         return formattedTitle.Remove(formattedTitle.Length - 1);
        }
    }
}
