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
    public class BuyingTablesController : Controller
    {

        //BuyingTable buyingtable = new BuyingTable();
        private Model1 db = new Model1();

        // GET: BuyingTables
        public ActionResult Index()
        {
            string user = User.Identity.Name;
            var context = new IdentityDbContext();
            var uid = context.Users.FirstOrDefault(x => x.UserName == user);
            return View(db.BuyingTables.ToList().Where(x=>x.UserId==uid.Id));
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
            BuyingTable buyingTable = new BuyingTable();
            string user = User.Identity.Name;
            var context = new IdentityDbContext();
            var uid = context.Users.FirstOrDefault(x => x.UserName == user);
            buyingTable.UserId = uid.Id;
            IEnumerable<SelectListItem> items = db.StockDatas
              .Select(c => new SelectListItem
              {
                  Value = c.StockName.ToString(),
                  Text = c.StockName
              });
            ViewBag.StockDatas = items;
            return View(buyingTable);
        }

        // POST: BuyingTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BidId,BidPrice,TimeStamp,Quantity,StockName,PriceType,UserId")] BuyingTable buyingTable)
        {
            int intValue = 1287926608;
            buyingTable.TimeStamp = BitConverter.GetBytes(intValue);
            if (ModelState.IsValid)
            {
                try
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

                        return View(buyingTable);
                    }
                }
                catch
                {
                    IEnumerable<SelectListItem> items = db.StockDatas
                         .Select(c => new SelectListItem
                         {
                             Value = c.StockName.ToString(),
                             Text = c.StockName
                         });
                    ViewBag.StockDatas = items;
                    return View(buyingTable);
                }
            
                if (buyingTable.PriceType == "Market Price")
                {
                   // buyingTable.BidPrice = stockdata.MarketPrice;
                }

                db.BuyingTables.Add(buyingTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                IEnumerable<SelectListItem> items = db.StockDatas
                     .Select(c => new SelectListItem
                     {
                         Value = c.StockName.ToString(),
                         Text = c.StockName
                     });
                ViewBag.StockDatas = items;
                return View(buyingTable);

            }
//            return View(buyingTable);
        }
        
    }
}
