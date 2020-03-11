using ScholarshipHub.Interfaces;
using ScholarshipHub.Models;
using ScholarshipHub.Repository;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ScholarshipHub.Controllers
{
    public class RegistrationController : Controller
    {
        IOrganisationRepository OrgRepo = new OrganisationRepository();
        IUserRepository userRepo = new UserRepository();
       [HttpGet]
        public ActionResult OrganizationRegistration()
        {
            return View();
        }
        [HttpPost]
        public ActionResult OrganizationRegistration(Organisation org)
        {

            try
            {

                var user = new User()
                {
                    Username = org.Username,
                    Password = org.Password,
                    Status = 3
                };

                if (userRepo.GetUser(user) != null)
                {
                    TempData["error"] = "User Already exists!!!";
                    return RedirectToAction("OrganizationRegistration");
                }


                string fileName1 = Path.GetFileNameWithoutExtension(org.ApprovalFile.FileName);
                string extension1 = Path.GetExtension(org.ApprovalFile.FileName);
                fileName1 = fileName1 + DateTime.Now.ToString("yymmssfff") + extension1;
                org.ApprovalPath =  fileName1;
                fileName1 = Path.Combine(Server.MapPath("~/Organization/Approval/"), fileName1);
                org.ApprovalFile.SaveAs(fileName1);

                string fileName2 = Path.GetFileNameWithoutExtension(org.InformationFile.FileName);
                string extension2 = Path.GetExtension(org.InformationFile.FileName);
                fileName2 = fileName2 + DateTime.Now.ToString("yymmssfff") + extension2;
                org.Information = fileName2;
                fileName2 = Path.Combine(Server.MapPath("~/Organization/Information/"), fileName2);
                org.InformationFile.SaveAs(fileName2);



                OrgRepo.Insert(org);
                userRepo.Insert(user);

                ModelState.Clear();
                return RedirectToAction("Login");
            }
            catch
            {
                TempData["error"] = "NULL Value OF Some Filed!";
                return RedirectToAction("OrganizationRegistration");

            }






        }
        [HttpGet]
        public ActionResult Login()
        {
            return RedirectToAction("Index","Login");
        }

    }
}