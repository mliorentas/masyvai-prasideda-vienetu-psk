using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using Common;
using MasyvaiPrasidedaVienetu.Interfaces;
using MasyvaiPrasidedaVienetu.Models;
using Services.Attributes;

namespace MasyvaiPrasidedaVienetu.WebEndpoints.Controllers
{
    [RoutePrefix("user")]
    public class UserController : ApiController
    {
        private IUserService _userService;
        private ISessionService _sessionService;
        
        public UserController(IUserService userService, ISessionService sessionService)
        {
            _userService = userService;
            _sessionService = sessionService;
        }

        [HttpGet]
        [Route("{personId}")]
        [RequireRoleAccess(UserRole.Admin)]
        public async Task<IHttpActionResult> GetUserById(int personId)
        {
            var user = await _userService.GetUser(personId);
            return Ok(user);
        }

        [HttpGet]
        [Route("currentUser")]
        [RequireRoleAccess(UserRole.LoggedIn)]
        public async Task<IHttpActionResult> GetUserBySessionHash()
        {
            var user = await _sessionService.GetUserBySessionHash();
            return Ok(user);
        }

        [HttpPost]
        [Route("add")]
        public async Task<IHttpActionResult> AddUser(UserViewModel user)
        {
            user.UserRole = 0;
            user.IsBanned = false;
            var userViewModel = await _userService.AddUser(user);
            return Ok(userViewModel);

        }

        [HttpDelete]
        [Route("delete/{email}")]
        [RequireRoleAccess(UserRole.Admin)]
        public async Task<IHttpActionResult> DeleteUser(string email)
        {
            var userViewModel = await _userService.DeleteUser(email);
            return Ok(userViewModel);
        }

        [HttpPut]
        [Route("edit")]
        [RequireRoleAccess(UserRole.LoggedIn)]
        public async Task<IHttpActionResult> EditUser(UserViewModel user)
        {
            var updatedUser = await _userService.EditUser(user);
            if (updatedUser == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return Ok(updatedUser);
        }

        [HttpPut]
        [Route("changeRole")]
        [RequireRoleAccess(UserRole.LoggedIn)]
        public async Task<IHttpActionResult> EditUserRole(UserViewModel user)
        {
            var userViewModel = await _userService.EditUserRole(user);
            return Ok(userViewModel);
        }

        [HttpPut]
        [Route("update")]
        [RequireRoleAccess(UserRole.Admin)]
        public async Task<IHttpActionResult> UpdateUser(UserViewModel user)
        {
            var updatedUser = await _userService.UpdateUser(user);
            if (updatedUser == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return Ok(updatedUser);
        }

        [HttpGet]
        [Route("all")]
        [RequireRoleAccess(UserRole.Admin)]
        public async Task<IHttpActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsers();
            if (users == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return Ok(users);
        }

        [HttpPut]
        [Route("ban")]
        [RequireRoleAccess(UserRole.Admin)]
        public async Task<IHttpActionResult> BanUser(int id)
        {
            var user = await _userService.BanUser(id);
            if (user == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return Ok(user);
        }

        [HttpPut]
        [Route("unban")]
        [RequireRoleAccess(UserRole.Admin)]
        public async Task<IHttpActionResult> UnbanUser(int id)
        {
            var user = await _userService.UnbanUser(id);
            if (user == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return Ok(user);
        }

        [HttpGet]
        [Route("search/{email}")]
        [RequireRoleAccess(UserRole.LoggedIn)]
        public async Task<IHttpActionResult> SearchUsers(string email)
        {
            var users = await _userService.SearchUsers(email);
            if (users == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return Ok(users);
        }

        [HttpGet]
        [Route("myOrders")]
        [RequireRoleAccess(UserRole.LoggedIn)]
        public async Task<IHttpActionResult> GetUserOrders()
        {
            var currentUser = await _sessionService.GetUserBySessionHash();
            var orders = await _userService.GetUserOrders(currentUser);
            return Ok(orders);
        }
    }
}