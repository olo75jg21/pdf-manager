using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace pdf_manager
{
    internal class DirectoryTree
    {
        public static string currentDirectory;

        public static string OpenDirectoryDialog()
        {
            var dlg = new CommonOpenFileDialog();
            dlg.Title = "Wybierz katalog do dodania";
            dlg.IsFolderPicker = true;
            dlg.InitialDirectory = currentDirectory;

            dlg.AddToMostRecentlyUsedList = false;
            dlg.AllowNonFileSystemItems = false;
            
            dlg.EnsureFileExists = true;
            dlg.EnsurePathExists = true;
            dlg.EnsureReadOnly = false;
            dlg.EnsureValidNames = true;
            dlg.Multiselect = false;
            dlg.ShowPlacesList = true;

            if (dlg.ShowDialog() == CommonFileDialogResult.Ok)
            {
                currentDirectory = dlg.FileName;
            }

            return currentDirectory;
        }

        public static void ListDirectory(TreeView treeView, string path)
        {
            DirectoryInfo rootDirectoryInfo = new DirectoryInfo(path);
            treeView.Items.Add(CreateDirectoryNode(rootDirectoryInfo));
        }

        private static TreeViewItem CreateDirectoryNode(DirectoryInfo directoryInfo)
        {
            TreeViewItem directoryNode = new TreeViewItem { Header= directoryInfo.Name };
            //foreach (var directory in directoryInfo.GetDirectories())
            //    directoryNode.Items.Add(CreateDirectoryNode(directory));

            foreach (var file in directoryInfo.GetFiles())
                if (file.Extension == ".pdf")
                    directoryNode.Items.Add(new TreeViewItem { Header = file.Name });

            return directoryNode;
        }
    }
}
