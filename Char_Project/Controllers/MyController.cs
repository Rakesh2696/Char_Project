using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Char_Project.Models;

namespace Char_Project.Controllers
{
    public class MyController : Controller
    {
        rockEntities RockEntities=new rockEntities();
        // GET: My
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult login()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Register(login regdata)
        {
            bool result = false;
            try
            {
                RockEntities.logins.Add(regdata);
                RockEntities.SaveChanges();
                result = true;
            }
            catch (Exception ex)
            {

            }

            return Json(result, JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
       public JsonResult login (login logindata)
        {
            bool result = false;
          login log=  RockEntities.logins.Where(l => l.UserName == logindata.UserName && l.Password == logindata.Password).FirstOrDefault();
            if(log!= null)
            {
               result= true;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Register()
        {
            return View();
        }
       
    }
}