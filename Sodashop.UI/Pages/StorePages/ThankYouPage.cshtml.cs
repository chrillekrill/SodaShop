using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Sodashop.UI.Pages.StorePages
{
    public class ThankYouPageModel : PageModel
    {
        public int ID { get; set; }
        public void OnGet(int ID)
        {
            this.ID = ID;
        }
    }
}
