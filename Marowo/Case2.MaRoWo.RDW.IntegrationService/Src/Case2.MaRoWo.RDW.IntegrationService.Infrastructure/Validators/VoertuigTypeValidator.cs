using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Case2.MaRoWo.RDW.IntegrationService.Infrastructure.Validators {
    [AttributeUsage(AttributeTargets.Property)]
    public class VoertuigTypeValidator : ValidationAttribute
    {
        private readonly string[] VOERTUIG_TYPES = { "personenauto", "motor", "personenvervoer", "vrachtvervoer" };

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
            if (!(value is string)) 
            {
                return false;
            }
            string voertuigType = value.ToString().ToLower();
            if (!VOERTUIG_TYPES.Contains(voertuigType)) 
            {
                return false;
            }
            return true;
        }
    }
}
