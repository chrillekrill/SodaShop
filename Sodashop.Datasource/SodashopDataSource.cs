using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Sodashop.Datasource
{
    public class SodashopDataSource
    {
        public JObject DataProvider()
        {
            //var currentDirectory = System.AppDomain.CurrentDomain.BaseDirectory;

            var projectDirectory = Path.GetFullPath(@"..\..\");

            var jsonRespone = JObject.Parse(File.ReadAllText(projectDirectory + "\\SodaShop\\Sodashop.Datasource\\Database.json"));

            return jsonRespone;
        }
    }
}