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
using System.Windows.Forms;
using System;

/// klasa wybranych pdfow do pracy
class files_info
{
    string sciezka = "";
    int strona; // strona gdzie znajduje sie wyszukany text
    int linia_w_dokumencie; // linia gdzie znajduje sie wyszukany text
    string text; // wyszukany text

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
}



namespace pdf_manager
{
    public partial class MainWindow : Window
    {
        // lista dodanych plikow do pracy 
        List<string> filePaths = new List<string>();

        List<files_info> pliki = new List<files_info>();

        List<int> pliki_dodane = new List<int>();

        public MainWindow()
        {
            InitializeComponent();
        }

        // przycisk pod drzewkiem, dodajacy wybrane pliki
        private void ButtonAddSelectedTreeItems_Click(object sender, RoutedEventArgs e)
        {
            string itemHeader = ((HeaderedItemsControl)Drzewko.SelectedItem).Header.ToString();
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
                DirectoryTree.ListDirectory(this.Drzewko, selectedPath);
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (filePaths.Count != 0)
            {
                string szukana_fraza;
                int licznik = 1;

                if (case_sensitivity.IsChecked == true)
                    szukana_fraza = searching_word.Text.ToLower();
                else
                    szukana_fraza = searching_word.Text;

                foreach (var path in filePaths)
                {
                    using (PdfReader reader = new PdfReader(path))
                    {
                        //StringBuilder text = new StringBuilder();
                        //ITextExtractionStrategy Strategy = new iTextSharp.text.pdf.parser.LocationTextExtractionStrategy();

                        string strText = string.Empty;
                        ITextExtractionStrategy its = new iTextSharp.text.pdf.parser.LocationTextExtractionStrategy();
                                    licznik++;
                                }
                                j++;
                            }
                        }
                    }
                }
            }
        }

        private void clear_Click(object sender, RoutedEventArgs e)
        {
            results.Items.Clear();
        }

        private void preview_Click(object sender, RoutedEventArgs e)
        {
            /// Tworzenie nowego pliku pdf 
            FileStream stream = new FileStream("C:/Users/Tomek/Desktop/demo.pdf", FileMode.Create, FileAccess.Write, FileShare.None);
            Document doc = new Document();
            PdfCopy nowy_pdf = new PdfCopy(doc, stream);
            doc.Open();

            // Sprawdzenie czy jakis checkbox zostal zaznaczony 
            for (int x = 0; x < results.SelectedItems.Count; x++)
            {
                // wyluskanie numeru linii z ListBox'a 
                string number = results.SelectedItems[x].ToString();
                number = number.Substring(0, number.IndexOf(":"));

                // w strukturze indeksuje sie od 0 dlatego - 1
                int listBoxLineNumber = Int32.Parse(number) - 1 ;
                bool czyStrona = false;

                // literacja po dodanych plikach i sprawdzenie czy ktoras ze stron nie zostal juz dodana ( ta sama sciezka i strona ) 
                for(int i=0; i < pliki_dodane.Count; i++)
                {
                    if ( pliki[ listBoxLineNumber ].Sciezka ==  pliki[ pliki_dodane[i] ].Sciezka )
                    {
                        if( pliki[ listBoxLineNumber ].Strona == pliki[pliki_dodane[i] ].Strona )
                        {
                            czyStrona = true;
                            break;
                        }
                    }
                }

                string path = pliki[listBoxLineNumber].Sciezka;
                if ( czyStrona == false )
                {
                    // przypisanie do zmiennej na ktorej stronie znajduje sie w nowym pdfie
                    System.Windows.MessageBox.Show(pliki[listBoxLineNumber].Sciezka.ToString());
                    System.Windows.MessageBox.Show(pliki[listBoxLineNumber].Strona.ToString());

                    // kopiowanie do nowo utworzonego pdfa strony
                    using (PdfReader kopiowany_pdf = new PdfReader(path))
                      {
                            System.Windows.MessageBox.Show(pliki[listBoxLineNumber].Strona.ToString());
                            PdfImportedPage importedPage = nowy_pdf.GetImportedPage(kopiowany_pdf, pliki[listBoxLineNumber].Strona );
                            nowy_pdf.AddPage(importedPage);
                      }

                      // wpisanie do listy dodanych linii z ListBoxa 
                      pliki_dodane.Add(listBoxLineNumber);
                }
  /*
                doc.Close();

                Spire.Pdf.PdfDocument docSpire = new Spire.Pdf.PdfDocument();
                docSpire.LoadFromFile(path);
                PdfPageBase page = docSpire.Pages[pliki[listBoxLineNumber].Strona - 1]; // liczy od 0 strony || wybor strony do przeszukania
                PdfTextFind[] result = page.FindText(pliki[listBoxLineNumber].Text).Finds; // przeszukanie strony 
                result[0].ApplyHighLight();
*/
            }
            // wyswietlenie pdfa w przegladarce i zamkniecie dokumentu
            System.Diagnostics.Process.Start(@"C:\Users\Tomek\Desktop\demo.pdf"); // wyswietlenie pliku podgladowego  
            doc.Close();

        }
           
      private void Button_Click_1(object sender, RoutedEventArgs e)
      {

      }

    }
}
