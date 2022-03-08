using System;
using System.Collections.Generic;
using System.IO;
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

namespace pdf_manager
{
   /// <summary>
   /// Logika interakcji dla klasy MainWindow.xaml
   /// </summary>
   public partial class MainWindow : Window
   {
      public MainWindow()
      {
         InitializeComponent();
      }

      private void ListDirectory(TreeView treeView, string path)
      {
          var rootDirectoryInfo = new DirectoryInfo(path);
          treeView.Items.Add(CreateDirectoryNode(rootDirectoryInfo));
      }

      private static TreeViewItem CreateDirectoryNode(DirectoryInfo directoryInfo)
      {
          var directoryNode = new TreeViewItem { Header = directoryInfo.Name };
          foreach (var directory in directoryInfo.GetDirectories())
            directoryNode.Items.Add(CreateDirectoryNode(directory));

          foreach (var file in directoryInfo.GetFiles())
            if (file.Extension == ".pdf")
                directoryNode.Items.Add(new TreeViewItem { Header = file.Name });

          return directoryNode;
      }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog fbd = new System.Windows.Forms.FolderBrowserDialog();

            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ListDirectory(this.Drzewko, fbd.SelectedPath);
            }
        }
    }
}
