﻿using Microsoft.AspNet.Identity.EntityFramework;
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

namespace VirtualStockTrading.MVC_Controllers
{
    [CustomAuthorize]
    public class PortfoliosController : Controller
    {
        private Model1 db = new Model1();
        public ActionResult Sell(int? id)
        {
            //return View();
            return RedirectToAction("Sell", "SellingTables", new { id = id });
        }
        // GET: Portfolios/Details/5
        public ActionResult Details()
        {
            try
            {
                string s = User.Identity.Name;
                var context = new IdentityDbContext();
                var uid = context.Users.FirstOrDefault(x => x.Email == s);
                string id = uid.Id;
                return View(db.Portfolios.Where(x=>x.UserId==id).ToList());
            }
            catch
            {
                return HttpNotFound();
                
            }
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