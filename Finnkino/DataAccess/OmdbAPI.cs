using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            string formattedTitle =  Regex.Replace(title, @"\W|(3D)|(orig)|(2D)|(dub)", " ");
            formattedTitle = Regex.Replace(formattedTitle, @"\s+", "+");
            Debug.WriteLine("originaaltisdfasdf " + formattedTitle);
            if (formattedTitle.Length - 1 == '+')
            {
                return formattedTitle.Remove(formattedTitle.Length - 1);
            }
            return formattedTitle;
        }
    }
}
