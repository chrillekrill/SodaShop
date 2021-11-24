using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sodashop.DTO.DTOs;
using Sodashop.UI.DataAccess;

namespace Sodashop.UI.Pages.StorePages
{
    public class PayWithKlarnaPageModel : PageModel
    {
        private readonly IShoppingCartDataAccess<ShoppingCartDTO> dataAccessShoppingCart;
        private readonly IUserDataAccess<UserDTO> dataAccessUser;
        private readonly IOrderDataAccess<OrderDTO> dataAccessOrder;

        public ShoppingCartDTO ShoppingCart { get; set; }
        public string FeedBack { get; set; }
        public string FeedBackClass { get; set; }
        public UserDTO User { get; set; }
        public int paymentOpt { get; set; }
        [BindProperty]
        public string SSN { get; set; }

        public PayWithKlarnaPageModel(IShoppingCartDataAccess<ShoppingCartDTO> dataAccessShoppingCart, IUserDataAccess<UserDTO> userDataAccess, IOrderDataAccess<OrderDTO> dataAccessOrder)
        {
            this.dataAccessShoppingCart = dataAccessShoppingCart;
            this.dataAccessUser = userDataAccess;
            this.dataAccessOrder = dataAccessOrder;
        }
        public void OnGet(int cartID, int paymentOpt)
        {
            ShoppingCart = dataAccessShoppingCart.getShoppingCart(cartID);
            User = dataAccessUser.GetUserByID(cartID);
            this.paymentOpt = paymentOpt;
        }
        public IActionResult OnPostPayWithKlarna(int cartID, int option, string SSN)
        {
            if (ModelState.IsValid)
            {
                this.SSN = SSN;

                ShoppingCart = dataAccessShoppingCart.getShoppingCart(cartID);
                User = dataAccessUser.GetUserByID(cartID);

                dataAccessOrder.CreateOrder(User, ShoppingCart, option, SSN);
                dataAccessShoppingCart.clearCart(cartID);

                return RedirectToPage("/StorePages/ThankYouPage", new { ID = ShoppingCart.ShoppingCartId });
            }
            ShoppingCart = dataAccessShoppingCart.getShoppingCart(cartID);
            User = dataAccessUser.GetUserByID(cartID);
            FeedBack = "Please write a valid social security number";
            FeedBackClass = "alert alert-danger";
            return Page();
        }
    }
}
