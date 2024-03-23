using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoServisSatis.Entities
{
    public class Kullanici:IEntity
    {
        public int Id { get; set; }
        [StringLength(30)]
        [Display(Name ="Adı"),Required(ErrorMessage ="{0} Boş Bırakılamaz.")]
        public string Adi { get; set; }
        [StringLength(30),Display(Name ="Soyadı")]
        public string Soyadi { get; set; }
        [StringLength(30)]
        [Display(Name ="E-posta")]
        public string EMail { get; set; }
        [StringLength(30)]
        [Display(Name ="Kullanıcı Adı")]
        public string KullaniciAdi { get; set; }
        [StringLength(30)]
        [Display(Name ="Parola")]
        public string Sifre{ get; set; }
        [StringLength(20)]
        public string? Telefon { get; set; }
        [Display(Name ="Aktif Mi?")]
        public bool AktifMi { get; set; }
        [Display(Name ="Eklenme Tarihi"),ScaffoldColumn(false)]     //Data annotation scaffold column ile gösterim yapmayabiliriz   
        public DateTime EklenmeTarihi { get; set; } = DateTime.Now;
        [Display(Name ="Kullanıcı Rolü")]
        public int? RolId { get; set; }
        
        public virtual Rol? Rol { get; set; }    //Kullanici sınıfı ile rol sınıfı arasındaki bağlantı


    }
}
