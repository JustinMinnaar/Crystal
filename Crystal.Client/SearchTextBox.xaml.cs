using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
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
    public partial class SearchTextBox : UserControl
    {
        private Timer t;
        private string text;

        public event EventHandler<string> Search;

        public SearchTextBox()
        {
            InitializeComponent();
            t = new Timer(250);
            t.Elapsed += T_Elapsed;
            t.Stop();
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            text = txtSearch.Text;
            t.Stop();
            t.Start();
        }

        private void T_Elapsed(object sender, ElapsedEventArgs e)
        {
            Search?.Invoke(this, text);
        }
    }
}
