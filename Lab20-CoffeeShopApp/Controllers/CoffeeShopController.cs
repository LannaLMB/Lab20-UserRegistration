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

            return View();
        }


        public List<string> GetAllItems()
        {
            // To return a list of all cities
            CoffeeShopDBEntities CoffDB = new CoffeeShopDBEntities();



            //Lambda Expression
            return CoffDB.Items.Select(x => x.ItemID).Distinct().ToList();

        }


        public ActionResult AddItem()
        {
            return View();
        }

        // Save The New Item Added
        public ActionResult SaveNewItem(Item NewItem)
        {
            CoffeeShopDBEntities CoffDB = new CoffeeShopDBEntities();

            CoffDB.Items.Add(NewItem);

            CoffDB.SaveChanges();

            return RedirectToAction("ListItems");
        }

        // Delete Items
        public ActionResult DeleteItem(string ItemID)
        {
            try
            {
                if (ItemID == null)
                {

                    ViewBag.ErrorMessage = "Nice Try!";
                    return View("ErrorMessages");
                }


                CoffeeShopDBEntities CoffDB = new CoffeeShopDBEntities();

                // 1. Find the Item that I need to delete

                Item ToDelete = CoffDB.Items.Find(ItemID);

                if (ToDelete == null)
                {
                    ViewBag.ErrorMessage = "Hahahaha";
                    return View("ErrorMessages");
                }


                // 2. Remove the object from the list of Items
                CoffDB.Items.Remove(ToDelete);


                // 3. Perform the changes onto the DB
                CoffDB.SaveChanges(); // save changes to DB


                // Execute the ListItems Action
                return RedirectToAction("ListItems", "CoffeeShop");
            }

            catch (System.Data.Entity.Infrastructure.DbUpdateException ex)
            {
                ViewBag.ErrorMessage = "You Cannot Delete an Item With an ID!";

                return View("ErrorMessages");
            }

            catch (Exception ex)
            {

                ViewBag.ErrorMessage = "Something Horrible Happened";

                return View("ErrorMessages");
            }
        }

        // Update Items
        public ActionResult UpdateItem(string ItemID)
        {
            CoffeeShopDBEntities CoffDB = new CoffeeShopDBEntities();

            Item ToFind = CoffDB.Items.Find(ItemID);

            return View("ItemDetails", ToFind);
        }


        // Save Updated Items
        public ActionResult SaveUpdates(Item ToBeUpdated)
        {
            CoffeeShopDBEntities CoffDB = new CoffeeShopDBEntities();

            // Find the Original Customer Record
            Item ToFind = CoffDB.Items.Find(ToBeUpdated.ItemID);

            ToFind.ItemID = ToBeUpdated.ItemID;

            ToFind.Name = ToBeUpdated.Name;

            ToFind.Description = ToBeUpdated.Description;

            ToFind.Quantity = ToBeUpdated.Quantity;

            ToFind.Price = ToBeUpdated.Price;


            CoffDB.SaveChanges();

            return RedirectToAction("ListItems");
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
