using LibraryManager.Data.Interfaces;
using LibraryManager.Data.Model;
using LibraryManager.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManager.Controllers
{
    public class AuthorController:Controller 
    {
        IAuthorRepository _auhtorRepository;

        public AuthorController(IAuthorRepository authorRepository)
        {
            _auhtorRepository = authorRepository;
        }

        [Route("Author")]
        public IActionResult List()
        {
            var authors = _auhtorRepository.GetAllWithBooks();
            if(authors.Count()==0)
            {
                return View("Empty");
            }
            else
            {
                return View(authors);
            }
        }

        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Author author)
        {
            _auhtorRepository.Create(author);
            return RedirectToAction("List");
        }

        public IActionResult Delete(int id)
        {
            var author = _auhtorRepository.GetById(id);
            _auhtorRepository.Delete(author);
            return RedirectToAction("List");
        }

        public IActionResult Update(int id) => View(_auhtorRepository.GetById(id));

        [HttpPost]
        public IActionResult Update(Author author)
        {
            _auhtorRepository.Update(author);
            return RedirectToAction("List");
        }


    }
}
