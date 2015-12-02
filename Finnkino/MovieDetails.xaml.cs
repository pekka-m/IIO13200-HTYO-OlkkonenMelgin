using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Finnkino
{
    /// <summary>
    /// Interaction logic for MovieDetails.xaml
    /// </summary>
    public partial class MovieDetails : Window
    {
        private MovieDetailsPresenter presenter;
        private Movie movie;

        public MovieDetails(int eventId, int area, string date, string movieTitle)
        {
            InitializeComponent();

            IAPIGateway gateway = new APIGateway();
            this.presenter = new MovieDetailsPresenter(gateway);

            //string format = "d.M.yyyy " + CultureInfo.CurrentCulture.DateTimeFormat.LongTimePattern;
            //DateTime _date = DateTime.ParseExact(date, format, null);

            this.movie = this.presenter.getMovieDetails(eventId, area, date, movieTitle);

            textBlock_Title.Text = movie.Title.ToString();
            textBlock_Genres.Text = movie.Genres;
            textBlock_Length.Text = movie.LengthInMinutes.ToString() + " min";
            textBlock3.Text = movie.Synopsis;
            textBlock_Rating.Text = movie.Rating;
            comboBox.ItemsSource = movie.Shows;
            backgroundImage.ImageSource = new BitmapImage(new Uri(movie.ImageBackground));
        }

        private void button_Tickets_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.finnkino.fi/Websales/Show/" + movie.Shows[comboBox.SelectedIndex].Id);
        }
    }
}
