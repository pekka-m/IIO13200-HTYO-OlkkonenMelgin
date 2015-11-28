using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finnkino
{
    public class BrowserPresenter
    {
        private IAPIGateway APIGateway;
        private List<Movie> Movies;

        public BrowserPresenter(IAPIGateway APIGateway)
        {
            this.APIGateway = APIGateway;
        }

        public List<Movie> initialize(int theatre)
        {
            Sorter sorter = new Sorter();
            this.Movies = sorter.sortByDay(this.APIGateway.getMovies(theatre));
            return this.Movies;
        }
    }
}
