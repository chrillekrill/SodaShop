using Sodashop.DTO.DTOs;

namespace Sodashop.UI.DataAccess
{
    public interface IShoppingCartDataAccess<T> : IDataAccess<T>
    {
        ShoppingCartDTO createCart(int ID);

        ShoppingCartDTO getShoppingCart(int id);

        void addProduct(ProductDTO product, int cartID);

        void clearCart(int cartID);

        void changeQuantity(int cartID, int productID, char plusOrMinus);
    }
}
