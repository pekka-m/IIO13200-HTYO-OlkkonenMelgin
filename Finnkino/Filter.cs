using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finnkino
{
    public class Filter
    {
        public void filterByDay(ObservableCollection<MovieCollection> collection, string day)
        {
            if (day != "Kaikki")
            {
                DateTime date = DateTime.ParseExact(day, "d.M.yyyy HH.mm.ss", null);
                for (int i = collection.Count - 1; i >= 0; i--)
                {
                    if (String.Format("{0:dd.MM}", collection[i].Day) != String.Format("{0:dd.MM}", date))
                    {
                        collection.RemoveAt(i);
                    }
                }
            }
        }

        public void filterByGenre(ObservableCollection<MovieCollection> collection, string genre)
        {
            if (genre != "Kaikki")
            {            
                for (int i = collection.Count-1; i >= 0; i--)
                {
                    for (int j = collection[i].Movies.Count-1; j >= 0; j--)
                    {
                        if (!collection[i].Movies[j].Genre.Contains<string>(genre))
                        {
                            collection[i].Movies.RemoveAt(j);
                        }
                    }
                    if (collection[i].Movies.Count == 0)
                    {
                        collection.RemoveAt(i);
                    }
                }
            }
        }

        public void filterByAgeLimit(ObservableCollection<MovieCollection> collection, string ageLimit)
        {
            if (ageLimit != "Kaikki")
            {
                for (int i = collection.Count - 1; i >= 0; i--)
                {
                    for (int j = collection[i].Movies.Count - 1; j >= 0; j--)
                    {
                        if (!collection[i].Movies[j].AgeLimit.Equals(ageLimit))
                        {
                            collection[i].Movies.RemoveAt(j);
                        }
                    }
                    if (collection[i].Movies.Count == 0)
                    {
                        collection.RemoveAt(i);
                    }
                }
            }
        }
    }
}
