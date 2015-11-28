using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Finnkino
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Movie> Movies = new List<Movie>();
        List<string> Titles = new List<string>();
        List<MovieCollection> MovieCollectionList;
        BrowserPresenter presenter;
        public MainWindow()
        {
            InitializeComponent();

            Titles.Add("Päivä 1");
            Titles.Add("Päivä 2");
            Titles.Add("Päivä 3");

            IAPIGateway gateway = new MockAPIGateway();
            this.presenter = new BrowserPresenter(gateway);
            this.MovieCollectionList = this.presenter.initialize(1);
            /*
            Browser = new List<MovieCollection>();
            Browser.Add(new MovieCollection("Päivä 1", this.Movies));
            Browser.Add(new MovieCollection("Päivä 2", this.Movies));
            Browser.Add(new MovieCollection("Päivä 3", this.Movies));
            */
            BrowserIC.ItemsSource = MovieCollectionList;
        }
    }
}
