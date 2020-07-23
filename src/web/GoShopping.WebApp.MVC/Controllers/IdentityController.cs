using GoShopping.WebApp.MVC.Models;
using GoShopping.WebApp.MVC.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoShopping.WebApp.MVC.Controllers
{
    public class IdentityController : MainController
    {
        private readonly IAuthenticationService _authenticationService;

        public IdentityController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpGet]
        [Route("new-account")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [Route("new-account")]
        public async Task<IActionResult> Register(UserRegister userRegister)
        {
            if (!ModelState.IsValid) return View(userRegister);

            // API - Registro

            if (false) return View(userRegister);

            //Realizar login na APP
            var response = await _authenticationService.Register(userRegister);

            return RedirectToAction("Index", "Home");



            //if (ResponsePossuiErros(resposta.ResponseResult)) return View(userRegister);

            //await RealizarLogin(resposta);

        }

        [HttpGet]
        [Route("login")]
        public IActionResult Login(/*string returnUrl = null*/)
        {
            /* ViewData["ReturnUrl"] = returnUrl;*/
            return View();
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(UserLogin userLogin, string returnUrl = null)
        {
            if (!ModelState.IsValid) return View(userLogin);

            // API - Login
            var response = await _authenticationService.Login(userLogin);

            if (false) return View(userLogin);

            //Realizar login na APP

            return RedirectToAction("Index", "Home");

            //ViewData["ReturnUrl"] = returnUrl;

            

            //if (ResponsePossuiErros(resposta.ResponseResult)) return View(userLogin);

            //await RealizarLogin(resposta);

            //if (string.IsNullOrEmpty(returnUrl)) return RedirectToAction("Index", "Home");

            //return LocalRedirect(returnUrl);
        }

        [HttpGet]
        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            //await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        /*private async Task RealizarLogin(UsuarioRespostaLogin resposta)
        {
            var token = ObterTokenFormatado(resposta.AccessToken);

            var claims = new List<Claim>();
            claims.Add(new Claim("JWT", resposta.AccessToken));
            claims.AddRange(token.Claims);

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(60),
                IsPersistent = true
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);
        }
        ss
        private static JwtSecurityToken ObterTokenFormatado(string jwtToken)
        {
            return new JwtSecurityTokenHandler().ReadToken(jwtToken) as JwtSecurityToken;
        }*/
    }
}
