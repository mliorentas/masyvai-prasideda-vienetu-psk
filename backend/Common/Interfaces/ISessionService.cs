using System.Threading.Tasks;
using MasyvaiPrasidedaVienetu.Models;

namespace MasyvaiPrasidedaVienetu.Interfaces
{
    public interface ISessionService
    {
        Task<string> AddSession(UserViewModel user);
        Task<bool> ValidateSession(int requiredRole);
        Task Logout(string sessionHash);
        Task<UserViewModel> MatchPassword(UserViewModel user);
        Task<UserViewModel> GetUserBySessionHash();
    }
}
