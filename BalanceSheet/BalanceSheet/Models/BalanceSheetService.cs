using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BalanceSheet.Models;

namespace BalanceSheet.Service
{
    public class BalanceSheetService
    {
        private readonly BalanceSheetContext context;
        public BalanceSheetService()
        {
            context = new BalanceSheetContext();
        }

        public IEnumerable<AccountBook> GetAll()
        {
            return context.AccountBooks.ToList(); 
        }
    }
}