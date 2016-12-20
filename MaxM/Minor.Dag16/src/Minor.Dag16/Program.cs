using Minor.Dag16.DAL.Repositories;

namespace Minor.Dag16
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var pr = new ProductRepository();
            var product = new Products();
            product.ProductName = "Test";
            product.CategoryId = 12;
            pr.Insert(product);
        }
    }
}
