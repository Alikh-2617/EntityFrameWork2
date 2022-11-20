using EntityFrameWork2.Models;
using System.ComponentModel.DataAnnotations;

namespace EntityFrameWork2.Models
{
    public class CityVM
    {
        [Key]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Försök igen")]
        [MaxLength(25)]
        public string PostNumber { get; set; }


        // menu people in city [koppling] o Add-Migration och Update
        public List<PersonVM> people { get; set; } = new List<PersonVM>();
    }
}