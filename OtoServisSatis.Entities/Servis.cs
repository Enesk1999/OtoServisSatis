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
        public DateTime ServisGelisTarihi { get; set; } =DateTime.Now;
        public string AracSorunu { get; set; }
        public decimal ServisUcreti { get; set; }
        public DateTime ServisCikisTarihi { get; set; } 
        public string? YapılanIslemler { get; set; }
        public bool GarantiKapsamındaMı { get; set; }
        [StringLength(15)]
        public string AracPlaka { get; set; }
        [StringLength(45)]
        public string Marka { get; set; }
        public string? Modeli { get; set; }
        public string? KasaTipi { get; set; }
        public string? SaseNo { get; set; }
        public string? Acikalama { get; set; }

    }
}
