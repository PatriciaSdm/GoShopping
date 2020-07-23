using GoShopping.WebApp.MVC.Models;
using GoShopping.WebApp.MVC.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GoShopping.WebApp.MVC.Controllers
{
    public class IdentityController : MainController
    {
        private readonly Services.IAuthenticationService _authenticationService;

        public IdentityController(Services.IAuthenticationService authenticationService)
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
            var response = await _authenticationService.Register(userRegister);

            if (ResponseHasErrors(response.ResponseResult)) return View(userRegister);

            //Realizar login na APP
            await ProcessLogin(response);
           

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

            if (ResponseHasErrors(response.ResponseResult)) return View(userLogin);

            //Realizar login na APP
            await ProcessLogin(response);

            return RedirectToAction("Index", "Home");

            //ViewData["ReturnUrl"] = returnUrl;



            //if (ResponsePossuiErros(resposta.ResponseResult)) return View(userLogin);

            

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

        private async Task ProcessLogin(UserResponseLogin response)
        {
            var token = GetFormattedToken(response.AccessToken);

            var claims = new List<Claim>();
            claims.Add(new Claim("JWT", response.AccessToken));
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

        private static JwtSecurityToken GetFormattedToken(string jwtToken)
        {
            return new JwtSecurityTokenHandler().ReadToken(jwtToken) as JwtSecurityToken;
        }
    }
}
