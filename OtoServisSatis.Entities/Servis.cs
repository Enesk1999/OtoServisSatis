using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoServisSatis.Entities
{
    public class Servis:IEntity
    {
        public int Id { get; set; }
        [Display(Name = "Servis Başlangıç")]
        public DateTime ServisGelisTarihi { get; set; } =DateTime.Now;
        [Display(Name = "Araç Sorun")]
        public string AracSorunu { get; set; }
        [Display(Name = "Ücret")]
        public decimal ServisUcreti { get; set; }
        [Display(Name = "Servis Bitiş")]
        public DateTime ServisCikisTarihi { get; set; }
        [Display(Name = "Servis İşlmeleri")]
        public string? YapılanIslemler { get; set; }
        [Display(Name = "Garanti")]
        public bool GarantiKapsamındaMı { get; set; }
        [StringLength(15),Display(Name ="Plaka")]
        public string AracPlaka { get; set; }
        [StringLength(45)]
        public string Marka { get; set; }
        public string? Modeli { get; set; }
        public string? KasaTipi { get; set; }
        public string? SaseNo { get; set; }
        [Display(Name = "Açıklama")]
        public string? Acikalama { get; set; }

    }
}
