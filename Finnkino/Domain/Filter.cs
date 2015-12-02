using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Finnkino
{
    public class Filter
    {
        public void filterByDay(ObservableCollection<MovieCollection> collection, string day)
        {
            if (day != "Kaikki")
            {
                DateTime date = DateTime.ParseExact(day, "d.M.yyyy H:mm:ss", null);
                for (int i = collection.Count - 1; i >= 0; i--)
                {
                    LoopCounter.loops++;
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
                    LoopCounter.loops++;
                    for (int j = collection[i].Movies.Count-1; j >= 0; j--)
                    {
                        LoopCounter.loops++;
                        if (!collection[i].Movies[j].getGenres().Contains<string>(genre))
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
                    LoopCounter.loops++;
                    for (int j = collection[i].Movies.Count - 1; j >= 0; j--)
                    {
                        LoopCounter.loops++;
                        if (!collection[i].Movies[j].Rating.Equals(ageLimit))
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

        public void filterByAuditorium(ObservableCollection<MovieCollection> collection, string auditoriumName)
        {
            if (auditoriumName != "Kaikki")
            {
                for (int i = collection.Count - 1; i >= 0; i--)
                {
                    LoopCounter.loops++;
                    for (int j = collection[i].Movies.Count - 1; j >= 0; j--)
                    {
                        LoopCounter.loops++;
                        if (!collection[i].Movies[j].TheatreAuditorium.Equals(auditoriumName))
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
        public List<string> getTheaterAuditoriums(ObservableCollection<MovieCollection> collection) {

            List<string> auditoriums = new List<string>();
            auditoriums.Add("Kaikki");
            //mennään jokanen päivä läpi
            for (int i = 0; i < collection.Count; i++)
            {
                LoopCounter.loops++;
                //mennään päivän jokanen leffa läpi
                for (int j = 0; j < collection.ElementAt(i).Movies.Count; j++)
                {
                    LoopCounter.loops++;
                    // jos lista ei sisällä teatterin nimeä
                    // niin lisätään se sinne
                    if (!auditoriums.Contains(collection.ElementAt(i).Movies[j].TheatreAuditorium))
                    {
                        auditoriums.Add(collection.ElementAt(i).Movies[j].TheatreAuditorium);
                    }
                }
            }
            return auditoriums;
        }
    }
}
