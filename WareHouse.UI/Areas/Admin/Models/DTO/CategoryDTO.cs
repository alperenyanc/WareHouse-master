using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WareHouse.Model.Entity;

namespace WareHouse.UI.Areas.Admin.Models.DTO
{
    public class CategoryDTO:BaseDTO
    {
        [Required(ErrorMessage ="Please add category name")]
        public string CategoryName { get; set; }
        [Required(ErrorMessage = "Please add category description")]
        public string CategoryDescription { get; set; }
      
    }
}