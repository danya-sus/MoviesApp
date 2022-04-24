using System;
using System.ComponentModel.DataAnnotations;
using MoviesApp.Models;

namespace MoviesApp.Filters
{
    public class MinLengthAttribute : ValidationAttribute
    {
        public int length;
        public string GetErrorMessage() => $"The actor's first name and/or last name have at least {length} characters.";

        public MinLengthAttribute(int _length)
        {
            length = _length;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var str = (string)value;
            if (str.Length < length)
            {
                return new ValidationResult(GetErrorMessage());
            }
            return ValidationResult.Success;
        }
    }
}