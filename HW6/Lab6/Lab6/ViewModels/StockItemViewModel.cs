using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Web;
using Lab6.Models;
using Microsoft.SqlServer.Types;

namespace Lab6.ViewModels
{
    public class StockItemViewModel
    {
        public StockItemViewModel(StockItem stockItem)
        {
            StockItemID = stockItem.StockItemID;
            StockItemName = stockItem.StockItemName;
            StockItemBrand = stockItem.Brand;
            StockItemSize = stockItem.Size;
            UnitPrice = stockItem.UnitPrice;
            ItemSupplier = stockItem.Supplier.SupplierName;
            ValidSinceDate = stockItem.ValidFrom;
            SupplierLocation = stockItem.Supplier.City.CityName;
            SupplierPhone = stockItem.Supplier.PhoneNumber;
            SupplierSite = stockItem.Supplier.WebsiteURL;
            SupplierContact = stockItem.Supplier.Person.FullName;
        }
        public string ItemCity { get; set; }
        public DateTime ValidSinceDate { get; set; }
        public int StockItemID { get; private set; }
        public string StockItemName { get; private set; }
        public string StockItemBrand { get; private set; }
        public string StockItemSize { get; private set; }
        public decimal UnitPrice { get; private set; }

        public string ItemSupplier { get; private set; }

        public string SupplierLocation { get; private set; }
        public string SupplierPhone { get; private set; }
        public string SupplierSite { get; private set; }
        public string SupplierContact { get; private set; }



    }
}