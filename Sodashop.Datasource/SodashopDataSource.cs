using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Sodashop.Datasource
{
    public class SodashopDataSource
    {
        public string DataProviderProducts()
        {
            //var currentDirectory = System.AppDomain.CurrentDomain.BaseDirectory;

            var projectDirectory = Path.GetFullPath(@"..\..\");

            var jsonRespone = File.ReadAllText(projectDirectory + "\\SodaShop\\Sodashop.Datasource\\Products.json");

            return jsonRespone;
        }
        public string DataProviderOrders()
        {
            //var currentDirectory = System.AppDomain.CurrentDomain.BaseDirectory;

            var projectDirectory = Path.GetFullPath(@"..\..\");

            var jsonRespone = File.ReadAllText(projectDirectory + "\\SodaShop\\Sodashop.Datasource\\Orders.json");

            return jsonRespone;
        }
        public string DataProviderUsers()
        {
            var projectDirectory = Path.GetFullPath(@"..\..\");

            var jsonRespone = File.ReadAllText(projectDirectory + "\\SodaShop\\Sodashop.Datasource\\Users.json");

            return jsonRespone;

        }

        public string DataProviderShoppingCarts()
        {
            var projectDirectory = Path.GetFullPath(@"..\..\");

            var jsonRespone = File.ReadAllText(projectDirectory + "\\SodaShop\\Sodashop.Datasource\\ShoppingCarts.json");

            return jsonRespone;

        }
    }
}