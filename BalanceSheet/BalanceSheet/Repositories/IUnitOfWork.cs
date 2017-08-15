using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BalanceSheet.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        DbContext context { get; set; }
    }
}