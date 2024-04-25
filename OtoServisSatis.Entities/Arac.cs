using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OtoServisSatis.Entities
{
    public class Arac : IEntity
    {
        public int Id { get; set; }
        [StringLength(30),Display(Name ="Araç Renk"),Required(ErrorMessage ="{0} Boş Bırakılmaz")]
        public string Renk { get; set; }
        public decimal Fiyat { get; set; }
        [StringLength(30),Display(Name = "Araç Model"), Required(ErrorMessage = "{0} Boş Bırakılmaz")]
        public string Model { get; set; }
        [StringLength(30), Display(Name = "Araç Kasa Tipi"), Required(ErrorMessage = "{0} Boş Bırakılmaz")]
        public string KasaTipi { get; set; }
        public string ModelYili { get; set; }

        [Display(Name ="Satşta mı?")]
        public bool SatistaMi { get; set; }     //Satış sayfası için araç gösterme
        public bool Anasayfa { get; set; }      //Anasayfada  olan araçları gösterme
        [StringLength(300)]
        public string Aciklama { get; set; }
        [StringLength(100)]
        public string? Resim1 { get; set; }
        [StringLength(100)]
        public string? Resim2 { get; set; }
        [StringLength(100)]
        public string? Resim3 { get; set; }
        public int MarkaId { get; set; }
        public virtual Marka? Marka { get; set; }    //Araç sınıfı ile marka sınıfı arasındaki bağlantı
    }
}
