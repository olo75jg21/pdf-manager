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
using System.Drawing;

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

        string pathToSavePreview = System.IO.Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "preview.pdf");

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
                        PdfReader reader = new PdfReader(@path);
                        string[] words;
                        string line;

                        for (int i = 1; i <= reader.NumberOfPages; i++)
                        {
                            string text = PdfTextExtractor.GetTextFromPage(reader, i, new LocationTextExtractionStrategy());

                            words = text.Split('\n');
                            for (int x = 0, len = words.Length; x < len; x++)
                            {
                                line = Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(words[x]));

                                if (line.Contains("Ala"))
                                {
                                    results.Items.Add( licznik + ": Strona " + i + " Linia: " + (x + 1) + "\n" + line + "\n");
                                    pliki.Add(new files_info(path, i, x, line));
                                    licznik++;
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
            FileStream stream = new FileStream(pathToSavePreview, FileMode.Create, FileAccess.Write, FileShare.None);
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
                int listBoxLineNumber = Int32.Parse(number) - 1;
                bool czyStrona = false;

                // literacja po dodanych plikach i sprawdzenie czy ktoras ze stron nie zostal juz dodana ( ta sama sciezka i strona ) 
                for (int i = 0; i < pliki_dodane.Count; i++)
                {
                    if (pliki[listBoxLineNumber].Sciezka == pliki[pliki_dodane[i]].Sciezka)
                    {
                        if (pliki[listBoxLineNumber].Strona == pliki[pliki_dodane[i]].Strona)
                        {
                            czyStrona = true;
                            break;
                        }
                    }
                }

                string path = pliki[listBoxLineNumber].Sciezka;
                if (czyStrona == false)
                {
                    // kopiowanie do nowo utworzonego pdfa strony
                    using (PdfReader kopiowany_pdf = new PdfReader(path))
                    {
                        PdfImportedPage importedPage = nowy_pdf.GetImportedPage(kopiowany_pdf, pliki[listBoxLineNumber].Strona);
                        nowy_pdf.AddPage(importedPage);
                    }

                    // wpisanie do listy dodanych linii z ListBoxa 
                    pliki_dodane.Add(listBoxLineNumber);
                }
                /*
                                Spire.Pdf.PdfDocument docSpire = new Spire.Pdf.PdfDocument();
                                docSpire.LoadFromFile("C:/Users/Tomek/Desktop/demo.pdf");
                                PdfPageBase page = docSpire.Pages[0]; // liczy od 0 strony || wybor strony do przeszukania
                                PdfTextFind[] finds = page.FindText(pliki[listBoxLineNumber].Text, TextFindParameter.CrossLine).Finds; // przeszukanie strony 

                                foreach (PdfTextFind result in finds)
                                {
                                    result.ApplyHighLight(Color.Yellow);
                                }

                                docSpire.SaveToFile("C:/Users/Tomek/Desktop/demo.pdf", FileFormat.PDF);
                                docSpire.Close();
                */
            }
                // wyswietlenie pdfa w przegladarce i zamkniecie dokumentu
                System.Diagnostics.Process.Start(@pathToSavePreview); // wyswietlenie pliku podgladowego  
                doc.Close();
        }
           
      private void Button_Click_1(object sender, RoutedEventArgs e)
      {

      }

        private void savePreview_Click(object sender, RoutedEventArgs e)
        {
            var folderBrowserDialog1 = new FolderBrowserDialog();
            DialogResult result = folderBrowserDialog1.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK)
            {

                if( ischecked )
                {
                     using (Stream output = new FileStream(destPdf, FileMode.Create, FileAccess.Write, FileShare.None))
                     {
                          PdfReader reader = new PdfReader(input);
                          string Password = "abc@123";
                          PdfEncryptor.Encrypt(reader, output, true, Password, Password, PdfWriter.ALLOW_PRINTING);
                     }
                }
                PdfWriter writer = PdfWriter.getInstance(document, new FileOutputStream("password-protected.pdf"));
                writer.setEncryption(
                        USER_PASSWORD.getBytes(),
                        OWNER_PASSWORD.getBytes(),
                        PdfWriter.ALLOW_COPY | PdfWriter.ALLOW_PRINTING,
                        PdfWriter.ENCRYPTION_AES_256 | PdfWriter.DO_NOT_ENCRYPT_METADATA);


                /*

                if (File.Exists(pathToSavePreview))
                {
                    File.Move(pathToSavePreview, folderBrowserDialog1.SelectedPath + "/savedPDF.pdf");
                    File.Delete(pathToSavePreview);
                }
                */
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            if (File.Exists(pathToSavePreview))
            {
                File.Delete(pathToSavePreview);
            }
        }

        private void password_GotFocus(object sender, RoutedEventArgs e)
        {
            password.Text = "";
        }

        private void password_LostFocus(object sender, RoutedEventArgs e)
        {
            password.Text = "Insert Password";
        }
    }
}
