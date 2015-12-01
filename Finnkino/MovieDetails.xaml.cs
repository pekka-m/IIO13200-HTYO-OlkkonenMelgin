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

        public MovieDetails(int eventId, int area, string date)
        {
            InitializeComponent();

            IAPIGateway gateway = new APIGateway();
            this.presenter = new MovieDetailsPresenter(gateway);

            string format = "d.M.yyyy " + CultureInfo.CurrentCulture.DateTimeFormat.LongTimePattern;
            DateTime _date = DateTime.ParseExact(date, format, null);

            textBlock.Text = eventId.ToString();
            textBlock2.Text = area.ToString();
            textBlock3.Text = _date.ToString();
        }
    }
}
