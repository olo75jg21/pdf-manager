using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System;

/// iTextSharp
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System.Linq;
using System.Collections.Specialized;

/// Spire 
using Spire.Pdf;
using Spire.Pdf.General.Find;
using System.Collections.ObjectModel;

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
        List<files_info> easySearchFilesInfo = new List<files_info>();

        List<int> easySearchAddedFiles = new List<int>();

        string pathToSavePreview = System.IO.Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "preview.pdf");

        List<files_info> pliki = new List<files_info>();

        // DirrectoryTree elements Collection
        public ObservableCollection<Object> RootDirectoryItems { get; } = new ObservableCollection<object>();

        // List of paths to selected files 
        public ObservableCollection<String> selectedFilesPath = new ObservableCollection<String>();
        public MainWindow()
        {
            InitializeComponent();
            // Connecting XAML view with the data
            SelectedItemsList.ItemsSource = selectedFilesPath;
            DirectoryTreeView.ItemsSource = RootDirectoryItems;

            // Loading selectedFilePaths from last session
            LoadSession();
        }
        private void LoadSession()
        {
            if (Properties.Settings.Default.filePaths != null)
            {
                foreach (String file in Properties.Settings.Default.filePaths.Cast<String>().ToList())
                    selectedFilesPath.Add(file);
            }
        }
        private void SaveSettingsButton_Click(object sender, RoutedEventArgs e)
        {
            StringCollection filePathsCollection = new StringCollection();
            filePathsCollection.AddRange(selectedFilesPath.ToArray());
            Properties.Settings.Default.filePaths = filePathsCollection; Properties.Settings.Default.Save();
        }

        // przycisk pod drzewkiem, dodajacy wybrane pliki
        private void ButtonAddSelectedTreeItems_Click(object sender, RoutedEventArgs e)
        {
            ItFile file = DirectoryTreeView.SelectedItem as ItFile;
            if (file != null)
            {
                if (!selectedFilesPath.Contains(file.FilePath))
                {
                    selectedFilesPath.Add(file.FilePath);
                }
            }
        }

        private void ButtonRemoveSelectedTreeItems_Click(object sender, RoutedEventArgs e)
        {
            String file = SelectedItemsList.SelectedItem as String;
            if (file != null)
            {
                if (selectedFilesPath.Contains(file))
                {
                    selectedFilesPath.Remove(file);
                }
            }
        }

        // przycisk nad drzewkiem katalogu, umozliwiajacy dodanie nowego katalogu
        private void ButtonAddDirectory_Click(object sender, RoutedEventArgs e)
        {
            string selectedPath = TreeComponents.OpenDirectoryDialog();

            if (selectedPath != null)
                RootDirectoryItems.Add(new ItDirectory(selectedPath));
        }

        private void ButtonRemoveDirectory_Click(object sender, RoutedEventArgs e)
        {
            var directory = DirectoryTreeView.SelectedItem as ItDirectory;

            if (directory != null)
            {
                Console.WriteLine(directory.ToString());
                RootDirectoryItems.Remove(directory);
            }
        }

        // Merges selected files
        private void mergeButton_Click(object sender, RoutedEventArgs e)
        {
            // Need to connect list with selected items
            SaveMergedFile(selectedFilesPath.ToList());
        }

        // Merges all files
        private void mergeAllButton_Click(object sender, RoutedEventArgs e)
        {
            SaveMergedFile(selectedFilesPath.ToList());
        }

        private void SaveMergedFile(List<string> sourceList)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string mergePath = saveFileDialog.FileName;
                CombineMultiplePDFs(sourceList, mergePath + ".pdf");
            }
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

        private void button_Click(object sender, RoutedEventArgs e)
        {
            // sprawdzenie czy wybrane zostaly jakies pliki
            if (selectedFilesPath.Count != 0 && searching_word.Text != "" && searching_word.Text != "Enter Searching Text")
            {
                string szukana_fraza;
                int licznik = 1;

                // czy ignorowac wielkosc liter
                if (case_sensitivity.IsChecked == true)
                    szukana_fraza = searching_word.Text.ToLower();
                else
                    szukana_fraza = searching_word.Text;

                // przejscie po sciezkach plikow
                foreach (var path in selectedFilesPath)
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
            if (btnSender == preview1)
                System.Diagnostics.Process.Start(@pathToSavePreview);

            // wyczyszczenie listy, bo wylowanie funkcji jest w dwoch miejscach i zamkniecie dokumentu
            easySearchAddedFiles.Clear();
            doc.Close();
        }


        // wyswietlenie jak bedzie wygladac finalny pdf 
        private void preview_Click(object sender, RoutedEventArgs e)
        {
            previewFunction(sender, null);
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
                if (userPath.Text == "Insert Path" || userPath.Text == "")
                {
                    userPath.Text = "Insert File Name";
                    userPath.Background = System.Windows.Media.Brushes.Red;
                    return;
                }
                pathToSaveCompleted = System.IO.Path.Combine(folderBrowserDialog1.SelectedPath, userPath.Text + ".pdf");

                if (File.Exists(pathToSaveCompleted))
                {
                    userPath.Text = "File Exists";
                    userPath.Background = System.Windows.Media.Brushes.Red;
                    return;
                }

                if (File.Exists(pathToSavePreview))
                {
                    // sprawdzenie czy ktos chce miec ustawione haslo 
                    if (passwordChecked.IsChecked == true)
                    {
                        // sprawdzenie czy pole z haslem nie jest puste 
                        if (password.Text == "Insert Password" || password.Text == "")
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

