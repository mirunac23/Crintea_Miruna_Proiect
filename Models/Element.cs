using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Crintea_Miruna_Proiect.Models
{
    public class Element
    {
        public int ID { get; set; }
        public string Name { get; set; }
        [Range(0, 30, ErrorMessage = "Element base value must be between 0 and 20")]
        [DisplayName("Base Value")]
        public int BaseValue { get; set; }
    }
}
