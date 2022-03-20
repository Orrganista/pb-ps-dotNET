using System.ComponentModel.DataAnnotations;

namespace FizzBuzzWeb.Models
{
    public class FizzBuzzAttribute : ValidationAttribute
    {
        private string errorMessage { get; set; }
        protected override ValidationResult? IsValid(
            object? value, ValidationContext validationContext)
        {

            if (value != null)
            {
                int number = (int)value;

                if (number % 3 == 0 && number % 5 == 0)
                    errorMessage = "FizzBuzz";
                else if (number % 3 == 0)
                    errorMessage = "Fizz";
                else if (number % 5 == 0)
                    errorMessage = "Buzz";
                else
                    errorMessage = $"Liczba: {number} nie spełnia kryteriów FizzBuzz";

                return new ValidationResult(errorMessage);
            }

            return ValidationResult.Success;
        }
    }
}
