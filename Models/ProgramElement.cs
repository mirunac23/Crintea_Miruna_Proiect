namespace Crintea_Miruna_Proiect.Models
{
    public class ProgramElement
    {
        public int ID { get; set; }
        public int SkaterID { get; set; }
        public Skater? Skater { get; set; }
        public int? ElementID { get; set; }
        public Element Element { get; set; }
    }
}
