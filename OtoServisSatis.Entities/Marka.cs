using System.ComponentModel.DataAnnotations;

namespace OtoServisSatis.Entities
{
    public class Marka:IEntity
    {
        public int Id { get; set; }
        [Display(Name ="Marka Adı")]
        public string Adi { get; set; }
    }
}
