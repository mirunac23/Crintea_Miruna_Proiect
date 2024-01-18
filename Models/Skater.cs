using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Crintea_Miruna_Proiect.Models
{
    public class Skater
    {
        public int ID { get; set; }
        public string Name { get; set; }
        [Range(15, 80, ErrorMessage = "Age must be between 15 and 80 to be able to compete")]
        public int Age { get; set; }
        public int Height { get; set; }
        [DisplayName("Email adress")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Please add a valid email.")]
        public string EmailAddress { get; set; }
        public int? SkatingClubID { get; set; }
        public SkatingClub? SkatingClub { get; set; }
        public ICollection<SkaterCoach>? SkaterCoaches { get; set; }
    }
}
