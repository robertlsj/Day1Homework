using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using BalanceSheet.Models;

namespace BalanceSheet.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        public DbContext context { get; set; }

        public EFUnitOfWork()
        {
            context = new BalanceSheetContext();
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}