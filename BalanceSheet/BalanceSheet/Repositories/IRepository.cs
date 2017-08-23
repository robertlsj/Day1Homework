using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace BalanceSheet.Repositories
{
    public interface IRepository<T> where T : class
    {
        IUnitOfWork UnitOfWork { get; set; }

        //取得全部資料
        IQueryable<T> GetAll();

        //條件搜尋資料
        IQueryable<T> Query(Expression<Func<T, bool>> filter);

        //新增資料
        void Create(T instance);
    }
}