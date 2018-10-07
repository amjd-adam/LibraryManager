using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManager.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManager.Controllers
{
    public class ReturnController : Controller
    {

       readonly IBookRepository _bookRepository;
      
        public ReturnController(IBookRepository bookRepository,ICustomerRepository customerRepository)
        {
            _bookRepository = bookRepository;         
        }
        public IActionResult List()
        {
            var books = _bookRepository.FindWithAuthorAndBorrower(b => b.BorrowerId != 0);
            if(books!=null && books.Count()>0)
            {
                return View(books);
            }
            else
            return View("Empty");
        }

        public IActionResult ReturnBook(int id)
        {
            var book = _bookRepository.GetById(id);            
            book.BorrowerId = 0;
            book.Borrower = null;
            _bookRepository.Update(book);            
            return RedirectToAction("List");
        }
    }
}