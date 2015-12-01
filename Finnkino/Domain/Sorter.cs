 using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Finnkino
{
    public class Sorter
    {
        private List<Movie> movieBoxList;
        private List<DateTime> dateList;
        private ObservableCollection<MovieCollection> movieCollectionList; //kuvat järjestetty päivittäin collectioneihin (oikea data)
        private List<int> eventIds;

        private void setShowSchedules() {
            // mennään moviecollection lista läpi
            ObservableCollection<MovieCollection> tempCollection = new ObservableCollection<MovieCollection>();
          
            for (int i = 0; i < movieCollectionList.Count; i++)
            {

                // haetaan yksittäinen moviecollectionlista
                MovieCollection colletion = movieCollectionList.ElementAt(i);
                // käydään sen leffat läpi
                for (int j = 0; j < colletion.Movies.Count ; j++)
                {
                    Movie leffa = colletion.Movies[j];
                    int leffanId = leffa.EventID;
                    // si tsekataan kaikki ne movieboxlistan leffat läpi ja verrataa onko sama event id
                    for (int q = 0; q < movieBoxList.Count; q++)
                    {
                        // jos on sama eventid, niin sitten tehdään uus show ja lisätään se takasin jonnekki
                        if (leffanId == movieBoxList[q].EventID) {
                            // lisätään siihen sen leffan sali
                            Show show = new Show();
                            show.Auditorium = movieBoxList[q].TheatreAuditorium;
                            // lisätään showit takasin leffaan
                            // koska referenssit niin toimii
                            // eli lisää sinne moviecollectionlistiin ne showit
                            leffa.Shows.Add(show);
                        }
                       
                    }
                }
            }

        }

        public ObservableCollection<MovieCollection> sortByDay(Schedule schedule)
        {
            //movies.Sort((x, y) => DateTime.Compare(DateTime.ParseExact(x.ShowStart, "yyyy-MM-dd'T'HH:mm:ss", null), DateTime.ParseExact(y.ShowStart, "yyyy-MM-dd'T'HH:mm:ss", null)));
            //return movies;
            

            // jos löytyy leffoja niin sitten
            if (schedule.Shows[0].Show.Count > 0)
            {
                // sisältää kaikki  leffat siis movie boxi sisältää
                this.movieBoxList = schedule.Shows[0].Show;
                //setataan kaikki showpäivät
                this.setDateList();

                //setataan iso lista
                //MovieCollection
                //- DateTime Day
                //- List<MovieBox>
                //jokaisessa MovieCollectionissa on yhden päivän movieboxit
                this.setMovieCollectionList();
                this.setShowSchedules();

                //nullataan kaikki mitä ei enää tarvita
                this.dateList = null;
                this.movieBoxList = null;

                return this.movieCollectionList;
            }
            return new ObservableCollection<MovieCollection>();

        }

        private string dateToString(DateTime date)
        {
            string format = "yyyy-MM-dd";
            return date.ToString(format);
        }

        //haetaan dateList-listaan kaikki eri showpäivät
        private void setDateList()
        {
            DateTime day = this.movieBoxList[0].getShowStart();
            this.dateList = new List<DateTime>();
            this.dateList.Add(this.movieBoxList[0].getShowStart());
            Debug.WriteLine("adataan datelistiin jotain: " + this.movieBoxList[0].getShowStart());
            //Debug.WriteLine(this.movieBoxList[0].ShowDate.ToString());
            for (int i = 1; i < this.movieBoxList.Count; i++)
            {
                if (dateToString(this.movieBoxList[i].getShowStart()) != dateToString(this.movieBoxList[i - 1].getShowStart()))
                {
                    dateList.Add(this.movieBoxList[i].getShowStart());
                    Debug.WriteLine("adataan datelistiin jotain: " + this.movieBoxList[i].getShowStart());
                    //Debug.WriteLine(this.movieBoxList[i].ShowStart.ToString());
                }
            }
        }

        //temppilistaan lisätään movieboxeja kunnes päivä on eri kun datelist-listassa oleva
        //lisätään temppilista collectioniin, tehään uus temppilista
        //ja siirrytään datelistassa seuraavaan päivään
        private void setMovieCollectionList()
        {
            this.eventIds = new List<int>();
            this.movieCollectionList = new ObservableCollection<MovieCollection>();
            int dateListIndex = 0;
            List<Movie> movieBoxListTemp = new List<Movie>();
            MovieCollection movieCollectionTemp = new MovieCollection();
            Debug.WriteLine("tehään uus temppilista");
            int i;
            this.eventIds.Add(this.movieBoxList[0].EventID);
            movieBoxListTemp.Add(this.movieBoxList[0]);
            for (i = 0; i < this.movieBoxList.Count; i++)
            {
                if (dateToString(this.movieBoxList[i].getShowStart()) == dateToString(this.dateList[dateListIndex]))
                {
                    if (!this.eventIds.Contains(this.movieBoxList[i].EventID))
                    {
                        movieBoxListTemp.Add(this.movieBoxList[i]);
                        this.eventIds.Add(this.movieBoxList[i].EventID);
                        Debug.WriteLine("Lisätään listaan eventti: " + this.movieBoxList[i].EventID.ToString());
                    }
                }
                else
                {
                    movieCollectionTemp.Day = this.movieBoxList[i - 1].getShowStart();
                    //Debug.WriteLine("Lisätään isoon listaan päivä: " + this.movieBoxList[i - 1].ShowDate.ToString());
                    movieCollectionTemp.Movies = movieBoxListTemp;
                    this.movieCollectionList.Add(movieCollectionTemp);
                    movieCollectionTemp = new MovieCollection();
                    movieBoxListTemp = new List<Movie>();
                    Debug.WriteLine("tehään uus temppilista");
                    movieBoxListTemp.Add(this.movieBoxList[i]);
                    //Debug.WriteLine("Lisätään listaan eventti: " + this.movieBoxList[i].EventId.ToString());
                    dateListIndex++;
                    this.eventIds.Clear();
                    this.eventIds.Add(this.movieBoxList[i].EventID);
                }
            }

            //lisätään viimenen temppilista collectioniin
            movieCollectionTemp.Day = this.movieBoxList[i - 1].getShowStart();
            //Debug.WriteLine("Lisätään isoon listaan päivä: " + this.movieBoxList[i - 1].ShowDate.ToString());
            movieCollectionTemp.Movies = movieBoxListTemp;
            this.movieCollectionList.Add(movieCollectionTemp);
        }
    }
}
