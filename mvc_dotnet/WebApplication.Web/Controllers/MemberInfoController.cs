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
    public class MemberInfoController : Controller
    {
        private readonly IGymDAL gymDAL;
        private readonly IMemberDAL memberDAL;
        private readonly IAuthProvider authProvider;
        private readonly IUserDAL userDAL;
        public MemberInfoController(IAuthProvider authProvider, IGymDAL gymDAL, IMemberDAL memberDAL, IUserDAL userDAL)
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
        public IActionResult AddSchedule()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddSchedule(EditSchedule model)
        {
            if (ModelState.IsValid)
            {
                gymDAL.AddSchedule(model);
                return RedirectToAction(nameof(ViewSchedules));
            }

            return View(model);
        }
        
        [AuthorizationFilter("Admin", "Employee")]
        [HttpGet]
        public IActionResult EditSchedule(int id)
        {
            EditSchedule model = new EditSchedule();
            model = gymDAL.GetScheduleById(id);
            return View(model);
        }


        [HttpPost]
        public IActionResult EditSchedule(EditSchedule model)
        {
            if (ModelState.IsValid)
            {
                gymDAL.EditSchedule(model);
                return RedirectToAction(nameof(ViewSchedules));
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult ViewSchedules()
        {
            ViewScheduleModel model = new ViewScheduleModel();
            model.AllSchedules = gymDAL.GetSchedules();
            return View(model);
        }

        [HttpGet]
        public IActionResult MemberTimelog()
        {
            Timelog model = new Timelog();
            User user = authProvider.GetCurrentUser();
            if (user.Role.ToLower() == "member")
            {
                model.MemberId = user.Id;
                model.IsCheckedIn = memberDAL.CheckedInStatusButNotCheckedOut(user.Id);
            }

            return View(model);
        }
    
        [HttpGet]
        public IActionResult CheckIn(int id)
        {
            
            if (!memberDAL.CheckedInStatusButNotCheckedOut(id))
            {
                memberDAL.CheckIn(id);
            }

            User user = authProvider.GetCurrentUser();
            
            if(user.Role == "Employee")
            {
                return RedirectToAction(nameof(EmployeeTimelog));
            }

            return RedirectToAction(nameof(MemberTimelog));
        }

        [HttpGet]
        public IActionResult CheckOut(int id)
        {
            if (memberDAL.CheckedInStatusButNotCheckedOut(id))
            {
                memberDAL.CheckOut(id);
            }

            User user = authProvider.GetCurrentUser();

            if (user.Role == "Employee")
            {
                return RedirectToAction(nameof(EmployeeTimelog));
            }

            return RedirectToAction(nameof(MemberTimelog));

        }

        [AuthorizationFilter("Employee")]
        [HttpGet]
        public IActionResult EmployeeTimelog()
        {
            Timelog model = new Timelog();
            IList<User> list = userDAL.GetMembers();
            model.AllMembers = memberDAL.UsersListForDropdown(list);

            return View(model);
        }
        
        [HttpPost]
        public IActionResult EmployeeTimelog(Timelog model)
        {
            if (model.IsCheckedIn)
            {
                memberDAL.CheckOut(model.MemberId);
            }
            else
            {
                memberDAL.CheckIn(model.MemberId);
            }

            return RedirectToAction(nameof(EmployeeTimelog));
        }

        [HttpGet]
        public IActionResult MemberVisitMetrics(int id)
        {
            ViewVisitMetrics model = new ViewVisitMetrics();
            model.AllVisitMetrics = memberDAL.TimeAtGym(id);
            model.AverageDuration = memberDAL.GetAverageDurationForAMember(id);
            
            return View(model);
        }

        [HttpGet]
        public IActionResult MemberWorkoutMetrics(int id)
        {
            ViewWorkoutMetrics model = new ViewWorkoutMetrics();
            model.AllMetrics = memberDAL.GetAllMetricsById(id);
            model.TimeSpent = memberDAL.GetAverageDurationForAMember(id);
            return View(model);
        }

        [HttpGet]
        public IActionResult Tim(Timelog model)
        {
            return RedirectToAction(nameof(MemberWorkoutMetrics), new { id = model.MemberId});
        }
    }
}