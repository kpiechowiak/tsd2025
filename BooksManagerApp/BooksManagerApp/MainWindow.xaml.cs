using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using HomeLibrary;


namespace BooksManagerApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            BooksListBox.ItemsSource = MyBookCollection.GetMyCollection();
            BooksListBox.SelectionChanged += BooksListBox_SelectionChanged;
            DetailsPanel.DeleteRequested += DetailsPanel_DeleteRequested;
        }

        private void BooksListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (BooksListBox.SelectedItem is Book selectedBook)
            {
                DetailsPanel.DataContext = selectedBook;
            }
        }

        private void AddBook_Click(object sender, RoutedEventArgs e)
        {
            var books = BooksListBox.ItemsSource as List<Book>;
            var newBook = new Book(GenerateNewId())
            {
                Title = "New Book",
                Author = "",
                Year = DateTime.Now.Year,
                IsRead = false,
                Format = BookFormat.PaperBack
            };
            books.Add(newBook);

            BooksListBox.ItemsSource = null;
            BooksListBox.ItemsSource = books;
            BooksListBox.SelectedItem = newBook;
        }

        private int GenerateNewId()
        {
            var books = BooksListBox.ItemsSource as List<Book>;
            return books.Any() ? books.Max(b => b.Id) + 1 : 1;
        }

        private void DetailsPanel_DeleteRequested(object sender, RoutedEventArgs e)
        {
            var selectedBook = BooksListBox.SelectedItem as Book;
            if (selectedBook != null)
            {
                var books = BooksListBox.ItemsSource as List<Book>;
                books.Remove(selectedBook);
                BooksListBox.ItemsSource = null;
                BooksListBox.ItemsSource = books;
                DetailsPanel.DataContext = null;
            }
        }
    }
}
