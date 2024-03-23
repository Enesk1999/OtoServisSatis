using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoServisSatis.Entities
{
    public class Musteri:IEntity
    {
        public int Id { get; set; }
        [StringLength(40),Display(Name ="Müşteri Adı"),Required(ErrorMessage ="{0} Boş bırakılamaz")]
        
        public string Adi { get; set; }
        [StringLength(40), Display(Name = "Müşteri Soyadı"), Required(ErrorMessage = "{0} Boş bırakılamaz")]
        public string Soyadi { get; set; }
        [StringLength(11),Display(Name ="Tc Kimlik")]
        public string? TcNo { get; set; }
        [StringLength(30), Display(Name = "E-Posta"), Required(ErrorMessage = "{0} Boş bırakılamaz")]
        public string Mail { get; set; }
        [StringLength(300)]
        public string? Adres { get; set; }
        public string Telefon { get; set; }
        [Display(Name ="Açıklama")]
        public string? Aciklama { get; set; }
        public int AracId { get; set; }
        public virtual Arac? Arac { get; set; }  //Müşteri sınıfı ile araç sınıfı arasındaki bağlantı
    }
}
