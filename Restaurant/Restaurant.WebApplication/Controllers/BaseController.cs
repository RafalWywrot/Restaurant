using Microsoft.AspNet.Identity;
using Restaurant.Database;
using Restaurant.WebApplication.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Restaurant.WebApplication.Controllers
{
    public class BaseController : Controller
    {
        private AuthenticationUserManager authenticationUserManager { get; }
        public BaseController(AuthenticationUserManager authenticationUserManager)
        {
            this.authenticationUserManager = authenticationUserManager;
        }
        // GET: Base
        protected ApplicationUser GetUser()
        {
            return authenticationUserManager.Users.First(x => x.Id == User.Identity.GetUserId());
        }
    }
}