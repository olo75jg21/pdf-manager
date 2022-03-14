using System.IO;
using System.Text;
using System.Windows;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using Xceed.Wpf.Toolkit;

class files_info
{
    string sciezka;
    int strona;
    int linia;
}

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
                        }
                        j++;
                    }
                }
            }
        }

        private void preview_Click(object sender, RoutedEventArgs e)
        {
            FileStream fs = new FileStream("demo.pdf", FileMode.Create, FileAccess.Write, FileShare.None);
            Document doc = new Document();
            PdfWriter writer = PdfWriter.GetInstance(doc, fs);
            doc.Open();

            if (results.SelectedItems.Count != 0)
            {
                for (int x = 0; x < results.SelectedItems.Count; x++)
                {
                     results.SelectedItems[x].ToString() + "\n";
                }
                
            }

            ///System.Diagnostics.Process.Start(@"C:\Users\Tomek\Desktop\test.pdf");
        }
    }
}
