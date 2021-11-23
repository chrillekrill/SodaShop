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
        [BindProperty]
        public string ErrorMessage{ get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Card Number is required")]
        public string CardNumber { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "expiration year is required")]
        public string ExpNumberYY { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "expiration month is required")]
        public string ExpNumberMM { get; set; }
        public string ExpNumber { get; set; }
        [BindProperty]
        public int paymentOpt { get; set; }
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
        }
        public IActionResult OnPostPayWithCard(string CardNumber, string ExpNumberMM, string ExpNumberYY, int cartID, int option)
        {
            if (ModelState.IsValid)
            {
                this.CardNumber = CardNumber;
                this.ExpNumberMM = ExpNumberMM;
                this.ExpNumberYY = ExpNumberYY;

                ExpNumber = ExpNumberMM + "/" + ExpNumberYY;

                ShoppingCart = dataAccessShoppingCart.getShoppingCart(cartID);
                User = dataAccessUser.GetUserByID(cartID);

                dataAccessOrder.CreateOrder(User, ShoppingCart, option);
                dataAccessShoppingCart.clearCart(cartID);

                return RedirectToPage("/StorePages/ThankYouPage", new { ID = ShoppingCart.ShoppingCartId });
            }
            ShoppingCart = dataAccessShoppingCart.getShoppingCart(cartID);
            User = dataAccessUser.GetUserByID(cartID);
            return Page();
        }
    }
}
