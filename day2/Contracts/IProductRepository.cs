
namespace day2.Contracts
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAll();
        Task<Product?> GetById(int id);
        Task<Product> Create(Product p);
        Task<bool> Update(Product p);

        Task<bool> DeleteById(int id);
    }
}
