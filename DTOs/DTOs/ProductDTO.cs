namespace Sodashop.DTO.DTOs
{
    public class ProductDTO
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public string ProductImage { get; set; }
        public int ID { get; set; }
        public int ProductID
        {
            get { return ID; }
            set
            {
                ID = value;

                switch (ID)
                {
                    //coca cola
                    case 13:
                        ProductImage = @"https://i.ibb.co/C0brYtC/5000112637922-1624968945047-master-axfood-400.jpg";
                        break;
                    //Fanta
                    case 15:
                        ProductImage = @"https://i.ibb.co/Xx860qn/5000112650723-1626900019030-master-axfood-400.jpg";
                        break;
                    case 1335:
                        ProductImage = @"https://i.ibb.co/b39FCzt/5000112637977-1554603683787-master-axfood-400.jpg";
                        break;
                    default:
                        ProductImage = "Image not found";
                        break;
                }
            }
        }
    }
}
