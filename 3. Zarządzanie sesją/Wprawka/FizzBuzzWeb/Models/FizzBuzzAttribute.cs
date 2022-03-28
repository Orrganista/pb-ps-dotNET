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

                string message = "";

                if (number % 3 == 0)
                    message += "Fizz";

                if (number % 5 == 0)
                    message += "Buzz";

                if (String.IsNullOrEmpty(message))
                    message = $"Liczba: {number} nie spełnia kryteriów FizzBuzz";

                return new ValidationResult(message);
            }

            return ValidationResult.Success;
        }
    }
}
