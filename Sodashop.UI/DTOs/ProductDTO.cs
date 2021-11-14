namespace Sodashop.UI.DTOs
{
    public class ProductDTO
    {
        public string ProductName { get; private set; }
        public int ProductID { get; private set; }
        public ProductDTO(string productName, int productID)
        {
            ProductName = productName;
            ProductID = productID;
        }
    }
}
