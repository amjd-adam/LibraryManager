using LibraryManager.Data.Interfaces;
using LibraryManager.Data.Model;
using LibraryManager.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManager.Controllers
{
    public class BookController:Controller
    {
        readonly IBookRepository _bookRepository;
        readonly IAuthorRepository _authorRepository;

        public BookController(IBookRepository bookRepository,IAuthorRepository authorRepository)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
        }

        [Route("Book")]
        public IActionResult List(int? authorId,int? borrowerId)
        {
            IEnumerable<Book> books;
            if (!authorId.HasValue && !borrowerId.HasValue)
                books = _bookRepository.GetAllWithAuthor();
            else if (authorId.HasValue && !borrowerId.HasValue)
                books = _bookRepository.FindWithAuthor(b => b.AuthorId == authorId.Value);
            else if (!authorId.HasValue && borrowerId.HasValue)
                books = _bookRepository.FindWithAuthorAndBorrower(b => b.BorrowerId == borrowerId.Value);
            else
                books = _bookRepository.FindWithAuthorAndBorrower(b => b.BorrowerId == borrowerId.Value && b.AuthorId == authorId.Value);
            if (books.Count() == 0)
                return View("Empty");
            else
            {
                return View(books);
            }
        }

        public IActionResult Create()
        {
            var bookVM = new BookViewModel
            {
                Authors = _authorRepository.GetAll()
            };
            return View(bookVM);
        }

        [HttpPost]
        public IActionResult Create(BookViewModel bookVM)
        {
            if (!ModelState.IsValid)
            {
                bookVM.Authors = _authorRepository.GetAll();
                return View(bookVM);
            }
            _bookRepository.Create(bookVM.Book);
            return RedirectToAction("List");
        }

        public IActionResult Delete(int id)
        {
            var book = _bookRepository.GetById(id);
            _bookRepository.Delete(book);
            return RedirectToAction("List");
        }

        public IActionResult Update(int id)
        {
            var bookVM = new BookViewModel
            {
                Authors = _authorRepository.GetAll(),
                Book = _bookRepository.GetById(id)
            };
           return View(bookVM);
        }

        [HttpPost]
        public IActionResult Update(BookViewModel bookVM)
        {
            if (!ModelState.IsValid)
            {
                bookVM.Authors = _authorRepository.GetAll();
                return View(bookVM);
            }
                _bookRepository.Update(bookVM.Book);
            return RedirectToAction("List");
        }
    }
}
