using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Runtime.InteropServices;

namespace LataPrzestepneIdenity.Models
{
    public class LeapYears
    {
        public int Id { get; set; }

        public string Date { get; set; }

        public string? UserID { get; set; }

        public string? UserName { get; set;}
        
        [Range(1899, 2023, ErrorMessage = "Oczekiwana wartość {0} z zakresu < {1} , {2} >.")]
        [Required(ErrorMessage = "Pole Rok urodzenia jest wymagane")]
        [Display(Name = "Rok urodzenia")]
        public int BirthYear { get; set; }

        [RegularExpression("[A-Za-z]*", ErrorMessage = "Nie możesz używać liczb oraz znaków specjalnych")]
        [Display(Name = "Imię")]
        [MaxLength(100)]
        public string? FirstName { get; set; }

        public bool LeapYear { get; set; }  

        public void CheckYear()
        {
            LeapYear = ((BirthYear %4 == 0) && (BirthYear %100 != 0) || BirthYear % 400 == 0);
        }
    }
}
