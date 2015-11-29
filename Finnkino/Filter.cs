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
        public ObservableCollection<MovieCollection> filterByGenre(ObservableCollection<MovieCollection> collection, string genre)
        {
            ObservableCollection<MovieCollection> tmp = new ObservableCollection<MovieCollection>();
            int tmpIndex = 0;
            for (int i = 0; i < collection.Count; i++)
            {
                tmp.Add(new MovieCollection());
                tmp[tmpIndex].Day = collection[i].Day;
                tmp[tmpIndex].Movies = new List<MovieBox>();
                for (int j = 0; j < collection[i].Movies.Count; j++)
                {
                    if (collection[i].Movies[j].Genre.Contains<string>(genre))
                    {
                        tmp[tmpIndex].Movies.Add(collection[i].Movies[j]);
                        Debug.WriteLine("lisätään temppiin: " + collection[i].Movies[j].EventId.ToString());
                    }
                }
                if (tmp[tmpIndex].Movies.Count == 0)
                {
                    tmp.RemoveAt(tmpIndex);
                }
                else
                {
                    tmpIndex++;
                }
            }
            return tmp;
        }

        public ObservableCollection<MovieCollection> filterByAgeLimit(ObservableCollection<MovieCollection> collection, string ageLimit)
        {
            ObservableCollection<MovieCollection> tmp = new ObservableCollection<MovieCollection>();
            int tmpIndex = 0;
            for (int i = 0; i < collection.Count; i++)
            {
                tmp.Add(new MovieCollection());
                tmp[tmpIndex].Day = collection[i].Day;
                tmp[tmpIndex].Movies = new List<MovieBox>();
                for (int j = 0; j < collection[i].Movies.Count; j++)
                {
                    if (collection[i].Movies[j].AgeLimit == ageLimit)
                    {
                        tmp[tmpIndex].Movies.Add(collection[i].Movies[j]);
                        Debug.WriteLine("lisätään temppiin: " + collection[i].Movies[j].EventId.ToString());
                    }
                }
                if (tmp[tmpIndex].Movies.Count == 0)
                {
                    tmp.RemoveAt(tmpIndex);
                }
                else
                {
                    tmpIndex++;
                }
            }
            return tmp;
        }
    }
}
