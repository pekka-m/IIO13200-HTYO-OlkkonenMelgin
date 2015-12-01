using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Finnkino
{
    /// <summary>
    /// Interaction logic for MovieDetails.xaml
    /// </summary>
    public partial class MovieDetails : Window
    {
        private MovieDetailsPresenter presenter;
        private Movie movie;

        public MovieDetails(int eventId, int area, string date)
        {
            InitializeComponent();

            IAPIGateway gateway = new APIGateway();
            this.presenter = new MovieDetailsPresenter(gateway);

            //string format = "d.M.yyyy " + CultureInfo.CurrentCulture.DateTimeFormat.LongTimePattern;
            //DateTime _date = DateTime.ParseExact(date, format, null);

            this.movie = this.presenter.getMovieDetails(eventId, area, date);

            textBlock_Title.Text = movie.Title.ToString();
            textBlock_Genres.Text = movie.Genres;
            textBlock3.Text = movie.Synopsis;
            comboBox.ItemsSource = movie.Shows;
            backgroundImage.ImageSource = new BitmapImage(new Uri(movie.ImageBackground));
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.finnkino.fi/Websales/Show/" + movie.Shows[comboBox.SelectedIndex].Id);
        }
    }
}
