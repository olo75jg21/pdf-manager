using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;

/// iTextSharp
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;

/// CheckedBoxList
using Xceed.Wpf.Toolkit;

/// Spire 
using Spire.Pdf;
using Spire.Pdf.General.Find;
using System;
using System.Collections.ObjectModel;

/// klasa wybranych pdfow do pracy
class files_info
{
    string sciezka = "";
    int strona; // strona gdzie znajduje sie wyszukany text
    int linia_w_dokumencie; // linia gdzie znajduje sie wyszukany text
    string text; // wyszukany text
    int strona_w_pdfie = 0; // lokalizacja strony w nowo utworzynym  pdfie "Preview" - jesli takowa juz zostala dodana 

    public files_info(string sciezka, int strona, int linia_w_dokumencie, string text)
    {
        this.sciezka = sciezka;
        this.strona = strona;
        this.linia_w_dokumencie = linia_w_dokumencie;
        this.text = text;
    }
    
    // nie wszedzie sa settery ( nie potrzebne aktualnie ) 
    public string Sciezka { get => sciezka; }
    public int Strona { get => strona; }
    public int Linia_w_dokumencie { get => linia_w_dokumencie; }
    public string Text { get => text; }
    public int Strona_w_pdfie { get => strona_w_pdfie; set => strona = value; }
}



namespace pdf_manager
{
   public partial class MainWindow : Window
   {
      // lista dodanych plikow do pracy 
      List<string> filePaths = new List<string>();

      List<files_info> pliki = new List<files_info>();

      // DirrectoryTree elements Collection
      public ObservableCollection<Object> RootDirectoryItems { get; } = new ObservableCollection<object>();

      public MainWindow()
      {
         InitializeComponent();
      }

      // przycisk pod drzewkiem, dodajacy wybrane pliki
      private void ButtonAddSelectedTreeItems_Click(object sender, RoutedEventArgs e)
      {
         string itemHeader = ((HeaderedItemsControl)DirectoryTreeView.SelectedItem).Header.ToString();
         string dir = DirectoryTree.currentDirectory;
         string toSave = dir + "\\" + itemHeader;
         if (!filePaths.Contains(toSave))
            filePaths.Add(toSave);
         refreshFileList();
      }

      private void refreshFileList()
      {
         SelectedItemsList.Children.Clear();

         foreach (string file in filePaths)
         {
            SelectedItemsList.Children.Add(new TextBlock()
            {
               Text = file.Substring(file.LastIndexOf('\\'))
            });
         }
      }

      // przycisk nad drzewkiem katalogu, umozliwiajacy dodanie nowego katalogu
      private void ButtonAddDirectory_Click(object sender, RoutedEventArgs e)
      {
         // System.Windows.Forms.FolderBrowserDialog fbd = new System.Windows.Forms.FolderBrowserDialog();
         string selectedPath = DirectoryTree.OpenDirectoryDialog();

         if (selectedPath != null)
         {
            DirectoryTree.ListDirectory(this.DirectoryTreeView, selectedPath);
         }
      }

      private void Button_Click_1(object sender, RoutedEventArgs e)
      {

      }

      private void mergeButton_Click(object sender, RoutedEventArgs e)
      {
         /*
         object textBoxResult = FindName("mergeOutput");

         if (textBoxResult is TextBlock)
         {
            TextBlock child = textBoxResult as TextBlock;
            foreach (string file_path in filePaths.ToArray())
            {
               child.Text += file_path + " ";
            }
         }
         */

         // Pan prezesik musi naprawić dodawanie
         foreach (string file in filePaths)
         {
            Console.WriteLine(file);
         }

         /*
         string[] filePaths2 = new String[2];
         filePaths2[0] = "C:/Users/admin/Desktop/2/TPI_w02.pdf";
         filePaths2[1] = "C:/Users/admin/Desktop/3/TPI_w03.pdf";
         */

         CombineMultiplePDFs(filePaths, "D:/outMerged.pdf");
      }

      public static void CombineMultiplePDFs(List<string> fileNames, string outFile)
      {
         // step 1: creation of a document-object
         Document document = new Document();
         //create newFileStream object which will be disposed at the end
         using (FileStream newFileStream = new FileStream(outFile, FileMode.Create))
         {
            // step 2: we create a writer that listens to the document
            PdfCopy writer = new PdfCopy(document, newFileStream);

            // step 3: we open the document
            document.Open();

            foreach (string fileName in fileNames)
            {
               // we create a reader for a certain document
               using (PdfReader reader = new PdfReader(fileName))
               {
                  reader.ConsolidateNamedDestinations();

                  // step 4: we add content
                  for (int i = 1; i <= reader.NumberOfPages; i++)
                  {
                     PdfImportedPage page = writer.GetImportedPage(reader, i);
                     writer.AddPage(page);
                  }

                  PRAcroForm form = reader.AcroForm;
                  if (form != null)
                  {
                     writer.AddDocument(reader);
                  }

                  reader.Close();
               }
            }

            // step 5: we close the document and writer
            writer.Close();
            document.Close();
         }//disposes the newFileStream object
      }
   }
}
