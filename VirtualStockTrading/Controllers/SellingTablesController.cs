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
            //return RedirectToAction("Details", "Portfolios", new { id = 1 });

            var stockname = portfolio.StockName;
            ViewBag.Message = stockname;
            return View();
        }

        // POST: SellingTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Sell([Bind(Include = "AskId,AskPrice,TimeStamp,Quantity,StockName,UserId")] SellingTable sellingTable)
        {
            if (ModelState.IsValid)
            {
                sellingTable.StockName = stockname;
                db.SellingTables.Add(sellingTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sellingTable);
        }

        // GET: SellingTables/Edit/5
        public ActionResult Edit(int? id)
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

        // POST: SellingTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AskId,AskPrice,TimeStamp,Quantity,StockName,UserId")] SellingTable sellingTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sellingTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sellingTable);
        }

        // GET: SellingTables/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: SellingTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SellingTable sellingTable = db.SellingTables.Find(id);
            db.SellingTables.Remove(sellingTable);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
