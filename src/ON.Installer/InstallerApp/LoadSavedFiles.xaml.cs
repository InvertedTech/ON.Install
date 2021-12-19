using ON.Installer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
using System.Windows.Shapes;

namespace InstallerApp
{
    /// <summary>
    /// Interaction logic for GodaddyPull.xaml
    /// </summary>
    public partial class LoadSavedFiles : Window
    {
        public LoadSavedFiles()
        {
            InitializeComponent();
        }

        public MainModel Selected { get; set; }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            Selected = (treeFiles.SelectedItem as TreeViewItem)?.DataContext as MainModel;

            DialogResult = true;
        }

        public void Load()
        {
            treeFiles.Items.Clear();

            foreach (var d in MainWindow.SaveLocation.GetDirectories())
            {
                try
                {
                    var f = new FileInfo(d.FullName + "/" + MainWindow.SAVED_FILENAME);
                    if (!f.Exists)
                        continue;

                    MainModel m = LoadFiles(f);

                    TreeViewItem item = new TreeViewItem();
                    item.Header = m.Personalization.Name;
                    item.DataContext = m;

                    treeFiles.Items.Add(item);
                }
                catch { }
            }
        }

        private MainModel LoadFiles(FileInfo f)
        {
            var json = File.ReadAllText(f.FullName);
            return JsonSerializer.Deserialize<MainModel>(json);
        }
    }
}
