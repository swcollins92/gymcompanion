﻿using System;
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
        public MemberInfoController(IAuthProvider authProvider, IGymDAL gymDAL, IMemberDAL memberDAL)
        {
            this.authProvider = authProvider;
            this.gymDAL = gymDAL;
            this.memberDAL = memberDAL;
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
                model.IsCheckedIn = false;
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult CheckIn(int id)
        {
            if (!memberDAL.CheckedInStatus(id))
            {
                memberDAL.CheckIn(id);
            }

            return RedirectToAction(nameof(MemberTimelog));
        }

        [HttpGet]
        public IActionResult CheckOut(int id)
        {
            if (memberDAL.CheckedInStatus(id))
            {
                memberDAL.CheckOut(id);
            }
            
            return RedirectToAction(nameof(MemberTimelog));
        }

        //[HttpGet]
        //public IActionResult LogInSummary()
        //{

        //}
    }
}