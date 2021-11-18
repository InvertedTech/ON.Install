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
using System.Windows.Shapes;

namespace InstallerApp
{
    /// <summary>
    /// Interaction logic for GodaddyPull.xaml
    /// </summary>
    public partial class GodaddyPull : Window
    {
        public GodaddyPull()
        {
            InitializeComponent();
        }

        public IEnumerable<string> Domains
        {
            set
            {
                cbDomains.Items.Clear();
                foreach (string i in value)
                    cbDomains.Items.Add(i);
            }
        }

        public string SelectedDomain { get => cbDomains.SelectedValue as string; }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
