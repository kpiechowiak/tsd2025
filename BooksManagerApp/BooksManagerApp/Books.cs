using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;


namespace HomeLibrary
{
    public class Book
    {
        public int Id { get; private set; }

        private string title;
        public string Title
        {
            get => title;
            set
            {
                title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        private string author;
        public string Author
        {
            get => author;
            set
            {
                author = value;
                OnPropertyChanged(nameof(Author));
            }
        }

        private bool isRead;
        public bool IsRead
        {
            get => isRead;
            set
            {
                isRead = value;
                OnPropertyChanged(nameof(IsRead));
            }
        }

        private int year;
        public int Year
        {
            get => year;
            set
            {
                year = value;
                OnPropertyChanged(nameof(Year));
            }
        }

        private BookFormat format;
        public BookFormat Format
        {
            get => format;
            set
            {
                format = value;
                OnPropertyChanged(nameof(Format));
            }
        }

        public Book(int id)
        {
            Id = id;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public enum BookFormat
    {
        PaperBack, EBook
    }

    public static class MyBookCollection
    {
        public static List<Book> GetMyCollection()
        {
            return new List<Book>()
            {
                new Book(1){ Author = "J.K. Rowling", Format = BookFormat.EBook, IsRead = true, Title = "Harry Potter and the Philosopher's Stone", Year=1997},

                new Book(2)
                {
                    Author = "J.K. Rowling", Format = BookFormat.EBook, IsRead = true, Title = "Harry Potter and the Chamber of Secrets",
                    Year = 1998
                },

                new Book(3){ Author = "J.K. Rowling", Format = BookFormat.PaperBack, IsRead = true, Title = "Harry Potter and the Prisoner of Azkaban", Year = 1999},

                new Book(4){ Author = "Jonathan Swift", Format = BookFormat.PaperBack, IsRead = false, Title = "Travels into Several Remote Nations of the World. In Four Parts. By Lemuel Gulliver, First a Surgeon, and then a Captain of several Ships", Year=1972},

                new Book(5){Author = "Wayne Thomas Batson", Format = BookFormat.EBook, IsRead = true, Title = "Isle of Swords", Year = 2007},

                new Book(6){Author = "Louis A. Meyer", Format = BookFormat.EBook, IsRead = true, Title = "Under the Jolly Roger", Year = 2005},
                
            };

        }
    }
}
