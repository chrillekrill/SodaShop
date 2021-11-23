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
            var jsonString = _dataSource.DataProviderUsers();

            var result =  JsonConvert.DeserializeObject<List<UserDTO>>(jsonString);

            return result;
        }

        public bool LoginCheck(string Email, string Password)
        {
            List<UserDTO> users = GetAll();
            foreach (var user in users)
            {
                if(user.Email.Equals(Email) && user.Password.Equals(Password))
                {
                    return true;
                }
            }

            return false;
        }

        public int GetID(string Email)
        {
            List<UserDTO> users = GetAll();

            foreach (var user in users)
            {
                if (Email == user.Email)
                {
                    
                    return user.UserID;
                }
            }
            return 0;
        }
        public UserDTO GetUserByID(int ID)
        {
            List<UserDTO> users = GetAll();

            return users.Single(user => user.UserID == ID);
        }
    }
}
