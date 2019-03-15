using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VehicleMarket.Models;

namespace VehicleMarket.Controllers
{
    public class AdminController : Controller
    {
        VehicleBaseEntities2 context = new VehicleBaseEntities2();
        // GET: Admin
        // Zbieramy dane, wiec HTTPGET
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        
        // A teraz wysyłamy, więc post
        [HttpPost]
        public ActionResult Login(UserData givenData)
        {
            // Porównanie danych czy się zgadzają
            UserData ad = context.UserData.Where(x=> x.Login == givenData.Login && x.Password == givenData.Password).SingleOrDefault();
            if(ad!=null)
            {
                Session["admin_id"] = ad.Login.ToString();
                return RedirectToAction("Create");
            }
            else
            {
                ViewBag.error = "Chyba się nie znamy";
            }
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
    }
}