using LibraryManager.Data.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManager.Data
{
    public static class DbInitializer
    {
        public static void Seed(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<LibraryDbContext>();

                var justin = new Customer { Name = "Justin Ventura" };
                var eden = new Customer { Name = "Eden Hazard" };
                var frnk = new Customer { Name = "Frank Lampard" };

                context.Customers.Add(justin);
                context.Customers.Add(eden);
                context.Customers.Add(frnk);


                var phil = new Author
                {
                    Name = "Dr Phil",
                    Books = new List<Book>
                     {
                         new Book{ Title="Alien Vs Predator"},
                         new Book{ Title="Anger Management"}
                     }
                };

                var mat = new Author
                {
                    Name = "Matt Graening",
                    Books = new List<Book>
                     {
                         new Book{ Title="Bart's Life Guide"},
                         new Book{ Title="Homer Wisdom"}
                     }

                };

                context.Authors.Add(phil);
                context.Authors.Add(mat);

                context.SaveChanges();
            }
        }
    }
}
