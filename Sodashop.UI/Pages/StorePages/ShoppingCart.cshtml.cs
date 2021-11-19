using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sodashop.DTO.DTOs;
using Sodashop.UI.DataAccess;

namespace Sodashop.UI.Pages.StorePages
{
    public class ShoppingCartModel : PageModel
    {
        private readonly IShoppingCartDataAccess<ShoppingCartDTO> dataAccessShoppingCart;
        public ShoppingCartDTO ShoppingCart { get; set; }
        public ShoppingCartModel(IShoppingCartDataAccess<ShoppingCartDTO> dataAccessShoppingCart)
        {
            this.dataAccessShoppingCart = dataAccessShoppingCart;
        }
        public void OnGet(int cartID)
        {
            ShoppingCart = dataAccessShoppingCart.getShoppingCart(cartID);
        }
    }
}
