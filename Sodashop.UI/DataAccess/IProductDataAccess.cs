using Sodashop.DTO.DTOs;

namespace Sodashop.UI.DataAccess
{
    public interface IProductDataAccess<T> : IDataAccess<T>
    {
        ProductDTO GetProductByID(int id);
    }
}
