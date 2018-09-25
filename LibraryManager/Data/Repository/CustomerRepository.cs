using LibraryManager.Data.Interfaces;
using LibraryManager.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManager.Data.Repository
{
    public class CustomerRepository:Repository<Customer>,ICustomerRepository
    {
        public CustomerRepository(LibraryDbContext context):base(context)
        {

        }
    }
}
