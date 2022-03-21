using System.ComponentModel.DataAnnotations;

namespace FizzBuzzWeb.Models
{
    public class FizzBuzzAttribute : ValidationAttribute
    {
        private string errorMessage { get; set; }
        protected override ValidationResult? IsValid(
            object? value, ValidationContext validationContext)
        {

            string message;

            if (value != null)
            {
                int number = (int)value;

                if (number % 3 == 0)
                    message = "Fizz";

                if (number % 5 == 0)
                    message = message + "Buzz";

                else
                    errorMessage = $"Liczba: {number} nie spełnia kryteriów FizzBuzz";

                return new ValidationResult(errorMessage);
            }

            return ValidationResult.Success;
        }
    }
}
