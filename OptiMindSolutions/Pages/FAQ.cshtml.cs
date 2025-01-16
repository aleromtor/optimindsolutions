using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace OptiMindSolutions.Pages
{
    public class FAQModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;

        public FAQModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }

}
