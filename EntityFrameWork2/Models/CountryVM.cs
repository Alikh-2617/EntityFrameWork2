using System.ComponentModel.DataAnnotations;

namespace EntityFrameWork2.Models
{
    public class CountryVM
    {
        [Key]
        [MaxLength(50)]
        public string Name { get; set; }

        public List<CityVM> City { get; set; } = new List<CityVM>();

    }
}

