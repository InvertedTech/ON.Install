using Microsoft.Win32;
using NodeF.Installer.Models;
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

namespace InstallerApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainModel MainModel { get; set; }

        const string FILE_FILTER = "Node Config File (*.ncfgx)|*.ncfgx";

        TreeViewItem[] treeNavItems;

        public MainWindow()
        {
            LoadMainModel();

            InitializeComponent();

            GetNavItems();
        }

        private void LoadMainModel()
        {
            MainModel = new MainModel()
            {
                Personalization = new PersonalizationModel()
                {
                    Name = "asdf",
                    Description = "fdsa"
                }
            };
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
                MessageBox.Show(saveFileDialog.FileName);
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
                MessageBox.Show(openFileDialog.FileName);
            }
        }

        void OpenCmdCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        void SaveCmdExecuted(object target, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Save it!");
        }

        void SaveCmdCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
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
