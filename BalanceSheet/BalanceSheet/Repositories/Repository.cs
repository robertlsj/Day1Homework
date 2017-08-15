using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace BalanceSheet.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public IUnitOfWork UnitOfWork { get; set; }

        public Repository(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        private DbSet<T> _objectSet;
        private DbSet<T> ObjectSet
        {
            get
            {
                if (_objectSet == null)
                {
                    _objectSet = UnitOfWork.context.Set<T>();
                }
                return _objectSet;
            }
        }

        public IQueryable<T> GetAll()
        {
            return ObjectSet;
        }

        public IQueryable<T> Query(Expression<Func<T, bool>> filter)
        {
            return ObjectSet.Where(filter);
        }
    }
}