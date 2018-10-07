using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LibraryManager.Models;
using LibraryManager.Data.Interfaces;
using LibraryManager.ViewModel;

namespace LibraryManager.Controllers
{
    public class HomeController : Controller
    {
      readonly   IBookRepository _bookRepository;
      readonly  ICustomerRepository _customerRepository;
      readonly  IAuthorRepository _authorRepository;

        public HomeController(IBookRepository bookRepository,ICustomerRepository customerRepository, IAuthorRepository authorRepository)
        {
            _bookRepository = bookRepository;
            _customerRepository = customerRepository;
            _authorRepository = authorRepository;
        }
     

        public IActionResult Index()
        {
            var homeVM = new HomeViewModel
            {
                BooksCount = _bookRepository.Count(b => true),
                AuthorsCount=_authorRepository.Count(a=>true),
                 CustomersCount=_customerRepository.Count(c=>true),
                  LentBooksCount=_bookRepository.Count(b=>b.BorrowerId>0)
            };
            return View(homeVM);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
