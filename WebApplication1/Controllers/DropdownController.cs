using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Context;

namespace WebApplication1.Controllers
{
    public class DropdownController : Controller
    {
        dropdownEntities con = new dropdownEntities();

        


        // GET: Dropdown
        public ActionResult Details()
        {
            var country = con.Countries.ToList();
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem { Text = "-----Select Country---", Value = "0" });
            foreach (var x in country)
            {
                list.Add(new SelectListItem { Text = x.Country1 , Value=x.CountryID.ToString()});
                ViewBag.country = list;
            }
            return View();
        }
        public JsonResult getState(int id)
        {
            var state = con.States.Where(x => x.CountryID == id).ToList();
            List<SelectListItem> s = new List<SelectListItem>();
            s.Add(new SelectListItem { Text = "-----Select State-----", Value = "0" });
            if (state != null)
            {

                foreach (var x in state)
                {
                        s.Add(new SelectListItem { Text = x.State1, Value = x.State_ID.ToString() });

                }
            }
            return Json(new SelectList(s,"Value","Text",JsonRequestBehavior.AllowGet));
        }
        public JsonResult getCity(int id)
        {
            var city = con.Cities.Where(x => x.State_ID == id).ToList();
            List<SelectListItem> ci = new List<SelectListItem>();
            ci.Add(new SelectListItem { Text = "-----Select City-----", Value = "0" });
            if (city != null)
            {
                foreach (var c in city)
                {
                    ci.Add(new SelectListItem { Text = c.City1, Value = c.City_ID.ToString() });
                }
            }
            return Json(new SelectList(ci,"Value","Text",JsonRequestBehavior.AllowGet));
        }
    }
   
}