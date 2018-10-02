using LibraryManager.Data.Interfaces;
using LibraryManager.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManager.Controllers
{
    public class LendController:Controller
    {
        readonly IBookRepository _bookRepository;
        readonly ICustomerRepository _customerRepository;

        public LendController(IBookRepository bookRepository,ICustomerRepository customerRepository)
        {
            _bookRepository = bookRepository;
            _customerRepository = customerRepository;
        }

        [Route("Lend")]
        public IActionResult List()
        {
            var books = _bookRepository.FindWithAuthor(b=>b.BorrowerId==0);
            if (books.Count() == 0)
                return View("Empty");
            else
                return View(books);
        }

        public IActionResult LendBook(int Id)
        {
            var book = _bookRepository.GetById(Id);
            var lendVM = new LendViewModel
            {
                Book = book,
                Customers = _customerRepository.GetAll()
            };
            return View(lendVM);
        }

        [HttpPost]
        public IActionResult LendBook(LendViewModel lendVM)
        {
            var book = lendVM.Book;
            book.Borrower = _customerRepository.GetById(lendVM.Book.BorrowerId);
            _bookRepository.Update(book);
            return RedirectToAction("List");
        }
    }
}
