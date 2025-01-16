using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace OptiMindSolutions.Pages
{
    public class LocationModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;

        public LocationModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }

}
