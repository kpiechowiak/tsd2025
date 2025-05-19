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


namespace BooksManagerApp
{
    public partial class BookDetailsControl : UserControl
    {
        public static readonly RoutedEvent DeleteRequestedEvent =
            EventManager.RegisterRoutedEvent("DeleteRequested", RoutingStrategy.Bubble,
                typeof(RoutedEventHandler), typeof(BookDetailsControl));

        public event RoutedEventHandler DeleteRequested
        {
            add { AddHandler(DeleteRequestedEvent, value); }
            remove { RemoveHandler(DeleteRequestedEvent, value); }
        }

        public BookDetailsControl()
        {
            InitializeComponent();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to delete this book?", "Confirm", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                RaiseEvent(new RoutedEventArgs(DeleteRequestedEvent));
            }
        }
    }
}