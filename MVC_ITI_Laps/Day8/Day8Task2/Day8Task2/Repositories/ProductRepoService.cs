using Day8Task2.Models;

namespace Day8Task2.Repositories
{
    public class ProductRepoService : IProductRepository
    {
        public CPContext Context { get; set; }
        public ProductRepoService(CPContext context)
        {
            Context = context;
        }

        public List<Product> GetAll()
        {
            return Context.Products.ToList();
        }

        public Product GetDetails(int id)
        {
            return Context.Products.Find(id);
        }

        public void Insert(Product product)
        {
            if (product != null)
            {
                Context.Products.Add(product);
                Context.SaveChanges();
            }
        }

        public void Update(int id, Product product)
        {
            Product updatedproduct = Context.Products.Find(id);
            if (updatedproduct != null)
            {
                updatedproduct.Description = product.Description;
                updatedproduct.Name = product.Name;
                updatedproduct.Image = product.Image;
                updatedproduct.Price = product.Price;
                updatedproduct.CustId = product.CustId;
                Context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            Product product = Context.Products.Find(id);
            if (product != null)
            {
                Context.Products.Remove(product);
                Context.SaveChanges();
            }
        }
    }
}
