using Microsoft.AspNetCore.Http;
using NodeF.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NodeF.Content.SimpleCMS.Web.Helper
{
    public class UserHelper
    {
        public readonly NodeUser MyUser;
        public readonly bool IsLoggedIn;
        public readonly Guid MyUserId;

        public UserHelper(IHttpContextAccessor httpContextAccessor)
        {
            MyUser = httpContextAccessor.HttpContext.User as NodeUser;
            IsLoggedIn = MyUser != null;
            MyUserId = MyUser?.Id ?? Guid.Empty;
        }
    }
}
