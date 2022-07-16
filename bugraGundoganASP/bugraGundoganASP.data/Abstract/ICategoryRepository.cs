using System.Collections.Generic;
using bugraGundoganASP.entity;

namespace bugraGundoganASP.data.Abstract
{
    public interface ICategoryRepository: IRepository<Category>
    {
        Category GetByIdWithProducts(int categoryId);

        void DeleteFromCategory(int productId, int categoryId);
    }
}