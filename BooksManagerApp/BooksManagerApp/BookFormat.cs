using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeLibrary;


namespace BooksManagerApp
{
    public static class BookFormatValue
    {
        public static IEnumerable<HomeLibrary.BookFormat> All { get; } =
            (HomeLibrary.BookFormat[])Enum.GetValues(typeof(HomeLibrary.BookFormat));
    }
}