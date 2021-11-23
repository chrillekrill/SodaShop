using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sodashop.DTO.DTOs;
using Sodashop.UI.DataAccess;
using System.ComponentModel.DataAnnotations;

namespace Sodashop.UI.Pages.StorePages
{
    public class PlaceOrderPageModel : PageModel
    {

        private readonly IShoppingCartDataAccess<ShoppingCartDTO> dataAccessShoppingCart;
        private readonly IUserDataAccess<UserDTO> dataAccessUser;
        private readonly IOrderDataAccess<OrderDTO> dataAccessOrder;
        [BindProperty]
        public ShoppingCartDTO ShoppingCart { get; set; }
        [BindProperty]
        public UserDTO User { get; set; }
        [BindProperty]
        public int PaymentOption { get; set; }
        [BindProperty]
        public int SCN { get; set; }
        public PlaceOrderPageModel(IShoppingCartDataAccess<ShoppingCartDTO> dataAccessShoppingCart, IUserDataAccess<UserDTO> userDataAccess, IOrderDataAccess<OrderDTO> dataAccessOrder)
        {
            this.dataAccessShoppingCart = dataAccessShoppingCart;
            this.dataAccessUser = userDataAccess;
            this.dataAccessOrder = dataAccessOrder;
        }
        public void OnGet(int cartID)
        {
            ShoppingCart = dataAccessShoppingCart.getShoppingCart(cartID);
            User = dataAccessUser.GetUserByID(cartID);

        }
        public void OnGetPayWithOption(int option, int cartID)
        {
            ShoppingCart = dataAccessShoppingCart.getShoppingCart(cartID);
            User = dataAccessUser.GetUserByID(cartID);
            PaymentOption = option;
        }
    }
}
