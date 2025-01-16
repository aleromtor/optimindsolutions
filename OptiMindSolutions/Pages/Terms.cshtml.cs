using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace OptiMindSolutions.Pages
{
    public class TermsModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;

        public TermsModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }

}
