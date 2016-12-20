using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Case2.MaRoWo.GarageAdministratie.Infrastructure.Validators
{
    [AttributeUsage(AttributeTargets.Property)]
    public class VoertuigTypeValidatorAttribute : ValidationAttribute
    {
        private string[] _voertuigTypes { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public VoertuigTypeValidatorAttribute()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="errorMessage"></param>
        public VoertuigTypeValidatorAttribute(string errorMessage, string[] voertuigTypes) : base(errorMessage)
        {
            _voertuigTypes = voertuigTypes;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="errorMessageAccessor"></param>
        public VoertuigTypeValidatorAttribute(Func<string> errorMessageAccessor, string[] voertuigTypes) : base(errorMessageAccessor)
        {
            _voertuigTypes = voertuigTypes;
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
            if (value is string)
            {
                string voertuigTypeToValidate = (string)value;
                isValid = IsVoertuigTypeValid(voertuigTypeToValidate, _voertuigTypes);
            }
            return isValid;
        }

        private bool IsVoertuigTypeValid(string voertuigType, string[] voertuigTypes)
        {
            bool isVoertuigTypeValid = false;

            if (voertuigTypes.Contains(voertuigType))
            {
                isVoertuigTypeValid = true;
            }

            return isVoertuigTypeValid;
        }
    }
}
