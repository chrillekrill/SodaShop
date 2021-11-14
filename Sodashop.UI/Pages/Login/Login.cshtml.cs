using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sodashop.UI.DataAccess;
using Sodashop.UI.DTOs;

namespace Sodashop.UI.Pages.Login
{
    public class LoginModel : PageModel
    {
        private readonly IDataAccess<UserDTO> dataAccessUsers;
        private readonly IDataAccess<ProductDTO> dataAccessProducts;
        public LoginModel(IDataAccess<UserDTO> dataAccessUsers, IDataAccess<ProductDTO> dataAccessProducts)
        {
            this.dataAccessUsers = dataAccessUsers;
            this.dataAccessProducts = dataAccessProducts;
        }
        public List<UserDTO> Users { get; private set; }
        public List<ProductDTO> Products { get; private set; }
        public void OnGet()
        {
            Users = dataAccessUsers.GetAll();
            Products = dataAccessProducts.GetAll();
        }
    }
}
