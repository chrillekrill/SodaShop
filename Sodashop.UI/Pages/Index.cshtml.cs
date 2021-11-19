using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sodashop.Datasource;
using Sodashop.UI.DataAccess;
using Sodashop.DTO.DTOs;


namespace Sodashop.UI.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IProductDataAccess<ProductDTO> dataAccessProducts;
        public List<ProductDTO> Products { get; private set; }

        public IndexModel(ILogger<IndexModel> logger, IProductDataAccess<ProductDTO> dataAccessProducts)
        {
            _logger = logger;
            this.dataAccessProducts = dataAccessProducts;
        }

        public void OnGet()
        {
            Products = dataAccessProducts.GetAll();
        }
    }
}