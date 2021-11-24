using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sodashop.DTO.DTOs;
using Sodashop.UI.DataAccess;

namespace Sodashop.UI.Pages.StorePages
{
    public class FrontStoreModel : PageModel
    {

        private readonly IProductDataAccess<ProductDTO> dataAccessProducts;
        private readonly IShoppingCartDataAccess<ShoppingCartDTO> dataAccessShoppingCart;

        public List<ProductDTO> cart = new List<ProductDTO>();
        public List<ProductDTO> Products { get; set; }
        public int CartID { get; set; }
        public ShoppingCartDTO ShoppingCart { get; set; }

        public FrontStoreModel(IProductDataAccess<ProductDTO> dataAccessProducts, IShoppingCartDataAccess<ShoppingCartDTO> dataAccessShoppingCart)
        {
            this.dataAccessProducts = dataAccessProducts;
            this.dataAccessShoppingCart = dataAccessShoppingCart;
        }
        public void OnGet(int cartID)
        {
            this.CartID = cartID;
            Products = dataAccessProducts.GetAll();
            var cartExists = dataAccessShoppingCart.GetAll().SingleOrDefault(cart => cart.ShoppingCartId == cartID);
            if(cartExists != null)
            {
                ShoppingCart = dataAccessShoppingCart.getShoppingCart(cartID);
            } else
            {
                ShoppingCart = dataAccessShoppingCart.createCart(cartID);
            }
            
        }
        public void OnGetAddToCart(int id, int cartID)
        {
            if(ModelState.IsValid)
            {
            ProductDTO productToAdd = dataAccessProducts.GetProductByID(id);

            dataAccessShoppingCart.addProduct(productToAdd, cartID);

            Products = dataAccessProducts.GetAll();
            ShoppingCart = dataAccessShoppingCart.getShoppingCart(cartID);
            }
        }

        public void OnGetClearCart(int cartID)
        {
            if (ModelState.IsValid)
            {
                dataAccessShoppingCart.clearCart(cartID);

                Products = dataAccessProducts.GetAll();
                ShoppingCart = dataAccessShoppingCart.getShoppingCart(cartID);
            }
        }
    }
}
