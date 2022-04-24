using System;
using System.ComponentModel.DataAnnotations;
using MoviesApp.Models;

namespace MoviesApp.Filters
{
    public class OldActorAttribute : ValidationAttribute
    {
        public int Age { get; }
        public string GetErrorMessage() => $"An actor cannot be more than {Age} years old.";

        public OldActorAttribute(int age)
        {
            Age = age;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var age = DateTime.Now.Year - ((DateTime)value).Year;
            if (age > Age)
            {
                return new ValidationResult(GetErrorMessage());
            }
            return ValidationResult.Success;
        }
    }
}
