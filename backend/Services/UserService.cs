using MasyvaiPrasidedaVienetu.DataAccessLayer;
using MasyvaiPrasidedaVienetu.Interfaces;
using MasyvaiPrasidedaVienetu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasyvaiPrasidedaVienetu.DAL;
using MasyvaiPrasidedaVienetu.WebEndpoints.ExtensionMethods;
using MasyvaiPrasidedaVienetu.Logging;
using MasyvaiPrasidedaVienetu.WebEndpoints.Models;
using Services.Attributes;

namespace MasyvaiPrasidedaVienetu.Services
{
    [MethodLogger]
    public class UserService : IUserService
    {
        private UserRepository _userRep;
        private OrderRepository _orderRep;
        private ILogger _logger;

        public UserService()
        {
            _logger = new FileLogger();
            _orderRep = new OrderRepository();
            _userRep = new UserRepository();
        }

        public async Task<UserViewModel> AddUser(UserViewModel user)
        {
            try
            {
                if (user.FirstName.Length == 0)
                    throw new NullReferenceException("Missing user to add!");
                var addedUser = await _userRep.AddAsync(user.ToEntity());
                return addedUser.ToViewModel();
            }
            catch (NullReferenceException e)
            {
                _logger.Log(e.Message + "\n" + e.StackTrace);
            }

            return null;
        }

        public async Task<UserViewModel> BanUser(int id)
        {
            try
            {
                var bannedUser = await _userRep.BanAsync(id);
                if (bannedUser.FirstName.Length == 0)
                    throw new NullReferenceException("No user with id - " + id + "!");
                return bannedUser.ToViewModel();
            }
            catch (NullReferenceException e)
            {
                _logger.Log(e.Message + "\n" + e.StackTrace);
            }
            return null;
        }

        public async Task<UserViewModel> DeleteUser(string email)
        {
            try
            {
                var deletedUser = await _userRep.DeleteAsync(email);
                if (deletedUser.FirstName.Length == 0)
                    throw new NullReferenceException("No user with email - " + email + "!");
                return deletedUser.ToViewModel();
            }
            catch (NullReferenceException e)
            {
                _logger.Log(e.Message + "\n" + e.StackTrace);
            }
            return null;
        }

        public async Task<IEnumerable<UserViewModel>> GetAllUsers()
        {
            try
            {
                var users = await _userRep.GetAllAsync();
                if (users.Count() == 0)
                    throw new NullReferenceException("There are no users!");
                return users.Select(x => x.ToViewModel());
            }
            catch (NullReferenceException e)
            {
                _logger.Log(e.Message + "\n" + e.StackTrace);
            }
            return null;
        }

        public async Task<UserViewModel> GetUser(int id)
        {
            try
            {
                var user = await _userRep.GetByIdAsync(id);
                if (user.FirstName.Length == 0)
                    throw new NullReferenceException("No user with id - " + id + "!");
                return user.ToViewModel();
            }
            catch (NullReferenceException e)
            {
                _logger.Log(e.Message + "\n" + e.StackTrace);
            }
            return null;
        }

        public async Task<UserViewModel> UnbanUser(int id)
        {
            try
            {
                var unbannedUser = await _userRep.UnbanAsync(id);
                if (unbannedUser.FirstName.Length == 0)
                    throw new NullReferenceException("No user with id - " + id + "!");
                return unbannedUser.ToViewModel();
            }
            catch (NullReferenceException e)
            {
                _logger.Log(e.Message + "\n" + e.StackTrace);
            }
            return null;
        }

        public async Task<UserViewModel> UpdateUser(UserViewModel user)
        {
            try
            {
                if (user == null)
                    throw new NullReferenceException("Missing user to update");
                var updatedUser = await _userRep.UpdateAsync(user.ToEntity());
                return updatedUser.ToViewModel();
            }
            catch (NullReferenceException e)
            {
                _logger.Log(e.Message + "\n" + e.StackTrace);
            }
            return null;
        }

        public async Task<UserViewModel> EditUser(UserViewModel user)
        {
            try
            {
                var currentUser = await _userRep.GetByIdAsync(user.Id);
                user.Email = currentUser.Email;
                user.IsBanned = currentUser.IsBanned;
                var updatedUser = await _userRep.UpdateAsync(user.ToEntity());
                return updatedUser.ToViewModel();
            }
            catch (NullReferenceException e)
            {
                _logger.Log(e.Message + "\n" + e.StackTrace);
            }
            return null;
        }

        public async Task<UserViewModel> EditUserRole(UserViewModel user)
        {
            try
            {
                var userToUpdate = await _userRep.GetByIdAsync(user.Id);
                if (userToUpdate == null)
                    throw new NullReferenceException("Missing user to update");
                userToUpdate.UserRole = user.UserRole;
                var updatedUser = await _userRep.UpdateAsync(userToUpdate);
                return updatedUser.ToViewModel();
            }
            catch (NullReferenceException e)
            {
                _logger.Log(e.Message + "\n" + e.StackTrace);
            }
            return null;
        }

        public async Task<IEnumerable<OrderViewModel>> GetUserOrders(UserViewModel user)
        {
            try
            {
                if (user == null)
                    throw new NullReferenceException("There is no user to get orders from.");
                var orders = await _orderRep.GetOrdersByUserId(user.Id);
                return orders.Select(x => x.ToViewModel());
            }
            catch(NullReferenceException e)
            {
                _logger.Log(e.Message + "\n" + e.StackTrace);
            }
            return null;
        }

        public async Task<UserViewModel> SearchUsers(string email)
        {
            try
            {
                var user = await _userRep.FindByEmailAsync(email);
                if (user == null)
                    throw new NullReferenceException("No users with email - " + email + "!");
                return user.ToViewModel();
            }
            catch (NullReferenceException e)
            {
                _logger.Log(e.Message + "\n" + e.StackTrace);
            }
            return null;
        }
    }
}