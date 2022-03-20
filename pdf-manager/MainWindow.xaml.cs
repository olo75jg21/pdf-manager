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

        public MainWindow()
        {
            InitializeComponent();
        }

        // przycisk pod drzewkiem, dodajacy wybrane pliki
        private void ButtonAddSelectedTreeItems_Click(object sender, RoutedEventArgs e)
        {
            string itemHeader = ((HeaderedItemsControl)Drzewko.SelectedItem).Header.ToString();
            filePaths.Add(itemHeader);
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
            string path = "file:///C:/Users/Tomek/Desktop/test.pdf";
            // string searchText = "Ala";
           
            using (PdfReader reader = new PdfReader(path))
            {
                StringBuilder text = new StringBuilder();
                ITextExtractionStrategy Strategy = new iTextSharp.text.pdf.parser.LocationTextExtractionStrategy();

                for (int i = 1; i <= reader.NumberOfPages; i++)
                {
                    string page = "";

                    page = PdfTextExtractor.GetTextFromPage(reader, i, Strategy);
                    string[] lines = page.Split('\n');

                    int j = 1;
                    foreach (string line in lines)
                    {
                        if (line.Contains("Ala"))
                        {
                            results.Items.Add("Strona: " + i + " Linia: " + j + "\n" + line + "\n");
                            pliki.Add(new files_info("",i,j,line) );
                        }
                        j++;
                    }
                }
            }
        }

        private void preview_Click(object sender, RoutedEventArgs e)
        {
            /// Tworzenie nowego pliku pdf 
            FileStream stream = new FileStream("demo.pdf", FileMode.Create, FileAccess.Write, FileShare.None);
            Document doc = new Document();
            PdfCopy nowy_pdf = new PdfCopy(doc, stream);
            doc.Open();

            // aktualna ilosc stron w nowo utworzonym pdfie
            int ilosc_stron = 1;

           // Sprawdzenie czy jakis checkbox zostal zaznaczony 
            if (results.SelectedItems.Count != 0)
            {
                // Petla po wybranych checkboxach 
                for (int x = 0; x < results.SelectedItems.Count; x++)
                {
                    // Sprawdzenie czy juz nie ma wybranego tekstu w nowo stworzonym pdfie
                    bool czyStrona = false;
                    for (int i = 0; i < x; i++)
                    {
                        // sprawdzenie czy uzyte byly te same pliki
                        if (pliki[i].Sciezka == pliki[i].Sciezka)
                        {
                            // sprawdzenie czy dodane zostaly te same linie do pliku
                            if (pliki[i].Strona == pliki[x].Strona)
                            {
                                czyStrona = true;
                                break;
                            }
                        }
                    }

                    // jesli plik nie zostal dodany w takim wypadku go dodajemy 
                    if(czyStrona == false)
                    {
                        // przypisanie do zmiennej na ktorej stronie znajduje sie w nowym pdfie
                        pliki[x].Strona_w_pdfie = ilosc_stron;
                        ilosc_stron++;

                        string path = "file:///C:/Users/Tomek/Desktop/test.pdf";

                        using (PdfReader kopiowany_pdf = new PdfReader(path))
                        {
                            PdfImportedPage importedPage = nowy_pdf.GetImportedPage(kopiowany_pdf, pliki[x].Strona);
                            nowy_pdf.AddPage( importedPage );
                        }
                    }
                    doc.Close();


                    // podekreslenie tekstu w nowym pliku - uzycie nowego frameworka Spire || itextsharp nie oferuje tego 
                    
                    // otwarcie pliku utowrzonego poprzednio
                    Spire.Pdf.PdfDocument docSpire = new Spire.Pdf.PdfDocument();
                    docSpire.LoadFromFile("demo.pdf");

                    PdfPageBase page = docSpire.Pages[ pliki[x].Strona - 1 ]; // liczy od 0 strony || wybor strony do przeszukania

                    PdfTextFind[] result = page.FindText(pliki[x].Text).Finds; // przeszukanie strony 

                    result[0].ApplyHighLight(); // dodanie tylko do pierwszego znalezienia podkreslenia 
                                                //  teoretycznie nie bedzie cala linia identyczna

                    doc.Close();

                }
                System.Diagnostics.Process.Start(@"C:\Users\Tomek\Desktop\demo.pdf"); // wyswietlenie pliku podgladowego
                                                                                      //  potem bedzie go mozna zapisac lub nie
            }

        }
    }
}
