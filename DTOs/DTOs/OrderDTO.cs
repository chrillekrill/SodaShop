using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sodashop.DTO.DTOs
{
    public class OrderDTO
    {
        public Guid OrderNumber { get; set; }
        public List<ProductDTO> OrderedItems { get; set; }
        public bool IsPaid { get; set; }
        public string PaidWith { get; set; }
    }
}
