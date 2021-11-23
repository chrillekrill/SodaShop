using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sodashop.DTO.DTOs;
using Sodashop.UI.DataAccess;

namespace Sodashop.UI.Pages.StorePages
{
    public class ShoppingCartModel : PageModel
    {
        private readonly IShoppingCartDataAccess<ShoppingCartDTO> dataAccessShoppingCart;
        private readonly IUserDataAccess<UserDTO> dataAccessUser;
        public ShoppingCartDTO ShoppingCart { get; set; }
        public UserDTO User { get; set; }
        public ShoppingCartModel(IShoppingCartDataAccess<ShoppingCartDTO> dataAccessShoppingCart, IUserDataAccess<UserDTO> dataAccessUser)
        {
            this.dataAccessShoppingCart = dataAccessShoppingCart;
            this.dataAccessUser = dataAccessUser;
        }
        public void OnGet(int cartID)
        {
            ShoppingCart = dataAccessShoppingCart.getShoppingCart(cartID);
            User = dataAccessUser.GetUserByID(cartID);
        }

        public void OnGetChangeQuantity(int cartID, int productID, char plusOrMinus)
        {
            dataAccessShoppingCart.changeQuantity(cartID, productID, plusOrMinus);

            ShoppingCart = dataAccessShoppingCart.getShoppingCart(cartID);
            User = dataAccessUser.GetUserByID(cartID);
        }
        //public void OnGetOrders(List<int> userOrders)
        //{
        //    Orders = orderDataAccessOrder.GetOrders(userOrders);
        //    ShoppingCart = dataAccessShoppingCart.getShoppingCart(cartID);
        //    User = dataAccessUser.GetUserByID(cartID);
        //}
    }
}
