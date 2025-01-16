using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace OptiMindSolutions.Pages
{
    public class ServiceModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;

        public ServiceModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }

}
