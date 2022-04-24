using System;
using System.ComponentModel.DataAnnotations;
using MoviesApp.Models;

namespace MoviesApp.Filters
{
    public class YoungActorAttribute : ValidationAttribute
    {
        public int Age { get; }
        public string GetErrorMessage() => $"An actor cannot be less than {Age} years old.";

        public YoungActorAttribute(int age)
        {
            Age = age;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var age = DateTime.Now.Year - ((DateTime)value).Year;
            if (age < Age)
            {
                return new ValidationResult(GetErrorMessage());
            }
            return ValidationResult.Success;
        }
    }
}