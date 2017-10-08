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

namespace VirtualStockTrading.Controllers
{
    public class SellingTablesController : Controller
    {
        private Model1 db = new Model1();

        String stockname;
        //int shareQuantity;
        int? a;
        // GET: SellingTables
        public ActionResult Index()
        {
            return View(db.SellingTables.ToList());
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
            //shareQuantity = portfolio.ShareQuantity;
            TempData["data"] = id;
            SellingTable sellingTable = new SellingTable();
            //return RedirectToAction("Details", "Portfolios", new { id = 1 });
            stockname = portfolio.StockName;
            sellingTable.StockName = portfolio.StockName;
            //TempData["data"] = stockname;


            //ViewBag.Message = stockname;
            return View(sellingTable);
        }

        // POST: SellingTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Sell([Bind(Include = "AskId,AskPrice,TimeStamp,Quantity,StockName,UserId")] SellingTable sellingTable)
        {
            //int a = shareQuantity;
            //int b = sellingTable.Quantity;
            if (ModelState.IsValid)
            {
                int a = (int)TempData["data"];
                string user = User.Identity.Name;
                var context = new IdentityDbContext();
                var uid = context.Users.FirstOrDefault(x => x.UserName == user);
                //int id = db.Portfolios.Where(x => x.StockName == sellingTable.StockName && x.UserId == uid.Id);
                Portfolio portfolio = db.Portfolios.Find(a);
                int c = portfolio.ShareQuantity;
                //StockData stockdata = db.StockDatas.Find(StockName);
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
