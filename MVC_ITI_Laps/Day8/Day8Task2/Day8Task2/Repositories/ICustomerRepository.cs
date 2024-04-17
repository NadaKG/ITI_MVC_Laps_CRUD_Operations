using Day8Task2.Models;

namespace Day8Task2.Repositories
{
    public interface ICustomerRepository
    {
        public List<Customer> GetAll();
        public Customer GetDetails(int id);
        public void Insert(Customer cus);
        public void Update(int id, Customer cus);
        public void Delete(int id);
    }
}
