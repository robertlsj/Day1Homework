using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BalanceSheet.Models;

namespace BalanceSheet.Views
{
    public static class AccountExtensions
    {
        public static bool IsIncome(this HtmlHelper helper, AccountEnum kind)
        {
            if ((int)kind == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}