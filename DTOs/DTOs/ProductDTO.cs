namespace Sodashop.DTO.DTOs
{
    public class ProductDTO
    {
        public string ProductName { get; private set; }

        public int Quantity { get; private set; }
        public string ProductImage { get; set; }
        public int ID { get; private set; }
        public int ProductID
        {
            get { return ID; }
            private set
            {
                ID = value;

                var projectDirectory = Path.GetFullPath(@"..\..\");

                var images = @"ProductImages\";

                switch (ID)
                {
                    case 13:
                        ProductImage = @"https://i.ibb.co/6Wqb5BM/coca-cola-can-white-background-chisinau-moldova-november-flavored-soft-drink-created-company-6414505.jpg";
                        break;
                    default:
                        ProductImage = "Image not found";
                        break;
                }
            }
        }
        public ProductDTO(string productName, int productID)
        {
            ProductName = productName;
            ProductID = productID;


        }
    }
}
