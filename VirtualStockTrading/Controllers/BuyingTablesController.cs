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

        //BuyingTable buyingtable = new BuyingTable();
        private Model1 db = new Model1();

        // GET: BuyingTables
        public ActionResult Index()
        {
            return View(db.BuyingTables.ToList());
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

            IEnumerable<SelectListItem> items = db.StockDatas
              .Select(c => new SelectListItem
              {
                  Value = c.StockName.ToString(),
                  Text = c.StockName
              });
            ViewBag.StockDatas = items;
            return View();
        }

        // POST: BuyingTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BidId,BidPrice,TimeStamp,Quantity,StockName,PriceType,UserId")] BuyingTable buyingTable)
        {
            if (ModelState.IsValid)
            {
                DateTime now = DateTime.Now;
                var StockName = buyingTable.StockName;
                StockData stockdata = db.StockDatas.Find(StockName);
                if (buyingTable.Quantity > stockdata.TotalVolume)
                {
                    ViewBag.Message = "The Number of Shares you want are not available in the Market" + "  Available Volume =" + stockdata.TotalVolume;


                    IEnumerable<SelectListItem> items = db.StockDatas
                      .Select(c => new SelectListItem
                      {
                          Value = c.StockName.ToString(),
                          Text = c.StockName
                      });
                    ViewBag.StockDatas = items;

                    return View();
                }
                if (buyingTable.PriceType == "Market Price")
                {
                    buyingTable.BidPrice = stockdata.MarketPrice;
                }

                db.BuyingTables.Add(buyingTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(buyingTable);
        }
        
    }
}
