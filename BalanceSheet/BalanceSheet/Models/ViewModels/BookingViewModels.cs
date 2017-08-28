using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BalanceSheet.Controllers;

namespace BalanceSheet.Models
{
    public class BookingViewModels
    {
        [Required]
        [Display(Name = "類別")]
        public AccountEnum Kind { get; set; }

        [Required]
        [Display(Name = "日期")]
        [EarlierThenToday(ErrorMessage = "{0}不能大於今天")]
        public string Date { get; set; }

        [Required]
        //[Remote("GreaterThenbasenum", "Validate",AdditionalFields = "basenum", ErrorMessage ="{0}必須大於0")]
        [RemoteDoublePlus("GreaterThenbasenum", "Validate", null, AdditionalFields = "basenum", ErrorMessage ="{0}必須大於0")]
        [Display(Name = "金額")]
        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        public int Amount { get; set; }

        //用來做為驗證Amount是否大於basenum
        public int basenum { get; set; }

        [Required]
        [Display(Name = "備註")]
        [StringLength(maximumLength:100,ErrorMessage ="{0}最多輸入{1}個字")]
        public string Remark { get; set; }
    }
}