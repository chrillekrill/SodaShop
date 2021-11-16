using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sodashop.UI.DataAccess;
using Sodashop.DTO.DTOs;
using System.ComponentModel.DataAnnotations;

namespace Sodashop.UI.Pages.Login
{
    public class LoginModel : PageModel
    {
        private readonly IUserDataAccess<UserDTO> dataAccessUsers;

        [BindProperty]
        public UserDTO user { get; set; }

        public LoginModel(IUserDataAccess<UserDTO> dataAccessUsers)
        {
            this.dataAccessUsers = dataAccessUsers;
        }
        public List<UserDTO> Users { get; private set; }
        public void OnGet()
        {
            Users = dataAccessUsers.GetAll();
        }

        public IActionResult OnPostLogin()
        {

                if (dataAccessUsers.LoginCheck(user.Email, user.Password))
                {
                    return RedirectToPage("/StorePages/FrontStore");
                }
                else
                {
                    return Page();
                }
        }
    }
}
