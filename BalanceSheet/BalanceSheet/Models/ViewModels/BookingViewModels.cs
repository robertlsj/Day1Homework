using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BalanceSheet.Models
{
    public class BookingViewModels
    {
        public string Kind { get; set; }        
        public string Date { get; set; }
        public int Amount { get; set; }
    }
}