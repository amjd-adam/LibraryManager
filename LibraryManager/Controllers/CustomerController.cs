using LibraryManager.Data.Interfaces;
using LibraryManager.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManager.Controllers
{
    public class CustomerController:Controller
    {
        readonly ICustomerRepository _customerRepository;
        readonly IBookRepository _bookRepository;

        public CustomerController(ICustomerRepository customerRepository,IBookRepository bookRepository)
        {
            _customerRepository = customerRepository;
            _bookRepository = bookRepository;
        }

        public IActionResult List()
        {
            var customerVM = new List<CustomerViewModel>();
            var customers=_customerRepository.GetAll();
            if(customers.Count()==0)
            {
                return View("Empty");
            }
            else
            {
                var x = from c in customers
                        select new CustomerViewModel
                        {
                            Customer = c,
                            BookCount = _bookRepository.Count(b => b.BorrowerId == c.CustomerId)
                        };
                customerVM = x.ToList();
                return View(customerVM);
            }
        }
    }
}
