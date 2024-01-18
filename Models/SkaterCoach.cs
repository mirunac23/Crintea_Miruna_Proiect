namespace Crintea_Miruna_Proiect.Models
{
    public class SkaterCoach
    {
        public int ID { get; set; }
        public int? SkaterID { get; set; }
        public Skater? Skater { get; set; }
        public int? CoachID { get; set; }
        public Coach? Coach {get;set;}
    }
}
