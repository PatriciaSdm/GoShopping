using GoShopping.WebApp.MVC.Models;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GoShopping.WebApp.MVC.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly HttpClient _httpclient;

        public AuthenticationService(HttpClient httpClient)
        {
            _httpclient = httpClient;
        }
        public async Task<string> Login(UserLogin userLogin)
        {
            var loginContent = new StringContent(
                JsonSerializer.Serialize(userLogin),
                Encoding.UTF8,
                "application/json");

            var response = await _httpclient.PostAsync("https://localhost:44316/api/identity/authenticate", loginContent);

            return JsonSerializer.Deserialize<string>(await response.Content.ReadAsStringAsync());
        }

        public async Task<string> Register(UserRegister userRegister)
        {
            var registerContent = new StringContent(
              JsonSerializer.Serialize(userRegister),
              Encoding.UTF8,
              "application/json");

            var response = await _httpclient.PostAsync("https://localhost:44316/api/identity/new-account", registerContent);

            return JsonSerializer.Deserialize<string>(await response.Content.ReadAsStringAsync());
        }
    }
}
