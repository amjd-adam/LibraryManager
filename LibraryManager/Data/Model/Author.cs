using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManager.Data.Model
{
    public class Author
    {
        public int AuthorId { get; set; }
        [Required, MaxLength(30), MinLength(3)]
        public string Name { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
