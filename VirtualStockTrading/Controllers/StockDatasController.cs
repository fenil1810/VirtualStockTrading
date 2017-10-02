using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VirtualStockTrading;

namespace VirtualStockTrading.MVC_Controllers
{
    public class StockDatasController : Controller
    {
        private Model1 db = new Model1();

        // GET: StockDatas
        public ActionResult Index()
        {
            return View(db.StockDatas.ToList());
        }

        // GET: StockDatas/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockData stockData = db.StockDatas.Find(id);
            if (stockData == null)
            {
                return HttpNotFound();
            }
            return View(stockData);
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
