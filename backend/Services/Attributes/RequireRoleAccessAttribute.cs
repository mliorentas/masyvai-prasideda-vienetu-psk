using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using Common;
using Common.AsyncHelper;
using MasyvaiPrasidedaVienetu.Interfaces;
using MasyvaiPrasidedaVienetu.Services;

namespace Services.Attributes
{
    public class RequireRoleAccessAttribute : AuthorizeAttribute
    {
        private int _role;
        private ISessionService _session;

        public RequireRoleAccessAttribute(UserRole role)
        {
            _role = (int)role;
            _session = new SessionService();
        }

        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            try
            {
                return AsyncHelpers.RunSync<bool>(() => _session.ValidateSession(_role));
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
