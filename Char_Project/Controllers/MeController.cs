
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Mapping;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Char_Project.Models;

namespace Char_Project.Controllers
{
    public class MeController : Controller
    {
        // GET: Me
        RelationEntities1 entities1= new RelationEntities1();
        public ActionResult Index()
        {
            var countrylist = entities1.countries.ToList();
            return View(countrylist);
        }
        [HttpPost]
        public JsonResult CountryData(country data)
        {
            decimal result = 0;
            try
            {
                var list = entities1.countries.Where(l => l.countryName == data.countryName).FirstOrDefault();
                if (list!=null)
                {
                    if (list.countryName == data.countryName)
                    {
                        result = 1;
                    }
                    else if (list.countryCode == data.countryCode)
                    {
                        result = 1;
                    }
                    else
                    {
                        result = 0;
                    }
                }
                else
                {
                    entities1.countries.Add(data);
                    entities1.SaveChanges();
                }
            }
            catch (Exception ex)
            {

            }
            return Json(result,JsonRequestBehavior.AllowGet);
        }
        public PartialViewResult Login()
        {
            return PartialView();
        }
        [HttpPost]
        public JsonResult Edit(country data,int id)
        {
            decimal result = 0;
            var list1 = entities1.countries.Where(l => l.Id == id).SingleOrDefault();
            if (list1 !=null)
            {
                list1.countryName=data.countryName;
                list1.countryCode=data.countryCode;
                entities1.SaveChanges();
                result = 1;
            }
            return Json(result,JsonRequestBehavior.AllowGet);
        }
    }
}