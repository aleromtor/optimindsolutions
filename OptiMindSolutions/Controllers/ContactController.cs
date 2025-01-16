using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OptiMindSolutions.Controllers
{
    public class ContactController : Controller
    {
        public class CallRequest
        {
            [JsonPropertyName("name")]
            public string Name { get; set; }

            [JsonPropertyName("phone")]
            public string Phone { get; set; }

            [JsonPropertyName("email")]
            public string Email { get; set; }
        }

        [HttpPost("/Call")]
        public async Task<IActionResult> Call([FromBody] CallRequest request)
        {
            using (var client = new HttpClient())
            {
                // Acceder a las claves desde las variables de entorno
                var twilioAccountSid = Environment.GetEnvironmentVariable("TWILIO_ACCOUNT_SID");
                var twilioAuthToken = Environment.GetEnvironmentVariable("TWILIO_AUTH_TOKEN");
                var apiKey = Environment.GetEnvironmentVariable("VAPI_API_KEY");

                // Configurar la autorización con la API key
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

                // Crear el payload que enviarás a la API
                var payload = new
                {
                    assistantId = "c1788135-59a4-4301-87a0-e91c8f7abb5a",
                    assistantOverrides = new
                    {
                        variableValues = new
                        {
                            name = request.Name,
                            email = request.Email
                        }
                    },
                    customer = new
                    {
                        name = request.Name,
                        number = request.Phone
                    },
                    phoneNumber = new
                    {
                        twilioAccountSid = twilioAccountSid,
                        twilioAuthToken = twilioAuthToken,
                        twilioPhoneNumber = "+18334360187"
                    }
                };

                // Convertir el payload a JSON
                var json = JsonSerializer.Serialize(payload);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                // Hacer la solicitud POST a la API
                var response = await client.PostAsync("https://api.vapi.ai/call", content);

                // Verificar la respuesta de la API
                if (response.IsSuccessStatusCode)
                {
                    return Ok();
                }
                else
                {
                    var error = await response.Content.ReadAsStringAsync();
                    return StatusCode((int)response.StatusCode, error);
                }
            }
        }
    }
}
