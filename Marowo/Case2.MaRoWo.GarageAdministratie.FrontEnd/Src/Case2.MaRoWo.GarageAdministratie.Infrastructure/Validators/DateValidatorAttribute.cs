using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Case2.MaRoWo.GarageAdministratie.Infrastructure.Validators
{
    [AttributeUsage(AttributeTargets.Property)]
    public class DateValidatorAttribute : ValidationAttribute
    {
        /// <summary>
        /// 
        /// </summary>
        public DateValidatorAttribute()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="errorMessage"></param>
        public DateValidatorAttribute(string errorMessage) : base(errorMessage)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="errorMessageAccessor"></param>
        public DateValidatorAttribute(Func<string> errorMessageAccessor) : base(errorMessageAccessor)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="validationContext"></param>
        /// <returns></returns>        
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (IsValid(value))
            {
                return ValidationResult.Success;
            }
            return new ValidationResult(ErrorMessage);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public override bool IsValid(object value)
        {
            bool isValid = false;
            if(value is DateTime)
            {
                DateTime dateToValidate = (DateTime)value;
                dateToValidate = dateToValidate.Date;
                isValid = IsDateToday(dateToValidate);
            }
            return isValid;
        }
        
        private bool IsDateToday(DateTime date)
        {
            bool isDateToday = false;
            DateTime currentDate = DateTime.Now.Date;
            if(date == currentDate)
            {
                isDateToday = true;
            }

            return isDateToday;
        }
    }
}
