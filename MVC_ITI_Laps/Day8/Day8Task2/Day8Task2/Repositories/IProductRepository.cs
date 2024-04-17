using Day8Task2.Models;

namespace Day8Task2.Repositories
{
    public interface IProductRepository
    {
        public List<Product> GetAll();
        public Product GetDetails(int id);
        public void Insert(Product prod);
        public void Update(int id, Product prod);
        public void Delete(int id);
    }
}
