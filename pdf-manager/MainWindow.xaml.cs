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

using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;
using System.Drawing;
using System.Linq;

/// klasa wybranych pdfow do pracy
class files_info
{
    string path = "";
    int page; // strona gdzie znajduje sie wyszukany text
    int line; // linia gdzie znajduje sie wyszukany text
    string text; // wyszukany text

    public files_info(string path, int page, int line, string text)
    {
        this.path = path;
        this.page = page;
        this.line = line;
        this.text = text;
    }
    
    // nie wszedzie sa settery ( nie potrzebne aktualnie ) 
    public string Path { get => path; }
    public int Page { get => page; }
    public int Line { get => line; }
    public string Text { get => text; }
}



namespace pdf_manager
{
    public partial class MainWindow : Window
    {
        // lista dodanych plikow do pracy 
        List<string> filePaths = new List<string>();

        List<files_info> easySearchFilesInfo = new List<files_info>();

        List<int> easySearchAddedFiles = new List<int>();

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
            // sprawdzenie czy wybrane zostaly jakies pliki
            if (filePaths.Count != 0 && searching_word.Text != "" && searching_word.Text != "Enter Searching Text")
            {
                string szukana_fraza;
                int licznik = 1;

                // czy ignorowac wielkosc liter
                if (case_sensitivity.IsChecked == true)
                    szukana_fraza = searching_word.Text.ToLower();
                else
                    szukana_fraza = searching_word.Text;

                // przejscie po sciezkach plikow
                foreach (var path in filePaths)
                {
                    // sprawdzanie czy w kazdej linii znajduje sie poszukiwany fragment
                    PdfReader reader = new PdfReader(@path);
                    string[] words;
                    string line;

                    for (int i = 1; i <= reader.NumberOfPages; i++)
                    {
                        string text = PdfTextExtractor.GetTextFromPage(reader, i, new LocationTextExtractionStrategy());

                        words = text.Split('\n');
                        for (int x = 0, length = words.Length; x < length; x++)
                        {
                            line = Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(words[x]));

                            if (line.Contains(szukana_fraza))
                            {

                                results.Items.Add(licznik + ": Strona " + i + " Linia: " + (x + 1) + "\n" + line + "\n");

                                // dodawanie do struktury informacji o znalezionych liniach
                                easySearchFilesInfo.Add(new files_info(path, i, x, line));
                                licznik++;
                            }
                        }
                    }
                }
            }
        }

        // czyszczenie listy 
        private void clear_Click(object sender, RoutedEventArgs e)
        {
            results.Items.Clear();
            easySearchAddedFiles.Clear();
        }

        private class RectAndText
        {
            public iTextSharp.text.Rectangle Rect;
            public String Text;
            public RectAndText(iTextSharp.text.Rectangle rect, String text)
            {
                this.Rect = rect;
                this.Text = text;
            }
        }


        private class MyLocationTextExtractionStrategy : LocationTextExtractionStrategy
        {
            //Hold each coordinate
            public List<RectAndText> myPoints = new List<RectAndText>();

            //The string that we're searching for
            public String TextToSearchFor { get; set; }

            //How to compare strings
            public System.Globalization.CompareOptions CompareOptions { get; set; }

            public MyLocationTextExtractionStrategy(String textToSearchFor, System.Globalization.CompareOptions compareOptions = System.Globalization.CompareOptions.None)
            {
                this.TextToSearchFor = textToSearchFor;
                this.CompareOptions = compareOptions;
            }

            //Automatically called for each chunk of text in the PDF
            public override void RenderText(TextRenderInfo renderInfo)
            {
                base.RenderText(renderInfo);

                //See if the current chunk contains the text
                var startPosition = System.Globalization.CultureInfo.CurrentCulture.CompareInfo.IndexOf(renderInfo.GetText(), this.TextToSearchFor, this.CompareOptions);

                //If not found bail
                if (startPosition < 0)
                {
                    return;
                }

                //Grab the individual characters
                var chars = renderInfo.GetCharacterRenderInfos().Skip(startPosition).Take(this.TextToSearchFor.Length).ToList();

                //Grab the first and last character
                var firstChar = chars.First();
                var lastChar = chars.Last();


                //Get the bounding box for the chunk of text
                var bottomLeft = firstChar.GetDescentLine().GetStartPoint();
                var topRight = lastChar.GetAscentLine().GetEndPoint();

                //Create a rectangle from it
                var rect = new iTextSharp.text.Rectangle(
                                                        bottomLeft[iTextSharp.text.pdf.parser.Vector.I1],
                                                        bottomLeft[iTextSharp.text.pdf.parser.Vector.I2],
                                                        topRight[iTextSharp.text.pdf.parser.Vector.I1],
                                                        topRight[iTextSharp.text.pdf.parser.Vector.I2]
                                                        );

                //Add this to our main collection
                this.myPoints.Add(new RectAndText(rect, this.TextToSearchFor));
            }
        }

        private void highlightPDF()
        {
            //Create a new file from our test file with highlighting
            string highLightFile = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Highlighted.pdf");

            // Stream
            //Bind a reader and stamper to our test PDF

            var testFile = pathToSavePreview;

            PdfReader reader = new PdfReader(testFile);

            var numberOfPages = reader.NumberOfPages;
            System.Globalization.CompareOptions cmp = System.Globalization.CompareOptions.None;
            //Create an instance of our strategy


            FileStream fs = new FileStream(highLightFile, FileMode.Create);
            Document document = new Document(PageSize.A4);
            PdfWriter writer = PdfWriter.GetInstance(document, fs);

            using (PdfStamper stamper = new PdfStamper(reader, fs))
            {
                //document.Open();
                for (var currentPageIndex = 1; currentPageIndex <= numberOfPages; currentPageIndex++)
                {
                    MyLocationTextExtractionStrategy strategyTest = new MyLocationTextExtractionStrategy(searching_word.Text, cmp);
                    ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();

                    //Parse page 1 of the document above
                    using (var r = new PdfReader(testFile))
                    {
                        var ex = PdfTextExtractor.GetTextFromPage(r, currentPageIndex, strategyTest);
                    }

                    //Loop through each chunk found

                    foreach (var p in strategyTest.myPoints)
                    {

                        float[] quad = { p.Rect.Left, p.Rect.Bottom, p.Rect.Right, p.Rect.Bottom, p.Rect.Left, p.Rect.Top, p.Rect.Right, p.Rect.Top };

                        iTextSharp.text.Rectangle rect = new iTextSharp.text.Rectangle(p.Rect.Left,
                                                       p.Rect.Top,
                                                       p.Rect.Bottom,
                                                       p.Rect.Right);

                        iTextSharp.text.pdf.PdfAnnotation highlight = iTextSharp.text.pdf.PdfAnnotation.CreateMarkup(stamper.Writer, rect, null, iTextSharp.text.pdf.PdfAnnotation.MARKUP_HIGHLIGHT, quad);

                        //Set the color
                        highlight.Color = BaseColor.YELLOW;

                        //Add the annotation
                        stamper.AddAnnotation(highlight, 1);
                    }
                }
            }
        }

            /*
                    private void highlightPDF()
                    {
                        //Loads the document
                        PdfLoadedDocument document = new PdfLoadedDocument(pathToSavePreview);
                        //Gets the first page from the document
                        PdfLoadedPage page = document.Pages[0] as PdfLoadedPage;
                        //Add a list to maintain extracted text information
                        List<TextData> extractedText = new List<TextData>();
                        //Extract text from first page
                        page.ExtractText(out extractedText);

                        foreach (TextData textData in extractedText)
                        {
                            if (textData.Text == searching_word.Text)
                            {
                                //Add text markup annotation on the bounds of highlighting text
                                PdfTextMarkupAnnotation textmarkup = new PdfTextMarkupAnnotation(textData.Bounds);
                                //Sets the markup annotation type as HighLight
                                textmarkup.TextMarkupAnnotationType = PdfTextMarkupAnnotationType.Highlight;
                                //Sets the content of the annotation
                                textmarkup.Text = "Highlight Text";
                                //Sets the highlighting color
                                textmarkup.TextMarkupColor = new PdfColor(Color.LightPink);
                                //Add annotation into page
                                page.Annotations.Add(textmarkup);
                            }
                        }
                        //Save and close the document
                        document.Save(pathToSavePreview);
                        document.Close(true);
                    }       
             */

            private void previewFunction(object sender, RoutedEventArgs e)
        {
            // jesli nie ma zadnego wybranego pliku to nic nie robi
            if (results.SelectedItems.Count == 0)
                return;

            // Tworzenie nowego pliku pdf 
            FileStream stream = new FileStream(pathToSavePreview, FileMode.Create, FileAccess.Write, FileShare.None);
            Document doc = new Document();
            PdfCopy nowy_pdf = new PdfCopy(doc, stream);
            doc.Open();

            // przejscie po zaznaczonych checkboxach
            for (int x = 0; x < results.SelectedItems.Count; x++)
            {
                // wyluskanie numeru linii z ListBox'a 
                string number = results.SelectedItems[x].ToString();
                number = number.Substring(0, number.IndexOf(":"));

                // w strukturze indeksuje sie od 0 dlatego - 1
                int listBoxLineNumber = Int32.Parse(number) - 1;
                bool czyStrona = false;

                // iteracja po dodanych plikach i sprawdzenie czy ktoras ze stron nie zostal juz dodana ( ta sama sciezka i strona ) 
                for (int i = 0; i < easySearchAddedFiles.Count; i++)
                {
                    if (easySearchFilesInfo[listBoxLineNumber].Path == easySearchFilesInfo[easySearchAddedFiles[i]].Path)
                    {
                        if (easySearchFilesInfo[listBoxLineNumber].Page == easySearchFilesInfo[easySearchAddedFiles[i]].Page)
                        {
                            czyStrona = true;
                            break;
                        }
                    }
                }

                string path = easySearchFilesInfo[listBoxLineNumber].Path;
                if (czyStrona == false)
                {
                    // kopiowanie do nowo utworzonego pdfa strony
                    using (PdfReader kopiowany_pdf = new PdfReader(path))
                    {
                        PdfImportedPage importedPage = nowy_pdf.GetImportedPage(kopiowany_pdf, easySearchFilesInfo[listBoxLineNumber].Page);
                        nowy_pdf.AddPage(importedPage);
                    }

                    // wpisanie do listy dodanych linii z ListBoxa 
                    easySearchAddedFiles.Add(listBoxLineNumber);
                }
            }
            
            System.Windows.Controls.Button btnSender = (System.Windows.Controls.Button)sender;

            // sprawdzenie czy "Search" wywoluje bo tam jest podglad | wyswietlenie podgladowego pdfa w przegladarce
            if ( btnSender == preview)
                System.Diagnostics.Process.Start(@pathToSavePreview);

            // wyczyszczenie listy, bo wylowanie funkcji jest w dwoch miejscach i zamkniecie dokumentu
            easySearchAddedFiles.Clear();
            doc.Close();
        }


        // wyswietlenie jak bedzie wygladac finalny pdf 
        private void preview_Click(object sender, RoutedEventArgs e)
        {
            previewFunction(sender, null);
            highlightPDF();
        }
           
      private void Button_Click_1(object sender, RoutedEventArgs e)
      {

      }

         private void savePreview_Click(object sender, RoutedEventArgs e)
        {     
            // jesli nie ma zadnego wybranego pliku to nic nie robi
            if (results.SelectedItems.Count == 0)
                 return;

            // stworzenie preview jesli ktos by nie chcial go korzystac z opcji "preview"
            previewFunction(sender, null);

            // okno dialogowe do wybrania folderu zapisu 
            var folderBrowserDialog1 = new FolderBrowserDialog();
            DialogResult result = folderBrowserDialog1.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                // sciezka do zapisu pdfa
                string pathToSaveCompleted;
                if ( userPath.Text == "Insert Path" || userPath.Text == "" )
                {
                    userPath.Text = "Insert File Name";
                    userPath.Background = System.Windows.Media.Brushes.Red;
                    return;
                }
                pathToSaveCompleted = System.IO.Path.Combine(folderBrowserDialog1.SelectedPath, userPath.Text + ".pdf");
               
                if( File.Exists(pathToSaveCompleted) )
                {
                    userPath.Text = "File Exists";
                    userPath.Background = System.Windows.Media.Brushes.Red;
                    return;
                }

                if ( File.Exists(pathToSavePreview) )
                {
                    // sprawdzenie czy ktos chce miec ustawione haslo 
                    if (passwordChecked.IsChecked == true )
                    {
                        // sprawdzenie czy pole z haslem nie jest puste 
                        if( password.Text == "Insert Password" || password.Text == "" )
                        {
                            password.Text = "Insert Password";
                            password.Background = System.Windows.Media.Brushes.Red;
                            return;
                        }
                        // utworzenie kopii pliku w nowej lokalizacji z haslem - inaczej sie nie da w itext
                        using (Stream output = new FileStream(pathToSaveCompleted, FileMode.Create, FileAccess.Write, FileShare.None))
                        {
                            PdfReader reader = new PdfReader(pathToSavePreview);
                            string Password = password.Text;
                            PdfEncryptor.Encrypt(reader, output, true, Password, Password, PdfWriter.ALLOW_PRINTING);
                        }
                    }
                    else
                    {
                        // bez hasla mozna tylko przeniesc plik 
                        File.Move(pathToSavePreview, pathToSaveCompleted);
                    }
                }
            }
        }


        // podczas zamykania aplikacji usuwamy plik preview.pdf
        private void Window_Closed(object sender, EventArgs e)
        {
            if (File.Exists(pathToSavePreview))
                File.Delete(pathToSavePreview);
        }

        // po kliknieciu w texboxa znika tekst 
        private void password_GotFocus(object sender, RoutedEventArgs e)
        {
            password.Text = "";
            password.Background = System.Windows.Media.Brushes.White;
        }

        // po kliknieciu w texboxa znika tekst i zmienia sie kolor na standardowy jesli nazwa pliku istaniala 
        private void userPath_GotFocus(object sender, RoutedEventArgs e)
        {
            userPath.Text = "";
            userPath.Background = System.Windows.Media.Brushes.White;
        }

        private void searching_word_GotFocus(object sender, RoutedEventArgs e)
        {
            searching_word.Text = "";
        }
    }
}

/* Podkreslanie tekstu - nowy framework platny ( ograniczony ) 
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