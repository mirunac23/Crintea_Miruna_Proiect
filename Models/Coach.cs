using System.ComponentModel.DataAnnotations;

namespace Crintea_Miruna_Proiect.Models
{
    public class Coach
    {
        public int ID { get; set; }
        public string Name { get; set; }
        [Range(0, 80, ErrorMessage = "Experience must be between 0 and 80 years.")]
        public int Experience { get; set; }
        public ICollection<SkaterCoach>? SkaterCoaches { get; set; }
    }
}
