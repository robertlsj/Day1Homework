using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BalanceSheet.Models;
using BalanceSheet.Repositories;
using System.Linq.Expressions;

namespace BalanceSheet.Service
{
    public class BalanceSheetService
    {
        private List<SelectListItem> kindList = new List<SelectListItem>();
        private readonly IRepository<AccountBook> accountBookRepository;
        private readonly IUnitOfWork _unitOfWork;
        public BalanceSheetService(IUnitOfWork unitOfWork)
        {
            kindList.AddRange(new[] {
                new SelectListItem() { Text = "支出", Value = "0" },
                new SelectListItem() { Text = "收入", Value = "1" }
            });
            accountBookRepository = new Repository<AccountBook>(unitOfWork);
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<BookingViewModels> GetAll()
        {
            var source = accountBookRepository.GetAll();
            var result = source.OrderBy(m => m.Dateee).ToList().Select(m => new BookingViewModels()
            {
                Kind = kindList.Where(x => x.Value == m.Categoryyy.ToString()).First().Text,
                Amount = m.Amounttt,
                Date = m.Dateee.ToString("yyyy-MM-dd")
            });

            return result;
        }

        public IEnumerable<BookingViewModels> Query(Expression<Func<AccountBook, bool>> filter)
        {
            var source = accountBookRepository.Query(filter);
            var result = source.ToList().Select(m => new BookingViewModels()
            {
                Kind = kindList.Where(x => x.Value == m.Categoryyy.ToString()).First().Text,
                Amount = m.Amounttt,
                Date = m.Dateee.ToString("yyyy-MM-dd")
            });
            return result;  
        }
    }
}