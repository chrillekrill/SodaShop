using Sodashop.DTO.DTOs;

namespace Sodashop.UI.DataAccess
{
    public interface IOrderDataAccess<T> : IDataAccess<T>
    {
        List<OrderDTO> GetAllUserOrders(List<Guid> userOrders);

        void CreateOrder(UserDTO user, ShoppingCartDTO cart, int option);
    }
}
