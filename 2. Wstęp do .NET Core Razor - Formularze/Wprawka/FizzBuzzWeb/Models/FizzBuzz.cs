using System.ComponentModel.DataAnnotations;

namespace FizzBuzzWeb.Models
{
    public class FizzBuzz
    {
        [Display(Name = "Twój szczęśliwy numere")]
        [Required(ErrorMessage = "Pole jest obowiązkowe"), Range(1, 1000,
        ErrorMessage = "Oczekiwana wartość {0} z zakresu {1} i {2}.")]
        [FizzBuzzAttribute]
        public int? Number { get; set; }
    }
}