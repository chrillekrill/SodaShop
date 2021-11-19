using Sodashop.DTO.DTOs;
using Sodashop.Datasource;
using Newtonsoft.Json;

namespace Sodashop.UI.DataAccess
{
    public class UserDataAccess : IUserDataAccess<UserDTO>
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

        public bool LoginCheck(string Email, string Password)
        {
            List<UserDTO> users = GetAll();
            foreach (var user in users)
            {
                if(Email == user.Email && Password == user.Password)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
