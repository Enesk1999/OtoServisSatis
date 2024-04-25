using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OtoServisSatis.Entities;
using OtoServisSatis.Service.Abstract;
using System.Security.Claims;

namespace OtoServisSatisWebUI.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class LoginController : Controller
    {
        private readonly IService<Kullanici> serviceKullanici;
        private readonly IService<Rol> serviceRol;

        public LoginController(IService<Kullanici> serviceKullanici, IService<Rol> serviceRol)
        {
            this.serviceKullanici = serviceKullanici;
            this.serviceRol = serviceRol;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        
        public async Task<IActionResult> Index(string email, string password)
        {
            try
            {
                var account = serviceKullanici.Get(x => x.EMail == email && x.Sifre ==password && x.AktifMi ==true);
                var rol = serviceRol.Get(x => x.Id == account.RolId);
                
                if(account == null)
                {
                    TempData["mesaj"] = "Giriş Başarısız";
                }
                else
                {
                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name, account.Adi),
                       
                    };
                    if(rol is not null)
                    {
                        claims.Add(new Claim("Role", rol.Adi));
                    }

                    var userIdentity = new ClaimsIdentity(claims,"Login");
                    ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                    await HttpContext.SignInAsync(principal);
                    return Redirect("/Admin");   
                }
            }
            catch (Exception) 
            {
                TempData["mesaj"] = "Bir hata oluştu";
            }
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/Admin/Login");
        }
    }
}
