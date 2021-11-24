using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sodashop.DTO.DTOs;
using Sodashop.UI.DataAccess;

namespace Sodashop.UI.Pages.Login
{
    public class UserPageModel : PageModel
    {
        private readonly IUserDataAccess<UserDTO> dataAccessUsers;
        private readonly IOrderDataAccess<OrderDTO> dataAccessOrder;
        public UserDTO user { get; set; }
        public List<OrderDTO> orders { get; set; }
        public int ID { get; set; }
        public UserPageModel(IUserDataAccess<UserDTO> dataAccessUsers, IOrderDataAccess<OrderDTO> dataAccessOrder)
        {
            this.dataAccessUsers = dataAccessUsers;
            this.dataAccessOrder = dataAccessOrder;
        }
        public void OnGet(int userID)
        {
            ID = userID;
            user = dataAccessUsers.GetUserByID(userID);
            orders = dataAccessOrder.GetAllUserOrders(user.OrderNumbers);
        }
        public IActionResult OnGetPay(Guid orderNumber, int userID)
        {
            if (ModelState.IsValid)
            {
                user = dataAccessUsers.GetUserByID(userID);
                orders = dataAccessOrder.GetAllUserOrders(user.OrderNumbers);
                dataAccessOrder.PayKlarnaOrder(orderNumber);
                return RedirectToPage("/Login/UserPage", new { userID = userID });
            }
            return Page();
        }
    }
}
