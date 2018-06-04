using MasyvaiPrasidedaVienetu.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using MasyvaiPrasidedaVienetu.WebEndpoints.Models;

namespace MasyvaiPrasidedaVienetu.Interfaces
{
    public interface IUserService
    {
        Task<UserViewModel> AddUser(UserViewModel user);
        Task<UserViewModel> BanUser(int id);
        Task<UserViewModel> UnbanUser(int id);
        Task<UserViewModel> UpdateUser(UserViewModel user);
        Task<UserViewModel> DeleteUser(string email);
        Task<UserViewModel> GetUser(int id);
        Task<IEnumerable<UserViewModel>> GetAllUsers();
        Task<UserViewModel> SearchUsers(string email);
        Task<UserViewModel> EditUserRole(UserViewModel user);
        Task<IEnumerable<OrderViewModel>> GetUserOrders(UserViewModel user);
        Task<UserViewModel> EditUser(UserViewModel user);
    }
}
