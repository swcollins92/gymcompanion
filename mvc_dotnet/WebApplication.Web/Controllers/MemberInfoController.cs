using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Web.Providers.Auth;
using WebApplication.Web.DAL;
using WebApplication.Web.Models;
using WebApplication.Web.Models.GymDetails;
using WebApplication.Web.Models.Account;

namespace WebApplication.Web.Controllers
{
    public class MemberInfoController : Controller
    {
        private readonly IGymDAL gymDAL;
        private readonly IAuthProvider authProvider;
        public MemberInfoController(IAuthProvider authProvider, IGymDAL gymDAL)
        {
            this.authProvider = authProvider;
            this.gymDAL = gymDAL;
        }

        public IActionResult Index()
        {
            return View();
        }

        [AuthorizationFilter("Admin")]
        [HttpGet]
        public IActionResult EditSchedule()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EditSchedule(EditSchedule model)
        {
            if (ModelState.IsValid)
            {
                gymDAL.EditSchedule(model);
                return RedirectToAction(nameof(ViewSchedule));
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult ViewSchedule()
        {
            return View();
        }
    }
}