using GoShopping.WebApp.MVC.Extensions;
using GoShopping.WebApp.MVC.Models;
using Microsoft.Extensions.Options;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace GoShopping.WebApp.MVC.Services
{
    public class AuthenticationService : Service, IAuthenticationService
    {
        private readonly HttpClient _httpclient;
        private readonly AppSettings _settings;

        public AuthenticationService(HttpClient httpClient, IOptions<AppSettings> settings)
        {
            httpClient.BaseAddress = new Uri(_settings.UrlAuthentication);

            _httpclient = httpClient;
            //_settings = settings.Value;
        }
        public async Task<UserResponseLogin> Login(UserLogin userLogin)
        {
            var loginContent = GetContent(userLogin);

            var response = await _httpclient.PostAsync("/api/identity/authenticate", loginContent);

            if (!ProcessErrorsResponse(response))
            {
                return new UserResponseLogin
                {
                    ResponseResult = await DeserializeObjectResponse<ResponseResult>(response)
                };
            }

            return await DeserializeObjectResponse<UserResponseLogin>(response)
        }

        public async Task<UserResponseLogin> Register(UserRegister userRegister)
        {
            var registerContent = GetContent(userRegister);

            var response = await _httpclient.PostAsync("/api/identity/new-account", registerContent);

            if (!ProcessErrorsResponse(response))
            {
                return new UserResponseLogin
                {
                    ResponseResult = await DeserializeObjectResponse<ResponseResult>(response)
                };
            }

            return await DeserializeObjectResponse<UserResponseLogin>(response);
        }
    }
}
