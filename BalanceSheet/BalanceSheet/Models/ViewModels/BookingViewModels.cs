using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BalanceSheet.Models
{
    public class BookingViewModels
    {
        [Display(Name = "類別")]
        public string Kind { get; set; }

        [Display(Name = "日期")]
        public string Date { get; set; }

        [Display(Name = "金額")]
        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        public int Amount { get; set; }
    }
}