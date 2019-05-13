using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WareHouse.Model.Enum;

namespace WareHouse.UI.Areas.Admin.Models.DTO
{
    public class UserDTO:BaseDTO
    {
        [Required(ErrorMessage ="Please enter your first name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter your last name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please enter your user name")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Please enter your Email address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter your password")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Please choose a user role")]
        public Role Role { get; set; }
        [Required(ErrorMessage = "Please choose a user gender")]
        public Gender Gender { get; set; }
    }
}