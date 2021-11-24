using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sodashop.DTO.DTOs;
using Sodashop.UI.DataAccess;
using System.ComponentModel.DataAnnotations;

namespace Sodashop.UI.Pages.StorePages
{
    public class PayWithCardPageModel : PageModel
    {
        private readonly IShoppingCartDataAccess<ShoppingCartDTO> dataAccessShoppingCart;
        private readonly IUserDataAccess<UserDTO> dataAccessUser;
        private readonly IOrderDataAccess<OrderDTO> dataAccessOrder;

        [BindProperty]
        public ShoppingCartDTO ShoppingCart { get; set; }
        public UserDTO User { get; set; }
        public string FeedBack { get; set; }
        public string FeedBackClass { get; set; }
        [BindProperty]
        [Required]
        public string CardNumber { get; set; }
        [BindProperty]
        [Required]
        public string SecurityNumber { get; set; }
        [BindProperty]
        [Required]
        public string ExpNumberYY { get; set; }
        [BindProperty]
        [Required]
        public string ExpNumberMM { get; set; }
        public string ExpNumber { get; set; }
        [BindProperty]
        public int paymentOpt { get; set; }
        public int cartID { get; set; }
        public PayWithCardPageModel(IShoppingCartDataAccess<ShoppingCartDTO> dataAccessShoppingCart, IUserDataAccess<UserDTO> userDataAccess, IOrderDataAccess<OrderDTO> dataAccessOrder)
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
            this.cartID = cartID;
        }
        public IActionResult OnPostPayWithCard(int cartID, int paymentOpt)
        {
            if (ModelState.IsValid)
            {
                ShoppingCart = dataAccessShoppingCart.getShoppingCart(cartID);
                User = dataAccessUser.GetUserByID(cartID);

                dataAccessOrder.CreateOrder(User, ShoppingCart, paymentOpt, CardNumber);
                dataAccessShoppingCart.clearCart(cartID);

                return RedirectToPage("/StorePages/ThankYouPage", new { ID = ShoppingCart.ShoppingCartId });
            }
            ShoppingCart = dataAccessShoppingCart.getShoppingCart(cartID);
            User = dataAccessUser.GetUserByID(cartID);
            FeedBack = "Please write a valid card number";
            FeedBackClass = "alert alert-danger";
            return Page();
        }
    }
}
