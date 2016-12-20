using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace FrontEnd.DataAnnotations
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    sealed public class CursusFile : ValidationAttribute
    {
        private const string _fileType = "text/plain";

        /// <summary>
        /// IsValid
        /// Check if given IFormFile is a valid Cursusbestand
        /// </summary>
        /// <param name="value">IFormFile (Cursusbestand)</param>
        /// <returns>bool</returns>
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return false;
            }
            IFormFile cursusFile = null;
            try
            {
                cursusFile = (IFormFile)value;
            }
            catch
            {
                return false;
            }

            if (cursusFile == null)
            {
                return false;
            }

            // Check if CursusFile has content
            if (cursusFile.Length < 1)
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(cursusFile.ContentType))
            {
                return false;
            }

            // Check if given file uses ' text/plain' ContentType
            if (cursusFile.ContentType != _fileType)
            {
                return false;
            }

            return true;
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(CultureInfo.CurrentCulture, ErrorMessageString, name);
        }
    }
}
