using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace GoShopping.WebApp.MVC.Configuration
{
    public static class IdentityConfig
    {
        public static void AddIdentityConfiguration(this IServiceCollection services)
        {
            // Adiciona autenticação por cookie
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/login";   //rota para redirecionar quando não estiver logado
                    options.AccessDeniedPath = "/acesso-negado";  //onde será encaminhado quando não tiver acesso
                    //options.AccessDeniedPath = "/erro/403";  //onde será encaminhado quando não tiver acesso
                });
        }

        public static void UseIdentityConfiguration(this IApplicationBuilder app)
        {
            app.UseAuthentication();
            app.UseAuthorization();
        }
    }
}