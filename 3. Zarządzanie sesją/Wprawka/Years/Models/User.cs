using System.ComponentModel.DataAnnotations;
using System;

namespace Years.Models
{
    public class User
    {
        [Display(Name = "Imię")]
        [Required(ErrorMessage = "Pole {0} jest obowiązkowe")]
        [StringLength(100, ErrorMessage = "{0} nie może przekraczać 100 znaków.")]
        public string? Name { get; set; }

        [Display(Name = "Rok")]
        [Required(ErrorMessage = "Pole {0} jest obowiązkowe")]
        [Range(1899, 2022, ErrorMessage = "Oczekiwana wartość {0} z zakresu {1} i {2}.")]
        public int? Year { get; set; }

        public bool isLeapYear()
        {
            if (DateTime.IsLeapYear(Year ?? 0))
                return true;

            return false;
        }
    }
}