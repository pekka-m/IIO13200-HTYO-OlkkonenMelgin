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
        BrowserPresenter presenter;
        public MainWindow()
        {
            InitializeComponent();
            IAPIGateway gateway = new MockAPIGateway();
            this.presenter = new BrowserPresenter(gateway);
            this.Movies = this.presenter.initialize(1);
            itemsControl.ItemsSource = this.Movies;
        }
    }
}
