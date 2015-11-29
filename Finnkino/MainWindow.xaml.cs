using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
        BrowserPresenter presenter;
        List<string> genres;
        List<string> ageLimits;
        List<DateTime> dates;
        ObservableCollection<MovieCollection> collection;
        Dictionary<string, string> filters;

        public MainWindow()
        {
            InitializeComponent();
            IAPIGateway gateway = new MockAPIGateway();
            this.presenter = new BrowserPresenter(gateway);
            this.filters = new Dictionary<string, string>();

            filters.Add("Day", "Kaikki");
            filters.Add("Genre", "Kaikki");
            filters.Add("AgeLimit", "Kaikki");
            filters.Add("Auditorium", "Kaikki");
            comboBox_Area.ItemsSource = this.presenter.getAreas();
            this.initializeFilters();          
        }

        private void comboBox_Area_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            filters["Day"] = "Kaikki";
            filters["Genre"] = "Kaikki";
            filters["AgeLimit"] = "Kaikki";
            filters["Auditorium"] = "Kaikki";
            Debug.WriteLine("valittu area / teatteri id: " + comboBox_Area.SelectedValue.ToString());
            this.collection = this.presenter.initialize(int.Parse(comboBox_Area.SelectedValue.ToString()));
            BrowserIC.ItemsSource = this.collection;
            comboBox_Filter_Auditorium.ItemsSource = this.presenter.getAuditoriums(int.Parse(comboBox_Area.SelectedValue.ToString()));
        }

        private void comboBox_Filter_Genre_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            filters["Genre"] = comboBox_Filter_Genre.SelectedValue.ToString();
            this.collection = this.presenter.getMovies(this.filters);
            //this.collection = this.presenter.filterByGenre(comboBox_Filter_Genre.SelectedValue.ToString());
            BrowserIC.ItemsSource = this.collection;
        }


        private void comboBox_Filter_AgeLimit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            filters["AgeLimit"] = comboBox_Filter_AgeLimit.SelectedValue.ToString();
            this.collection = this.presenter.getMovies(this.filters);
            //this.collection = this.presenter.filterByAgeLimit(comboBox_Filter_AgeLimit.SelectedValue.ToString());
            BrowserIC.ItemsSource = this.collection;
        }

        private void comboBox_Filter_Auditorium_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                filters["Auditorium"] = comboBox_Filter_Auditorium.SelectedValue.ToString();
            }
            catch (Exception)
            {
                filters["Auditorium"] = "Kaikki";
            }
            this.collection = this.presenter.getMovies(this.filters);
            BrowserIC.ItemsSource = this.collection;
        }

        private void comboBox_Sort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!filters.ContainsKey("Day"))
            {
                filters["Day"] = "Kaikki";
            }
            else
            {
                filters["Day"] = comboBox_Sort.SelectedValue.ToString();
            }
            this.collection = this.presenter.getMovies(this.filters);
        }

        private void button_clearDay_Click(object sender, RoutedEventArgs e)
        {
            filters["Day"] = "Kaikki";
            this.collection = this.presenter.getMovies(this.filters);
            BrowserIC.ItemsSource = this.collection;
        }
        private void initializeFilters()
        {
            genres = new List<string>();
            genres.Add("Kaikki");
            genres.Add("Animaatio");
            genres.Add("Dokumentti");
            genres.Add("Draama");
            genres.Add("Elämäkerta");
            genres.Add("Fantasia");
            genres.Add("Jännitys");
            genres.Add("Kauhu");
            genres.Add("Komedia");
            genres.Add("Kotimainen");
            genres.Add("Musiikki");
            genres.Add("Perhe-elokuva");
            genres.Add("Rikoselokuva");
            genres.Add("Romantiikka");
            genres.Add("Sci-fi");
            genres.Add("Seikkailu");
            genres.Add("Sota");
            genres.Add("Toiminta");
            genres.Add("3D");
            ageLimits = new List<string>();
            ageLimits.Add("Kaikki");
            ageLimits.Add("Luok_vap");
            ageLimits.Add("S");
            ageLimits.Add("7");
            ageLimits.Add("12");
            ageLimits.Add("16");
            ageLimits.Add("18");
            comboBox_Filter_Genre.ItemsSource = this.genres;
            comboBox_Filter_AgeLimit.ItemsSource = this.ageLimits;
            comboBox_Filter_Genre.SelectedIndex = 0;
            comboBox_Filter_AgeLimit.SelectedIndex = 0;

            dates = new List<DateTime>();
            for (int i = 0; i < 14; i++)
            {
                dates.Add(DateTime.Now.AddDays(i));
                Debug.WriteLine(DateTime.Now.AddDays(i));
            }
            comboBox_Sort.ItemsSource = this.dates;
            comboBox_Sort.ItemStringFormat = "ddd dd.MM";
            //comboBox_Sort.SelectedIndex = 0;
        }
    }
}
