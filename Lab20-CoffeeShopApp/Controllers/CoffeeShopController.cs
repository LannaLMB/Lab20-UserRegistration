using Lab20_CoffeeShopApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab20_CoffeeShopApp.Controllers
{
    public class CoffeeShopController : Controller
    {
        // GET: CoffeeShop
        public ActionResult ListItems()
        {
            CoffeeShopDBEntities CoffDB = new CoffeeShopDBEntities();


            List<Item> ItemList = CoffDB.Items.ToList();
            ViewBag.ItemList= ItemList;
            ViewBag.Names = GetName();

            return View("Home/Index");
        }


        public List<string> GetAllItems()
        {
            // To return a list of all cities
            CoffeeShopDBEntities CoffDB = new CoffeeShopDBEntities();



            //Lambda Expression
            return CoffDB.Items.Select(x => x.ItemID).Distinct().ToList();

        }



        // Search for the Name of a Coffee in the Drop Down Box
        public ActionResult SearchItem(string Name)
        {
            CoffeeShopDBEntities CoffDB = new CoffeeShopDBEntities();

            List<Item> ItemList = CoffDB.Items.Where(x => x.Name != null && x.Name.ToUpper().
            Contains(Name.ToUpper())).ToList();


            ViewBag.Names = GetName();

            ViewBag.ItemList = ItemList;

            return View("ListItems");

        }


        public List<string> GetName()
        {
            // To return a list of all cities
            CoffeeShopDBEntities CoffDB = new CoffeeShopDBEntities();



            //Lambda Expression
            return CoffDB.Items.Select(x => x.ItemID).Distinct().ToList();

        }


        // GET: CoffeeShop/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CoffeeShop/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CoffeeShop/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CoffeeShop/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CoffeeShop/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CoffeeShop/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CoffeeShop/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
