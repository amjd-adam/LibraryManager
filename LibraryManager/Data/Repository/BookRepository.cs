using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManager.Data.Interfaces;
using LibraryManager.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager.Data.Repository
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(LibraryDbContext context):base(context)
        {

        }
        public IEnumerable<Book> FindWithAuthor(Func<Book, bool> predicate) => _context.Books.Include(b=>b.Author).Where(predicate);


        public IEnumerable<Book> FindWithAuthorAndBorrower(Func<Book, bool> predicate) => _context.Books.Include(b => b.Author).Include(b => b.Borrower).Where(predicate);
       

        public IEnumerable<Book> GetAllWithAuthor() => _context.Books.Include(b=>b.Author);
    }
}
