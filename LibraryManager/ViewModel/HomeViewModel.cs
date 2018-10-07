using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManager.ViewModel
{
    public class HomeViewModel
    {
        public int CustomersCount { get; set; }
        public int AuthorsCount { get; set; }
        public int BooksCount { get; set; }
        public int LentBooksCount { get; set; }
    }
}
