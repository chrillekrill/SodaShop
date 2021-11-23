using Newtonsoft.Json;
using Sodashop.Datasource;
using Sodashop.DTO.DTOs;

namespace Sodashop.UI.DataAccess
{
    public class OrderDataAccess : IOrderDataAccess<OrderDTO>
    {
        private readonly SodashopDataSource _dataSource;
        public OrderDataAccess(SodashopDataSource dataSource)
        {
            _dataSource = dataSource;
        }
        public List<OrderDTO> GetAll()
        {
            var jsonString = _dataSource.DataProviderOrders();

            var result = JsonConvert.DeserializeObject<List<OrderDTO>>(jsonString);

            return result;
        }
        public List<OrderDTO> GetAllUserOrders(List<Guid> userOrders)
        {
            var orders = GetAll();
            List<OrderDTO> orderDTOs = new List<OrderDTO>();

            foreach (var order in orders)
            {
                foreach(var orderNum in userOrders)
                {
                    if(orderNum == order.OrderNumber)
                    {
                        orderDTOs.Add(order);
                    }
                }
            }
            return orderDTOs;
        }

        public void CreateOrder(UserDTO user, ShoppingCartDTO cart, int option) {
            var projectDirectory = Path.GetFullPath(@"..\..\");
            var path = projectDirectory + "\\SodaShop\\Sodashop.Datasource\\";
            var jsonResponseOrders = File.ReadAllText(path + "Orders.json");
            var jsonResponseUsers = File.ReadAllText(path + "Users.json");
            var resultOrders = JsonConvert.DeserializeObject<List<OrderDTO>>(jsonResponseOrders);
            var resultUsers = JsonConvert.DeserializeObject<List<UserDTO>>(jsonResponseUsers);

            var indexOfUser = resultUsers.IndexOf(resultUsers.Single(userCheck => userCheck.UserID == user.UserID));

            OrderDTO newOrder = new OrderDTO();
            newOrder.OrderNumber = Guid.NewGuid();
            newOrder.OrderedItems = cart.CartÍtems;

            if(option == 2)
            {
                newOrder.PaidWith = "Debit Card";
                newOrder.IsPaid = true;
            } else
            {
                newOrder.PaidWith = "Klarna";
                newOrder.IsPaid = false;
            }

            resultUsers[indexOfUser].OrderNumbers.Add(newOrder.OrderNumber);
            resultOrders.Add(newOrder);

            var serializedOrder = JsonConvert.SerializeObject(resultOrders);
            var serializedUser = JsonConvert.SerializeObject(resultUsers);

            File.WriteAllText(path + "Orders.json", serializedOrder);
            File.WriteAllText(path + "Users.json", serializedUser);
        }
    }
}
