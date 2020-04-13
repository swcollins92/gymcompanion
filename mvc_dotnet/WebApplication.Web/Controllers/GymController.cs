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
using WebApplication.Web.Models.MemberInfo;

namespace WebApplication.Web.Controllers
{
    public class GymController : Controller
    {
        private readonly IGymDAL gymDAL;
        private readonly IMemberDAL memberDAL;
        private readonly IAuthProvider authProvider;
        private readonly IUserDAL userDAL;

        public GymController(IAuthProvider authProvider, IGymDAL gymDAL, IMemberDAL memberDAL, IUserDAL userDAL)
        {
            this.authProvider = authProvider;
            this.gymDAL = gymDAL;
            this.memberDAL = memberDAL;
            this.userDAL = userDAL;
        }

        public IActionResult Index()
        {
            return View();
        }

        [AuthorizationFilter("Admin", "Employee")]
        [HttpGet]
        public IActionResult AddGymEquipment()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddGymEquipment(GymEquipment model)
        {
            if (ModelState.IsValid)
            {
                gymDAL.AddGymEquipment(model);
            }

            return RedirectToAction(nameof(ViewEquipments));
        }

        [HttpGet]
        public IActionResult ViewEquipments()
        {
            ViewEquipmentsModel model = new ViewEquipmentsModel();
            model.AllEquipments = gymDAL.GetEquipments();
            return View(model);
        }

        [AuthorizationFilter("Admin", "Employee")]
        [HttpGet]
        public IActionResult EditGymEquipment()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EditGymEquipment(EditGymEquipment model)
        {
            if (ModelState.IsValid)
            {
                gymDAL.EditGymEquipment(model);
                return RedirectToAction(nameof(ViewEquipments));
            }

            return View(model);
        }
        //TODO: Session with edit equipment. 
        //TODO: Also with users added in sql they do not show in view profile
    }
}