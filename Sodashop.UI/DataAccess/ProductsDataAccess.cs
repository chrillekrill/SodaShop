using Newtonsoft.Json;
using Sodashop.Datasource;
using Sodashop.DTO.DTOs;

namespace Sodashop.UI.DataAccess
{
    public class ProductsDataAccess : IProductDataAccess<ProductDTO>
    {
        private readonly SodashopDataSource _dataSource;
        public ProductsDataAccess(SodashopDataSource dataSource)
        {
            _dataSource = dataSource;
        }

        public List<ProductDTO> GetAll()
        {
            var jsonString = _dataSource.DataProviderProducts();

            var result = JsonConvert.DeserializeObject<List<ProductDTO>>(jsonString);

            return result;
        }

        public ProductDTO GetProductByID(int id)
        {
            var jsonString = _dataSource.DataProviderProducts();

            //var result = jsonString["products"].ToObject<List<ProductDTO>>();

            var result = GetAll();

            var productToAdd = result.Single(product => product.ID == id);

            return productToAdd;
        }
    }
}
