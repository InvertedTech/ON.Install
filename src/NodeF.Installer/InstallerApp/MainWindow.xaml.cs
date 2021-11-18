using Microsoft.Win32;
using NodeF.Installer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainModel MainModel { get; set; }
        public string CurrentFileName = null;

        const string FILE_FILTER = "Node Config File (*.ncfgx)|*.ncfgx";

        TreeViewItem[] treeNavItems;

        public MainWindow()
        {
            LoadMainModel(null);

            InitializeComponent();

            GetNavItems();
        }

        private void LoadMainModel(string fileName)
        {
            if (File.Exists(fileName))
            {
                try
                {
                    var json = File.ReadAllText(fileName);
                    MainModel = JsonSerializer.Deserialize<MainModel>(json);
                    return;
                }
                catch
                {
                    MessageBox.Show("Unable to parse and load file!");
                }
            }
            MainModel = new MainModel();
        }

        private void GetNavItems()
        {
            treeNavItems = GetNavItems(treeNav.Items).ToArray();
        }

        private List<TreeViewItem> GetNavItems(ItemCollection items)
        {
            List<TreeViewItem> list = new List<TreeViewItem>();

            foreach (var i in items)
            {
                var tvi = i as TreeViewItem;
                if (tvi.Items.Count == 0)
                {
                    list.Add(tvi);
                }
                else
                {
                    list.AddRange(GetNavItems(tvi.Items));
                }
            }

            return list;
        }

        void NewCmdExecuted(object target, ExecutedRoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = FILE_FILTER;
            if (saveFileDialog.ShowDialog() == true)
            {
                CurrentFileName = saveFileDialog.FileName;
                LoadMainModel(null);
            }
        }

        void NewCmdCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        void OpenCmdExecuted(object target, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = FILE_FILTER;
            if (openFileDialog.ShowDialog() == true)
            {
                CurrentFileName = openFileDialog.FileName;
                LoadMainModel(CurrentFileName);
                frmMain.Refresh();
            }
        }

        void OpenCmdCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        void SaveCmdExecuted(object target, ExecutedRoutedEventArgs e)
        {
            PerformSave();

            MessageBox.Show("File saved.");
        }

        void SaveCmdCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void PerformSave()
        {
            var json = JsonSerializer.Serialize(MainModel);

            File.WriteAllText(CurrentFileName, json);
        }

        DeployWindow deployWindow;
        private async void btnDeploy_Click(object sender, RoutedEventArgs e)
        {
            PerformSave();

            if (deployWindow != null)
                return;

            deployWindow = new DeployWindow();
            deployWindow.Show();
            await deployWindow.StartDeploying();
        }

        private void btnPersonalization_Click(object sender, RoutedEventArgs e)
        {
            if (frmMain != null)
                frmMain.Source = new Uri("Personalization.xaml", UriKind.RelativeOrAbsolute);
        }

        private void btnDNS_Click(object sender, RoutedEventArgs e)
        {
            if (frmMain != null)
                frmMain.Source = new Uri("DNS.xaml", UriKind.RelativeOrAbsolute);
        }

        private void btnCMS_Selected(object sender, RoutedEventArgs e)
        {
            if (frmMain != null)
                frmMain.Source = new Uri("CMS.xaml", UriKind.RelativeOrAbsolute);
        }

        private void btnAuthentication_Selected(object sender, RoutedEventArgs e)
        {
            if (frmMain != null)
                frmMain.Source = new Uri("Authentication.xaml", UriKind.RelativeOrAbsolute);
        }

        private void btnPayments_Selected(object sender, RoutedEventArgs e)
        {
            if (frmMain != null)
                frmMain.Source = new Uri("Payments.xaml", UriKind.RelativeOrAbsolute);
        }

        private void btnMicroblog_Selected(object sender, RoutedEventArgs e)
        {
            if (frmMain != null)
                frmMain.Source = new Uri("Microblog.xaml", UriKind.RelativeOrAbsolute);
        }

        private void btnCommunity_Selected(object sender, RoutedEventArgs e)
        {
            if (frmMain != null)
                frmMain.Source = new Uri("Community.xaml", UriKind.RelativeOrAbsolute);
        }

        private void btnLocation_Selected(object sender, RoutedEventArgs e)
        {
            if (frmMain != null)
                frmMain.Source = new Uri("Location.xaml", UriKind.RelativeOrAbsolute);
        }

        private void btnBackup_Selected(object sender, RoutedEventArgs e)
        {
            if (frmMain != null)
                frmMain.Source = new Uri("Backup.xaml", UriKind.RelativeOrAbsolute);
        }

        private void btnCredentials_Selected(object sender, RoutedEventArgs e)
        {
            if (frmMain != null)
                frmMain.Source = new Uri("Credentials.xaml", UriKind.RelativeOrAbsolute);
        }

        private void btnPreviousPage_Click(object sender, RoutedEventArgs e)
        {
            if (treeNavItems.First().IsSelected)
                return;

            for (int i = 0; i < treeNavItems.Length; i++)
            {
                if (treeNavItems[i].IsSelected)
                {
                    treeNavItems[i - 1].IsSelected = true;
                    return;
                }
            }

            treeNavItems.First().IsSelected = true;
        }

        private void btnNextPage_Click(object sender, RoutedEventArgs e)
        {
            if (treeNavItems.Last().IsSelected)
                return;

            for (int i = 0; i < treeNavItems.Length; i++)
            {
                if (treeNavItems[i].IsSelected)
                {
                    treeNavItems[i + 1].IsSelected = true;
                    return;
                }
            }

            treeNavItems.First().IsSelected = true;
        }
    }
}
