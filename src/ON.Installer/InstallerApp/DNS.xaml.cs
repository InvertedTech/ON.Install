using ON.Installer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
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

namespace InstallerApp
{
    /// <summary>
    /// Interaction logic for Page2.xaml
    /// </summary>
    public partial class DNS : Page
    {
        public DNSModel MyModel { get; set; }

        public DNS()
        {
            MyModel = MainWindow.MainModel.DNS;

            InitializeComponent();

            DataContext = MyModel;
        }

        private void GodaddyCreds_onClick(object sender, RoutedEventArgs e)
        {
            var dialog = new GodaddyCreds();
            dialog.Key = MyModel.GodaddyApiKey;
            dialog.Secret = MyModel.GodaddyApiSecret;
            if (dialog.ShowDialog() == true)
            {
                MyModel.GodaddyApiKey = dialog.Key;
                MyModel.GodaddyApiSecret = dialog.Secret;
            }
        }

        private void GodaddyPull_onClick(object sender, RoutedEventArgs e)
        {
            try
            {
                using (WebClient wc = new())
                {
                    wc.Headers.Add("accept", "application/json");
                    wc.Headers.Add("Authorization", "sso-key " + MyModel.GodaddyApiKey + ":" + MyModel.GodaddyApiSecret);
                    var json = wc.DownloadString("https://api.godaddy.com/v1/domains?statuses=ACTIVE");
                    var domains = JsonSerializer.Deserialize<List<GodaddyDomainDetails>>(json);

                    var dialog = new GodaddyPull();
                    dialog.Domains = domains.Select(d => d.domain);

                    if (dialog.ShowDialog() == true)
                    {
                        txtName.Text = dialog.SelectedDomain;
                        MyModel.Name = dialog.SelectedDomain;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Error pulling your domains from GoDaddy.");
            }
        }
    }
}
