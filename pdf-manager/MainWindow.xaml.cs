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
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;

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

        private void open_pdf_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(@"C:\Users\Tomek\Desktop\test.pdf");
        }
    }
}
