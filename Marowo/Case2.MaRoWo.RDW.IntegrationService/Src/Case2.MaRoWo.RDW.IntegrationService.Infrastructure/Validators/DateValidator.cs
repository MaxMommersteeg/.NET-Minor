using System;
using System.ComponentModel.DataAnnotations;

namespace Case2.MaRoWo.RDW.IntegrationService.Infrastructure.Validators
{
    [AttributeUsage(AttributeTargets.Property)]
    public class DateValidator : ValidationAttribute
    {
        /// <summary>
        /// 
        /// </summary>
        public DateValidator()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="errorMessage"></param>
        public DateValidator(string errorMessage) : base(errorMessage)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="errorMessageAccessor"></param>
        public DateValidator(Func<string> errorMessageAccessor) : base(errorMessageAccessor)
        {
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public override bool IsValid(object value)
        {
            if(value is DateTime)
            {
                return !((DateTime)value).Equals(new DateTime());
            }
            return false;
            
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
    }
}