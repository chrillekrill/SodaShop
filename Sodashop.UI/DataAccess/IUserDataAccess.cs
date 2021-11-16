using Sodashop.DTO.DTOs;

namespace Sodashop.UI.DataAccess
{
    public interface IUserDataAccess<T> : IDataAccess<T>
    {
        bool LoginCheck(string Email, string Password);
    }
}
