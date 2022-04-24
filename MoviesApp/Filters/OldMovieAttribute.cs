using System.ComponentModel.DataAnnotations;
using MoviesApp.Models;
using System;

namespace MoviesApp.Filters
{
    public class OldMovieAttribute : ValidationAttribute
    {
        public int Year { get; }
        public string GetErrorMessage() => $"Movie must have a release year no later than {Year}.";

        public OldMovieAttribute(int year)
        {
            Year = year;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var releaseDate = ((DateTime)value).Year;
            if (releaseDate < Year)
            {
                return new ValidationResult(GetErrorMessage());
            }
            return ValidationResult.Success;
        }
    }
}