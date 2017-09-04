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
        private UserViewModel User;

        public BalanceSheetService(IUnitOfWork unitOfWork)
        {
            kindList.AddRange(new[] {
                new SelectListItem() { Text = "支出", Value = "0" },
                new SelectListItem() { Text = "收入", Value = "1" }
            });
            accountBookRepository = new Repository<AccountBook>(unitOfWork);
            _unitOfWork = unitOfWork;

            User = new Models.UserViewModel() {
                UserName="robert",
                password = "1234",
                role = "admin"
            };
        }

        public bool UserIsAdmin(string _name)
        {
            return (User.UserName == _name) ? true : false; 
        }

        public IEnumerable<BookingViewModels> GetAll()
        {
            var source = accountBookRepository.GetAll();
            var result = source.OrderBy(m => m.Dateee).OrderByDescending(m => m.Dateee).ToList().Select(m => new BookingViewModels()
            {
                Id = m.Id.ToString(),
                Kind = (AccountEnum)m.Categoryyy,
                Amount = m.Amounttt,
                Date = m.Dateee.ToString(),
                Remark = m.Remarkkk
            });

            return result;
        }

        public IEnumerable<BookingViewModels> Query(Expression<Func<AccountBook, bool>> filter)
        {
            var source = accountBookRepository.Query(filter);
            var result = source.ToList().Select(m => new BookingViewModels()
            {
                Id = m.Id.ToString(),
                Kind = (AccountEnum)m.Categoryyy,
                Amount = m.Amounttt,
                Date = m.Dateee.ToString(),
                Remark = m.Remarkkk
            });
            return result;  
        }

        public void Create(BookingViewModels booking)
        {
            var thisbooking = new AccountBook();
            thisbooking.Id = Guid.NewGuid();
            thisbooking.Amounttt = booking.Amount;
            thisbooking.Categoryyy = (int)booking.Kind;
            thisbooking.Dateee = Convert.ToDateTime(booking.Date);
            thisbooking.Remarkkk = booking.Remark;
            accountBookRepository.Create(thisbooking);
        }

        public void Delete(BookingViewModels model)
        {
            var result = accountBookRepository.Query(m => m.Id.ToString() == model.Id).FirstOrDefault();
            accountBookRepository.Delete(result);
        }

        public void Edit(BookingViewModels model)
        {
            var result = accountBookRepository.Query(m => m.Id.ToString() == model.Id).FirstOrDefault();
            result.Amounttt = model.Amount;
            result.Categoryyy = (int)model.Kind;
            result.Dateee = DateTime.Parse(model.Date);
            result.Remarkkk = model.Remark;
            accountBookRepository.Edit(result);
        }
    }
}