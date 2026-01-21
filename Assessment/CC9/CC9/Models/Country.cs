using System.ComponentModel.DataAnnotations;
namespace CC9.Models
{
    public class Country
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string CountryName { get; set; }

        [Required, StringLength(100)]
        public string Capital { get; set; }
    }
}
