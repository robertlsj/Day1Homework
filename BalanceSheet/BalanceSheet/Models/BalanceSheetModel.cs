namespace BalanceSheet.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BalanceSheetContext : DbContext
    {
        public BalanceSheetContext()
            : base("name=BalanceSheetModel")
        {
        }

        public virtual DbSet<AccountBook> AccountBooks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }

        public System.Data.Entity.DbSet<BalanceSheet.Models.BookingViewModels> BookingViewModels { get; set; }
    }
}
