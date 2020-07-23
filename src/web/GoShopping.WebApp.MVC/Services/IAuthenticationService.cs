using GoShopping.WebApp.MVC.Models;
using System.Threading.Tasks;

namespace GoShopping.WebApp.MVC.Services
{
    public interface IAuthenticationService
    {
        Task<UserResponseLogin> Login(UserLogin userLogin);
        Task<UserResponseLogin> Register(UserRegister userRegister);
    }
}
