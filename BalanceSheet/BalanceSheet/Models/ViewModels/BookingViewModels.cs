using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BalanceSheet.Models
{
    public class BookingViewModels
    {
        public string Kind { get; set; }

        public string Date { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        public int Amount { get; set; }
    }
}