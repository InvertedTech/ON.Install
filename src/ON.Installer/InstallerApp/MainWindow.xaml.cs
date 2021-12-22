using Microsoft.Win32;
using NBitcoin;
using ON.Installer.Models;
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
using static System.Environment;

namespace InstallerApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainModel MainModel { get; set; } = new();

        public static DirectoryInfo RootLocation;
        public static DirectoryInfo SaveLocation;
        public static DirectoryInfo TerraformLocation;
        public const string SAVED_FILENAME = "config.onf";

        const string FILE_FILTER = "ON Config File (*.onfx)|*.onfx";

        TreeViewItem[] treeNavItems;

        public MainWindow()
        {
            InitializeComponent();

            GetNavItems();

            RootLocation = new DirectoryInfo(GetFolderPath(SpecialFolder.ApplicationData) + "/ONF");
            SaveLocation = new DirectoryInfo(RootLocation.FullName + "/saves");
            SaveLocation.Create();
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
            MainModel = new();
            frmMain.Refresh();
        }

        void NewCmdCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        void OpenCmdExecuted(object target, ExecutedRoutedEventArgs e)
        {
            var dialog = new LoadSavedFiles();
            dialog.Load();

            if (dialog.ShowDialog() == true)
            {
                LoadSavedFile(dialog.Selected);
            }
        }

        private void LoadSavedFile(LoadSavedFiles.ModelInfo info)
        {
            MainModel = info.Model;
            frmMain.Refresh();

            TerraformLocation = new DirectoryInfo(info.ConfigFile.DirectoryName + "/terraform");
            TerraformLocation.Create();
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
            if (MainModel.Id == Guid.Empty)
                MainModel.Id = Guid.NewGuid();

            if (MainModel.Credentials == null)
                MainModel.Credentials = new();

            if (string.IsNullOrWhiteSpace(MainModel.Credentials.MasterKey))
            {
                Mnemonic mnemo = new Mnemonic(Wordlist.English, WordCount.TwentyFour);
                MainModel.Credentials.MasterKey = string.Join(" ", mnemo.Words);
            }    

            var d = new DirectoryInfo(SaveLocation.FullName + "/" + MainModel.Id);
            d.Create();

            var json = JsonSerializer.Serialize(MainModel);
            File.WriteAllText(d.FullName + "/" + SAVED_FILENAME, json);
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

            PerformSave();
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
