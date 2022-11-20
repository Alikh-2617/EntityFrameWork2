using System.ComponentModel.DataAnnotations;

namespace EntityFrameWork2.Models
{
    public class PersonVM
    {
        [Key]
        public string Id { get; set; }

        public string Name { get; set; }

        public string EfterName { get; set; }

        public int age { get; set; }

        public string? PhoneNumber { get; set; }

        public List<CityVM> cities { get; set; } = new List<CityVM>();
    }
}
