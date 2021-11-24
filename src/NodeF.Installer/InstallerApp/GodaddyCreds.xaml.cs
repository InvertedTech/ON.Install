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
    /// Interaction logic for GodaddyCreds.xaml
    /// </summary>
    public partial class GodaddyCreds : Window
    {
        public GodaddyCreds()
        {
            InitializeComponent();
        }

        public string Key
        {
            get { return passKey.Password; }
            set { passKey.Password = value; }
        }

        public string Secret
        {
            get { return passSecret.Password; }
            set { passSecret.Password = value; }
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
