using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

namespace OptiMindSolutions.Models
{
    public class ContactModel : PageModel
    {
        // Propiedades para los datos del formulario
        [BindProperty]
        public string Name { get; set; }

        [BindProperty]
        public string PhoneNumber { get; set; }

        // Método OnGet: Se ejecuta cuando se accede a la página de contacto
        public void OnGet()
        {
        }

        // Método OnPost: Se ejecuta cuando el formulario es enviado
        public IActionResult OnPost()
        {
            // Validar si el formulario es válido
            if (ModelState.IsValid)
            {
                // Aquí es donde puedes manejar la lógica para enviar los datos
                // Por ejemplo, guardarlos en una base de datos o enviarlos por correo
                // Aquí solo vamos a mostrar un mensaje de éxito

                TempData["SuccessMessage"] = "¡Gracias por contactarnos! Te responderemos pronto.";

                // Redirigir a la misma página para mostrar el mensaje de éxito
                return RedirectToPage();
            }

            // Si el formulario no es válido, solo retornamos la página
            return Page();
        }
    }
}