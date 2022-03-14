using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using Xceed.Wpf.Toolkit;

class files_info
{
    string sciezka = "";
    int strona;
    int linia;
    string linijka;

    public files_info(string sciezka, int strona, int linia, string linijka)
    {
        this.sciezka = sciezka;
        this.strona = strona;
        this.linia = linia;
        this.linijka = linijka;
    }
    public string Sciezka { get => sciezka; }
    public int Strona { get => strona; set => strona = value; }
    public int Linia { get => linia; }
    public string Linijka { get => linijka; }
}



namespace pdf_manager
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
   {
        List<files_info> pliki = new List<files_info>();

        public MainWindow()
      {
            InitializeComponent();
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

           /// Sprawdzenie czy jakis checkbox zostal zaznaczony 
            if (results.SelectedItems.Count != 0)
            {
                /// Petla po wybranych checkboxach 
                for (int x = 0; x < results.SelectedItems.Count; x++)
                {
                    /// Sprawdzenie czy juz nie ma wybranego tekstu w nowo stworzonym pdfie
                    bool czyStrona = false;
                    for (int i = 0; i < x; i++)
                    {
                        /// sprawdzenie czy uzyte byly te same pliki
                        if (pliki[i].Sciezka == pliki[i].Sciezka)
                        {
                            /// sprawdzenie czy dodane zostaly te same linie do pliku
                            if (pliki[i].Strona == pliki[x].Strona)
                            {
                                czyStrona = true;
                                break;
                            }
                        }
                    }

                    /// jesli plik nie zostal dodany w takim wypadku go dodajemy 
                    if(czyStrona == false)
                    {
                        string path = "file:///C:/Users/Tomek/Desktop/test.pdf";

                        using (PdfReader kopiowany_pdf = new PdfReader(path))
                        {
                            PdfImportedPage importedPage = nowy_pdf.GetImportedPage(kopiowany_pdf, pliki[x].Strona);
                            nowy_pdf.AddPage( importedPage );
                        }
                    }

                    /// podekreslenie tekstu w nowym pliku



                   


                }
                
            }

            ///System.Diagnostics.Process.Start(@"C:\Users\Tomek\Desktop\test.pdf");
        }
    }
}
