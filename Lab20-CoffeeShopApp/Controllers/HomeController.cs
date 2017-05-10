using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab20_CoffeeShopApp.Models;

namespace Lab20_CoffeeShopApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public ActionResult UserReg()
        {

            return View();
        }


        public ActionResult AddUser(UserInfo NewUser)
        {
            // validation
            // to add data from the model to the db


            // Pass the NewUser model to the AddUser view
            return View(NewUser);
        }
    }
}