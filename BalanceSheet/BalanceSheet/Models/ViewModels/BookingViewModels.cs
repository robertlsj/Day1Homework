using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BalanceSheet.Models
{
    public class BookingViewModels
    {
        [Required]
        [Display(Name = "類別")]
        public AccountEnum Kind { get; set; }

        [Required]
        [Display(Name = "日期")]
        [EarlierThenToday(ErrorMessage = "{0}不能大於今天")]
        public string Date { get; set; }

        [Required]
        [Display(Name = "金額")]
        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        public int Amount { get; set; }

        [Required]
        [Display(Name = "備註")]
        [StringLength(maximumLength:100,ErrorMessage ="{0}最多輸入{1}個字")]
        public string Remark { get; set; }
    }
}