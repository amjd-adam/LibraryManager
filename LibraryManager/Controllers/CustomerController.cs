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
    public class CustomerController:Controller
    {
        readonly ICustomerRepository _customerRepository;
        readonly IBookRepository _bookRepository;

        public CustomerController(ICustomerRepository customerRepository,IBookRepository bookRepository)
        {
            _customerRepository = customerRepository;
            _bookRepository = bookRepository;
        }

        [Route("Customer")]
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

        public IActionResult Delete(int id)
        {
            var customer = _customerRepository.GetById(id);
            _customerRepository.Delete(customer);
            return RedirectToAction("List");
        }

        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            _customerRepository.Create(customer);
            return RedirectToAction("List");
        }

        public IActionResult Update(int id)
        {
            var customer = _customerRepository.GetById(id);
            return View(customer);
        }

        [HttpPost]
        public IActionResult Update(Customer customer)
        {
            _customerRepository.Update(customer);
            return RedirectToAction("List");
              
        }
    }
}
