

namespace day2.Services;

public class ProductRepositoryMock : IProductRepository
{
    List<Product> products = new List<Product>{
        new Product{ id =1, name="Apple" , price=10 },
        new Product{ id = 2 , name = "Bread" , price=5.4 } };

    public Task<Product> Create(Product p)
    {
        int id = products.Max(p => p.id) + 1;
        var newP = p with { id = id };
        products.Add(newP);

        return Task.FromResult(newP);
    }

    public Task<bool> DeleteById(int id)
    {
        var p = products.FirstOrDefault(p => p.id == id);
        if (p == null)
        {
            return Task.FromResult(false);
        }

        products.Remove(p);
        return Task.FromResult(true);

    }

    public Task<List<Product>> GetAll()
    {
        return Task.FromResult(products);
    }

    public Task<Product?> GetById(int id)
    {
        return Task.FromResult(products.Where(p => p.id == id).FirstOrDefault());
    }

    public Task<bool> Update(Product productToUpdate)
    {
        var productToRemove = products.FirstOrDefault(p => p.id == productToUpdate.id);
        if(productToRemove == null)
        {
            return Task.FromResult(false);
        }

        products.Remove(productToRemove);
        products.Add(productToUpdate);
        return Task.FromResult(true);

    }
}
