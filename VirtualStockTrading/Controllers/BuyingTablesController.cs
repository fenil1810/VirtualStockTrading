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
    public class BuyingTablesController : Controller
    {
        private Model1 db = new Model1();

        public string PriceType { get; set; } 

        // GET: BuyingTables
        public ActionResult Index()
        {
            var buyingTables = db.BuyingTables.Include(b => b.StockData).Include(b => b.UserInformation);
            return View(buyingTables.ToList());
        }

        // GET: BuyingTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BuyingTable buyingTable = db.BuyingTables.Find(id);
            if (buyingTable == null)
            {
                return HttpNotFound();
            }
            return View(buyingTable);
        }

        // GET: BuyingTables/Create
        public ActionResult Create()
        {
            ViewBag.StockName = new SelectList(db.StockDatas, "StockName", "StockType");
            ViewBag.UserId = new SelectList(db.UserInformations, "UserId", "FirstName");
            return View();
        }

        // POST: BuyingTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BidId,BidPrice,TimeStamp,Quantity,StockName,PriceType,UserId")] BuyingTable buyingTable)
        {
            if (ModelState.IsValid)
            {
                db.BuyingTables.Add(buyingTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StockName = new SelectList(db.StockDatas, "StockName", "StockType", buyingTable.StockName);
            ViewBag.UserId = new SelectList(db.UserInformations, "UserId", "FirstName", buyingTable.UserId);
            return View(buyingTable);
        }

        // GET: BuyingTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BuyingTable buyingTable = db.BuyingTables.Find(id);
            if (buyingTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.StockName = new SelectList(db.StockDatas, "StockName", "StockType", buyingTable.StockName);
            ViewBag.UserId = new SelectList(db.UserInformations, "UserId", "FirstName", buyingTable.UserId);
            return View(buyingTable);
        }

        // POST: BuyingTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BidId,BidPrice,TimeStamp,Quantity,StockName,PriceType,UserId")] BuyingTable buyingTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(buyingTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StockName = new SelectList(db.StockDatas, "StockName", "StockType", buyingTable.StockName);
            ViewBag.UserId = new SelectList(db.UserInformations, "UserId", "FirstName", buyingTable.UserId);
            return View(buyingTable);
        }

        // GET: BuyingTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BuyingTable buyingTable = db.BuyingTables.Find(id);
            if (buyingTable == null)
            {
                return HttpNotFound();
            }
            return View(buyingTable);
        }

        // POST: BuyingTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BuyingTable buyingTable = db.BuyingTables.Find(id);
            db.BuyingTables.Remove(buyingTable);
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
