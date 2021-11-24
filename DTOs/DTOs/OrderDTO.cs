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
        public decimal OrderPrice { get; set; }
        public bool IsPaid { get; set; }
        public string PaidWith { get; set; }
        public string SentToAddress { get; set; }
        public string SentToName { get; set; }
        public string CCN { get; set; }
    }
}
