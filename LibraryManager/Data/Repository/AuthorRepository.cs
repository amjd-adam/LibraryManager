using LibraryManager.Data.Interfaces;
using LibraryManager.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManager.Data.Repository
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        public AuthorRepository(LibraryDbContext context):base(context)
        {

        }
        public IEnumerable<Author> GetAllWithBooks() => _context.Authors.Include(a=>a.Books);

        public Author GetWithBook(int id) => _context.Authors.Where(a => a.AuthorId == id).Include(a => a.Books).FirstOrDefault();
       
    }
}
