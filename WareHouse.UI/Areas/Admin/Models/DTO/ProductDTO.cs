using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WareHouse.Model.Entity;

namespace WareHouse.UI.Areas.Admin.Models.DTO
{
    public class ProductDTO:BaseDTO
    {
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal? UnitPrice { get; set; }
        public short? UnitsInStock { get; set; }


        public int CategoryID { get; set; }
        public string CategoryName { get; set; }

        public List<Category> categories { get; set; }
        //public ProductDTO product { get; set; }
    }
}