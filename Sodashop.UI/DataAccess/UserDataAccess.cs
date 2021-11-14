using Sodashop.UI.DTOs;
using Sodashop.Datasource;
using Newtonsoft.Json;

namespace Sodashop.UI.DataAccess
{
    public class UserDataAccess : IDataAccess<UserDTO>
    {

        private readonly SodashopDataSource _dataSource;
        public UserDataAccess(SodashopDataSource dataSource)
        {
            _dataSource = dataSource;
        }

        public List<UserDTO> GetAll()
        {
            var jsonString = _dataSource.DataProvider();

            //var results =  JsonConvert.DeserializeObject<List<UserDTO>>(jsonString);

            var result = jsonString["users"].ToObject<List<UserDTO>>();

            return result;
        }
    }
}
