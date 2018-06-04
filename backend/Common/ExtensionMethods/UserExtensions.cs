using System;
using Core;
using MasyvaiPrasidedaVienetu.Models;

namespace MasyvaiPrasidedaVienetu.WebEndpoints.ExtensionMethods
{
    public static class UserExtenions
    {
        public static UserViewModel ToViewModel(this User user)
        {
            UserViewModel parsedUser;
            try
            {
                parsedUser = new UserViewModel
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    SecondName = user.SecondName,
                    Email = user.Email,
                    PasswordHash = user.PasswordHash,
                    City = user.City,
                    Zip = user.Zip,
                    Street = user.Street,
                    HouseNumber = user.HouseNumber,
                    PhoneNumber = user.PhoneNumber,
                    IsBanned = user.IsBanned,
                    UserRole = user.UserRole,
                };
            }
            catch (Exception)
            {
                parsedUser = new UserViewModel();
            }
            return parsedUser;
        }

        public static User ToEntity(this UserViewModel user)
        {
            User parsedUser;
            try
            {
                parsedUser = new User
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    SecondName = user.SecondName,
                    Email = user.Email,
                    PasswordHash = user.PasswordHash,
                    City = user.City,
                    Zip = user.Zip,
                    Street = user.Street,
                    HouseNumber = user.HouseNumber,
                    PhoneNumber = user.PhoneNumber,
                    IsBanned = user.IsBanned,
                    UserRole = user.UserRole,
                };
            }
            catch (Exception)
            {
                parsedUser = new User();
            }
            return parsedUser;
        }
    }
}