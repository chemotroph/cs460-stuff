using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Lab6.DAL;
using Lab6.Models;
using Lab6.ViewModels;

namespace Lab6.Controllers
{
    public class StockItemsController : Controller
    {
        private WorldWideImportersContext db = new WorldWideImportersContext();


        public ActionResult Index()
        {
            var stockItems = db.StockItems.Include(s => s.Color).Include(s => s.PackageType).Include(s => s.PackageType1).Include(s => s.Person).Include(s => s.StockItemHolding).Include(s => s.Supplier);
            return View(stockItems.ToList());
        }

        [HttpGet]
        public ActionResult Index(string searchTerm)
        {
            return View(db.StockItems.Where(x => x.StockItemName.Contains(searchTerm)).ToList());
        }



        // GET: StockItems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockItem stockItem = db.StockItems.Find(id);
            salesStats stats = new salesStats(id, db);

            if (stockItem == null)
            {
                return HttpNotFound();
            }
            StockItemViewModel viewModel = new StockItemViewModel(stockItem, stats);
            return View(viewModel);
        }

        // GET: StockItems/Create
        public ActionResult Create()
        {
            ViewBag.ColorID = new SelectList(db.Colors, "ColorID", "ColorName");
            ViewBag.OuterPackageID = new SelectList(db.PackageTypes, "PackageTypeID", "PackageTypeName");
            ViewBag.UnitPackageID = new SelectList(db.PackageTypes, "PackageTypeID", "PackageTypeName");
            ViewBag.LastEditedBy = new SelectList(db.People, "PersonID", "FullName");
            ViewBag.StockItemID = new SelectList(db.StockItemHoldings, "StockItemID", "BinLocation");
            ViewBag.SupplierID = new SelectList(db.Suppliers, "SupplierID", "SupplierName");
            return View();
        }

        // POST: StockItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StockItemID,StockItemName,SupplierID,ColorID,UnitPackageID,OuterPackageID,Brand,Size,LeadTimeDays,QuantityPerOuter,IsChillerStock,Barcode,TaxRate,UnitPrice,RecommendedRetailPrice,TypicalWeightPerUnit,MarketingComments,InternalComments,Photo,CustomFields,Tags,SearchDetails,LastEditedBy,ValidFrom,ValidTo")] StockItem stockItem)
        {
            if (ModelState.IsValid)
            {
                db.StockItems.Add(stockItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ColorID = new SelectList(db.Colors, "ColorID", "ColorName", stockItem.ColorID);
            ViewBag.OuterPackageID = new SelectList(db.PackageTypes, "PackageTypeID", "PackageTypeName", stockItem.OuterPackageID);
            ViewBag.UnitPackageID = new SelectList(db.PackageTypes, "PackageTypeID", "PackageTypeName", stockItem.UnitPackageID);
            ViewBag.LastEditedBy = new SelectList(db.People, "PersonID", "FullName", stockItem.LastEditedBy);
            ViewBag.StockItemID = new SelectList(db.StockItemHoldings, "StockItemID", "BinLocation", stockItem.StockItemID);
            ViewBag.SupplierID = new SelectList(db.Suppliers, "SupplierID", "SupplierName", stockItem.SupplierID);
            return View(stockItem);
        }

        // GET: StockItems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockItem stockItem = db.StockItems.Find(id);
            if (stockItem == null)
            {
                return HttpNotFound();
            }
            ViewBag.ColorID = new SelectList(db.Colors, "ColorID", "ColorName", stockItem.ColorID);
            ViewBag.OuterPackageID = new SelectList(db.PackageTypes, "PackageTypeID", "PackageTypeName", stockItem.OuterPackageID);
            ViewBag.UnitPackageID = new SelectList(db.PackageTypes, "PackageTypeID", "PackageTypeName", stockItem.UnitPackageID);
            ViewBag.LastEditedBy = new SelectList(db.People, "PersonID", "FullName", stockItem.LastEditedBy);
            ViewBag.StockItemID = new SelectList(db.StockItemHoldings, "StockItemID", "BinLocation", stockItem.StockItemID);
            ViewBag.SupplierID = new SelectList(db.Suppliers, "SupplierID", "SupplierName", stockItem.SupplierID);
            return View(stockItem);
        }

        // POST: StockItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StockItemID,StockItemName,SupplierID,ColorID,UnitPackageID,OuterPackageID,Brand,Size,LeadTimeDays,QuantityPerOuter,IsChillerStock,Barcode,TaxRate,UnitPrice,RecommendedRetailPrice,TypicalWeightPerUnit,MarketingComments,InternalComments,Photo,CustomFields,Tags,SearchDetails,LastEditedBy,ValidFrom,ValidTo")] StockItem stockItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stockItem).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ColorID = new SelectList(db.Colors, "ColorID", "ColorName", stockItem.ColorID);
            ViewBag.OuterPackageID = new SelectList(db.PackageTypes, "PackageTypeID", "PackageTypeName", stockItem.OuterPackageID);
            ViewBag.UnitPackageID = new SelectList(db.PackageTypes, "PackageTypeID", "PackageTypeName", stockItem.UnitPackageID);
            ViewBag.LastEditedBy = new SelectList(db.People, "PersonID", "FullName", stockItem.LastEditedBy);
            ViewBag.StockItemID = new SelectList(db.StockItemHoldings, "StockItemID", "BinLocation", stockItem.StockItemID);
            ViewBag.SupplierID = new SelectList(db.Suppliers, "SupplierID", "SupplierName", stockItem.SupplierID);
            return View(stockItem);
        }

        // GET: StockItems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockItem stockItem = db.StockItems.Find(id);
            if (stockItem == null)
            {
                return HttpNotFound();
            }
            return View(stockItem);
        }

        // POST: StockItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StockItem stockItem = db.StockItems.Find(id);
            db.StockItems.Remove(stockItem);
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
        
        public class salesStats
        {
            public List<Customer> customerList=new List<Customer>();
            public decimal totalSales;
            public decimal totalProfit;
            public decimal totalCost;
            public int id;

            public salesStats(int? id, WorldWideImportersContext db)   //salesStats takes in the ID of the item, and fetches details about its 
            {
                id = id;
                //Top purchasers, how many items they bought, and gross sales and profits            
                totalSales = getTotalSales(id, db);    //Query for total sales
                totalCost = getGrossCost(id, db);      //Query for total cost
                totalProfit = totalSales - totalCost;
                //find top 5 customers and their quantity bought
                customerList = getTop5(id, db);
            }

            private List<Customer> getTop5(int? id, WorldWideImportersContext db)
            {
                List<Customer> customerList = new List<Customer>();
                var myset= db.StockItemTransactions.Where(x => x.StockItemID == id).GroupBy(x => x.CustomerID).OrderByDescending(x => x.Sum(z => z.Quantity * -1)).Take(5).ToList();
                customerList.Add(db.Customers.Find(myset[0].First().CustomerID));
                customerList.Add(db.Customers.Find(myset[1].First().CustomerID));
                customerList.Add(db.Customers.Find(myset[2].First().CustomerID));
                customerList.Add(db.Customers.Find(myset[3].First().CustomerID));
                customerList.Add(db.Customers.Find(myset[4].First().CustomerID));
                return customerList;
            }

            private decimal getGrossCost(int? id, WorldWideImportersContext db)
            {
                return db.StockItemTransactions.Where(x => x.StockItemID == 10).Sum(x => x.Quantity) * db.StockItems.Find(id).UnitPrice;
            }

            private decimal getTotalSales(int? id, WorldWideImportersContext db)
            {
                return id != null
                    ? (decimal)(db.StockItemTransactions.Where(x => x.StockItemID == 10).Sum(x => x.Quantity) * db.StockItems.Find(id).RecommendedRetailPrice)
                    : 0;
            }
        }

    



    

}
