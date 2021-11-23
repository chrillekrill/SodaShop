using Newtonsoft.Json;
using Sodashop.Datasource;
using Sodashop.DTO.DTOs;

namespace Sodashop.UI.DataAccess
{
    public class ShoppingCartDataAccess : IShoppingCartDataAccess<ShoppingCartDTO>
    {
        private readonly SodashopDataSource _dataSource;

        public ShoppingCartDataAccess(SodashopDataSource dataSource)
        {
            _dataSource = dataSource;
        }

        public List<ShoppingCartDTO> GetAll()
        {
            var jsonString = _dataSource.DataProviderShoppingCarts();

            var result = JsonConvert.DeserializeObject<List<ShoppingCartDTO>>(jsonString);

            return result;
        }
        public ShoppingCartDTO getShoppingCart(int id)
        {
            var projectDirectory = Path.GetFullPath(@"..\..\");
            var path = projectDirectory + "\\SodaShop\\Sodashop.Datasource\\ShoppingCarts.json";
            var jsonResponse = File.ReadAllText(path);
            var result = JsonConvert.DeserializeObject<List<ShoppingCartDTO>>(jsonResponse);

            var shoppingCart = result.Single(cart => cart.ShoppingCartId == id);

            return shoppingCart;
        }
        public ShoppingCartDTO createCart(int ID)
        {
            var projectDirectory = Path.GetFullPath(@"..\..\");
            var path = projectDirectory + "\\SodaShop\\Sodashop.Datasource\\ShoppingCarts.json";
            var jsonResponse = File.ReadAllText(path);
            var existingCarts = JsonConvert.DeserializeObject<List<ShoppingCartDTO>>(jsonResponse);

            ShoppingCartDTO Cart = new ShoppingCartDTO();
            Cart.ShoppingCartId = ID;

            existingCarts.Add(Cart);

            var serializedCarts = JsonConvert.SerializeObject(existingCarts);

            File.WriteAllText(path, serializedCarts);

            return Cart;
        }
        public void changeQuantity(int cartID, int productID, char plusOrMinus)
        {
            var projectDirectory = Path.GetFullPath(@"..\..\");
            var path = projectDirectory + "\\SodaShop\\Sodashop.Datasource\\ShoppingCarts.json";
            var jsonResponse = File.ReadAllText(path);
            var result = JsonConvert.DeserializeObject<List<ShoppingCartDTO>>(jsonResponse);

            var shoppingCart = result.Single(cart => cart.ShoppingCartId == cartID);

            var updatedCart = result.IndexOf(shoppingCart);

            var productToUpdate = result[updatedCart].CartÍtems.SingleOrDefault(product => product.ID == productID);

            var updatedProduct = result[updatedCart].CartÍtems.IndexOf(productToUpdate);

            switch (plusOrMinus)
            {
                case '+':
                    result[updatedCart].CartÍtems[updatedProduct].Quantity++;
                    break;
                case '-':
                    if(result[updatedCart].CartÍtems[updatedProduct].Quantity > 1)
                    {
                        result[updatedCart].CartÍtems[updatedProduct].Quantity--;
                    } else
                    {
                        result[updatedCart].CartÍtems.Remove(productToUpdate);
                    }
                    break;
                default:
                    result[updatedCart].CartÍtems[updatedProduct].Quantity = result[updatedCart].CartÍtems[updatedProduct].Quantity;
                    break;
            }
            var serializedCarts = JsonConvert.SerializeObject(result);

            File.WriteAllText(path, serializedCarts);
        }
        public void addProduct(ProductDTO product, int cartID)
        {
            var projectDirectory = Path.GetFullPath(@"..\..\");
            var path = projectDirectory + "\\SodaShop\\Sodashop.Datasource\\ShoppingCarts.json";
            var jsonResponse = File.ReadAllText(path);
            var result = JsonConvert.DeserializeObject<List<ShoppingCartDTO>>(jsonResponse);

            var shoppingCart = result.Single(cart => cart.ShoppingCartId == cartID);

            var updatedCart = result.IndexOf(shoppingCart);

            List<ProductDTO> products = new List<ProductDTO>();

            if(result[updatedCart].CartÍtems != null)
            {
                foreach (var item in result[updatedCart].CartÍtems)
                {
                        products.Add(new ProductDTO
                        {
                            ProductID = item.ProductID,
                            ProductImage = item.ProductImage,
                            ProductName = item.ProductName,
                            Stock = item.Stock,
                            Price = item.Price,
                            Quantity = item.Quantity,
                        });
                }     
            }
            bool productExists = products.Any(item => item.ProductID == product.ProductID);
            if(!productExists)
            {
                products.Add(new ProductDTO
                {
                    ProductID = product.ProductID,
                    ProductImage = product.ProductImage,
                    ProductName = product.ProductName,
                    Stock = product.Stock,
                    Price = product.Price,
                    Quantity = product.Quantity + 1
                });
            } else
            {
                products.Single(item => item.ProductID == product.ProductID).Quantity++;
            }
                
            

            result[updatedCart].CartÍtems = products;

            var serializedCarts = JsonConvert.SerializeObject(result);

            File.WriteAllText(path, serializedCarts);
        }

        public void clearCart(int cartID)
        {
            

            var projectDirectory = Path.GetFullPath(@"..\..\");
            var path = projectDirectory + "\\SodaShop\\Sodashop.Datasource\\ShoppingCarts.json";
            var jsonResponse = File.ReadAllText(path);
            var result = JsonConvert.DeserializeObject<List<ShoppingCartDTO>>(jsonResponse);

            var shoppingCart = result.Single(cart => cart.ShoppingCartId == cartID);

            var updatedCart = result.IndexOf(shoppingCart);

            //List<ProductDTO> clearedList = new List<ProductDTO>();

            result[updatedCart].CartÍtems = null;

            var serializedCarts = JsonConvert.SerializeObject(result);

            File.WriteAllText(path, serializedCarts);
        }
    }
}
