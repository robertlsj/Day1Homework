using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BalanceSheet.Models
{
    public sealed class GreaterThenAttribute : ValidationAttribute, IClientValidatable
    {
        public int BaseNum;

        public GreaterThenAttribute(int basenum)
        {
            BaseNum = basenum;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule
            {
                ErrorMessage = FormatErrorMessage(metadata.GetDisplayName()),
                ValidationType = "earlierthentoday"
            };
            yield return rule;
        }
    }

    public sealed class EarlierThenTodayAttribute : ValidationAttribute, IClientValidatable
    {
        public EarlierThenTodayAttribute()
        {
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule
            {
                ErrorMessage = FormatErrorMessage(metadata.GetDisplayName()),
                ValidationType="earlierthentoday"
            };
            yield return rule;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (DateTime.Compare(Convert.ToDateTime(value), DateTime.Today) > 0)
            {
                return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
            }
            return null;
        }

    }
}