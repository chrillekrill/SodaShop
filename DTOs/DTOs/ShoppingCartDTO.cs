using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sodashop.DTO.DTOs
{
    public class ShoppingCartDTO
    {
        public List<ProductDTO> CartÍtems { get; set; }
        public int ShoppingCartId { get; set; }

        public ShoppingCartDTO()
        {
            CartÍtems = new List<ProductDTO>();
        }
    }
}
