using LibraryManager.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManager.Data.Interfaces
{
    public interface IAuthorRepository:IRepository<Author>
    {
        IEnumerable<Author> GetAllWithBooks();

        Author GetWithBook(int id);
    }
}
