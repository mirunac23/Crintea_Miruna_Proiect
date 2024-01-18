using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Crintea_Miruna_Proiect.Models
{
    public class SkatingClub
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        [RegularExpression(@"^\d{4}$", ErrorMessage = "Please insert valid year format")]
        [Range(1900, 2024, ErrorMessage = "Year must be between 1900 and 2024.")]
        [DisplayName("Opening Year")]
        public int OpeningYear { get; set; }
        public ICollection<Skater>? Skaters { get; set; }
    }
}
