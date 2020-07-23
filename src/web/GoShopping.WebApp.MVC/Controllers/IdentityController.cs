using GoShopping.WebApp.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoShopping.WebApp.MVC.Controllers
{
    public class IdentityController : MainController
    {
        /*private readonly IAutenticacaoService _autenticacaoService;

        public IdentityController(IAutenticacaoService autenticacaoService)
        {
            _autenticacaoService = autenticacaoService;
        }*/

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

            return RedirectToAction("Index", "Home");


            //var resposta = await _autenticacaoService.Registro(userRegister);

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

            if (false) return View(userLogin);

            //Realizar login na APP

            return RedirectToAction("Index", "Home");

            //ViewData["ReturnUrl"] = returnUrl;
            //if (!ModelState.IsValid) return View(userLogin);

            //var resposta = await _autenticacaoService.Login(userLogin);

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
