using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sodashop.Datasource;
using Sodashop.UI.DataAccess;
using Sodashop.UI.DTOs;


namespace Sodashop.UI.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IDataAccess<ProductDTO> dataAccessProducts;
        public List<ProductDTO> Products { get; private set; }

        public IndexModel(ILogger<IndexModel> logger, IDataAccess<ProductDTO> dataAccessProducts)
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