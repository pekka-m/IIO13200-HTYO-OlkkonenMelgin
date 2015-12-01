using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finnkino
{
    public class MovieDetailsPresenter
    {
        private IAPIGateway APIGateway;

        public MovieDetailsPresenter(IAPIGateway gateway)
        {
            this.APIGateway = gateway; 
        }

        public void getMovieDetails(int eventId, int area, string date)
        {
            APIGateway.getMovieDetails(eventId, area, date);
        }
    }
}
