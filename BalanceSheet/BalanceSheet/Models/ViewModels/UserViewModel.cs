using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BalanceSheet.Models
{
    public class UserViewModel
    {
        [Display(Name = "帳號")]
        public string UserName { get; set; }
        [Display(Name = "密碼")]
        public string password { get; set; }
        [Display(Name ="角色")]
        public string role { get; set; }
    }
}