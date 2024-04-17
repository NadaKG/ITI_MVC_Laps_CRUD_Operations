using Day8Task2.Models;
using Microsoft.EntityFrameworkCore;

namespace Day8Task2.Repositories
{
    public class CustomerRepoService : ICustomerRepository
    {
        public CPContext Context { get; set; }
        public CustomerRepoService(CPContext context)
        {
            Context = context;
        }

        public List<Customer> GetAll()
        {
            return Context.Customers.Include(p=>p.Products).ToList();
        }

        public Customer GetDetails(int id)
        {
            return Context.Customers.Include(p=>p.Products).FirstOrDefault(i => i.CustomerId == id);
        }

        public void Insert(Customer customer)
        {
            if (customer != null)
            {
                Context.Customers.Add(customer);
                Context.SaveChanges();
            }
        }

        public void Update(int id, Customer customer)
        {
            Customer customerToUpdate = Context.Customers.Include(t => t.Products).FirstOrDefault(t => t.CustomerId == id);

            if (customerToUpdate != null)
            {

                customerToUpdate.Name = customer.Name;
                customerToUpdate.Email = customer.Email;
                customerToUpdate.gender = customer.gender;
                customerToUpdate.PhoneNumber = customer.PhoneNumber;
                Context.SaveChanges();
            }
        }


        public void Delete(int id)
        {
            Customer customerToDelete = Context.Customers.Find(id);
            if (customerToDelete != null)
            {
                Context.Customers.Remove(customerToDelete);
                Context.SaveChanges();
            }
        }
    }
}
