namespace Sodashop.UI.DTOs
{
    public class UserDTO
    {
        public string Email { get; private set; }
        public string Password { get; private set; }

        public UserDTO(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
