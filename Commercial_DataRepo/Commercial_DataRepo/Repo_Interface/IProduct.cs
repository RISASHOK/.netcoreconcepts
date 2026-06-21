using Commercial_DataRepo.Repo_Models;

namespace Commercial_DataRepo.Repo_Interface
{
    public interface IProduct
    {
        List<Product> GetAllProducts();
        int InsertNewProduct(Product product);
        Product GetProductById(int pid);
        int DeleteProduct(int pid);
    }
}
