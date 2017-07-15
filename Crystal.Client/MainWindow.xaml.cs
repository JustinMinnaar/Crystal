using Crystal.Data;
using System;
using System.Collections.Generic;
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
using System.Windows.Threading;

namespace Crystal.Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CrystalStuff stuff;
        private Dispatcher d;

        public MainWindow()
        {
            InitializeComponent();
            InitializeDispatcher();
            InitialiseListOfStuff();
        }

        protected override void OnClosed(EventArgs e)
        {
            d = null;
            base.OnClosed(e);
        }

        private void InitializeDispatcher()
        {
            d = Dispatcher.CurrentDispatcher;
        }

        private void InitialiseListOfStuff()
        {
            stuff = new CrystalStuff();
            lstTypes.ItemsSource = stuff.Types;
        }

        private void txtSearch_Search(object sender, string text)
        {
            if (d == null) return;
            var result = from t in stuff.Types where t.Contains(text) orderby t select t;
            d?.Invoke(delegate { lstTypes.ItemsSource = result; });
        }
    }
}
