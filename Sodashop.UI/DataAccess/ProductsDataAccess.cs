using Sodashop.Datasource;
using Sodashop.UI.DTOs;

namespace Sodashop.UI.DataAccess
{
    public class ProductsDataAccess : IDataAccess<ProductDTO>
    {
        private readonly SodashopDataSource _dataSource;
        public ProductsDataAccess(SodashopDataSource dataSource)
        {
            _dataSource = dataSource;
        }

        public List<ProductDTO> GetAll()
        {
            var jsonString = _dataSource.DataProvider();

            //var results =  JsonConvert.DeserializeObject<List<UserDTO>>(jsonString);

            var result = jsonString["products"].ToObject<List<ProductDTO>>();

            return result;
        }
    }
}
