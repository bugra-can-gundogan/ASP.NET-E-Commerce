using System.Collections.Generic;
using bugraGundoganASP.entity;

namespace bugraGundoganASP.data.Abstract
{
    public interface IProductRepository : IRepository<Product>
    {
        Product GetProductDetails(string url);
        Product GetByIdWithCategories(int id);
        List<Product> GetProductsByCategory(string name, int page, int pageSize);
        List<Product> GetSearchResult(string search);

        List<Product> GetHomePageProducts();
        int GetCountByCategory(string category);

        void Update(Product entity, int[] categoryIds);
    }
}