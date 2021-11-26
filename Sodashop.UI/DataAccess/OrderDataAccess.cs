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
                if(userOrders != null)
                {
                    foreach (var orderNum in userOrders)
                    {
                        if (orderNum == order.OrderNumber)
                        {
                            orderDTOs.Add(order);
                        }
                    }
                }  
            }
            return orderDTOs;
        }

        public void CreateOrder(UserDTO user, ShoppingCartDTO cart, int option, string CCN) {
            var projectDirectory = Path.GetFullPath(@"..\..\");
            var path = projectDirectory + "\\SodaShop\\Sodashop.Datasource\\";
            var jsonResponseOrders = File.ReadAllText(path + "Orders.json");
            var jsonResponseUsers = File.ReadAllText(path + "Users.json");
            var resultOrders = JsonConvert.DeserializeObject<List<OrderDTO>>(jsonResponseOrders);
            var resultUsers = JsonConvert.DeserializeObject<List<UserDTO>>(jsonResponseUsers);

            var userWhoOrdered = resultUsers.Single(userCheck => userCheck.UserID == user.UserID);
            var indexOfUser = resultUsers.IndexOf(userWhoOrdered);

            OrderDTO newOrder = new OrderDTO();
            newOrder.OrderNumber = Guid.NewGuid();
            newOrder.OrderedItems = cart.CartÍtems;
            newOrder.OrderPrice = cart.TotalPrice;
            newOrder.SentToAddress = userWhoOrdered.Address;
            newOrder.SentToName = userWhoOrdered.Name;
            string newCCN = CCN.Substring(CCN.Length - 4);
            newOrder.CCN = newCCN;

            if(option == 2)
            {
                newOrder.PaidWith = "Debit Card";
                newOrder.IsPaid = true;
            } else
            {
                newOrder.PaidWith = "Klarna";
                newOrder.IsPaid = false;
            }
            if(resultUsers[indexOfUser].OrderNumbers == null)
            {
                resultUsers[indexOfUser].OrderNumbers = new List<Guid>();
            }
            resultUsers[indexOfUser].OrderNumbers.Add(newOrder.OrderNumber);
            resultOrders.Add(newOrder);

            var serializedOrder = JsonConvert.SerializeObject(resultOrders);
            var serializedUser = JsonConvert.SerializeObject(resultUsers);

            File.WriteAllText(path + "Orders.json", serializedOrder);
            File.WriteAllText(path + "Users.json", serializedUser);
        }
        public void PayKlarnaOrder(Guid orderNumber)
        {
            var projectDirectory = Path.GetFullPath(@"..\..\");
            var path = projectDirectory + "\\SodaShop\\Sodashop.Datasource\\Orders.json";
            var jsonResponseOrders = File.ReadAllText(path);
            var resultOrders = JsonConvert.DeserializeObject<List<OrderDTO>>(jsonResponseOrders);

            resultOrders[resultOrders.IndexOf(resultOrders.Single(order => order.OrderNumber == orderNumber))].IsPaid = true;

            var serializedOrder = JsonConvert.SerializeObject(resultOrders);
            File.WriteAllText(path, serializedOrder);
        }
    }
}
