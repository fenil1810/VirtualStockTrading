using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VirtualStockTrading;
using VirtualStockTrading.Models;

namespace VirtualStockTrading.Controllers
{
    [CustomAuthorize]
    public class SellingTablesController : Controller
    {
        private Model1 db = new Model1();

        // GET: SellingTables
        public ActionResult Index()
        {
            string user = User.Identity.Name;
            var context = new IdentityDbContext();
            var uid = context.Users.FirstOrDefault(x => x.UserName == user);
            return View(db.SellingTables.ToList().Where(x => x.UserId == uid.Id));
        }

        // GET: SellingTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SellingTable sellingTable = db.SellingTables.Find(id);
            if (sellingTable == null)
            {
                return HttpNotFound();
            }
            return View(sellingTable);
        }

        // GET: SellingTables/Create
        public ActionResult Sell(int? id)
        {
            Portfolio portfolio = db.Portfolios.Find(id);
            TempData["data"] = id;
            SellingTable sellingTable = new SellingTable();
            sellingTable.StockName = portfolio.StockName;
            string user = User.Identity.Name;
            var context = new IdentityDbContext();
            var uid = context.Users.FirstOrDefault(x => x.UserName == user);
            sellingTable.UserId = uid.Id;
            return View(sellingTable);
        }
        
        // POST: SellingTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Sell([Bind(Include = "AskId,AskPrice,TimeStamp,Quantity,StockName,UserId")] SellingTable sellingTable)
        {
            string user = User.Identity.Name;
            var context = new IdentityDbContext();
            var uid = context.Users.FirstOrDefault(x => x.UserName == user);
            sellingTable.UserId = uid.Id;
            int intValue= 1287926608;
            sellingTable.TimeStamp = BitConverter.GetBytes(intValue); 
            if (ModelState.IsValid)
            {
                int a = (int)TempData["data"];
                Portfolio portfolio = db.Portfolios.Find(a);
                int c = portfolio.ShareQuantity;
                if (sellingTable.Quantity > portfolio.ShareQuantity)
                {
                    ViewBag.Message = "You donot have the required Quantity" + "  Available Shares =" + portfolio.ShareQuantity;
                    return View();
                }

                db.SellingTables.Add(sellingTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sellingTable);
        }
        
    }
}
