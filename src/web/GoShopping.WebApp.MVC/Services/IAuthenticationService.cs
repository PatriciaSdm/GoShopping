using GoShopping.WebApp.MVC.Models;
using System.Threading.Tasks;

namespace GoShopping.WebApp.MVC.Services
{
    public interface IAuthenticationService
    {
        Task<string> Login(UserLogin userLogin);
        Task<string> Register(UserRegister userRegister);
    }
}
