using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OtoServisSatis.Entities;
using OtoServisSatis.Service.Abstract;

namespace OtoServisSatisWebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class KullaniciController : Controller
    {
        private readonly IService<Kullanici> serviceKullanici;
        private readonly IService<Rol> serviceRol;
        public KullaniciController(IService<Kullanici> kullanici,IService<Rol> rol)
        {
            serviceKullanici = kullanici;
            serviceRol = rol;
        }
        // GET: KullaniciController
        public async Task<IActionResult> Index()
        {
            var getAllUsers = await serviceKullanici.GetAllAsync();
            return View(getAllUsers);
        }


      

        // GET: KullaniciController/Create
        public async Task<ActionResult> Create()
        {
            ViewBag.RolId = new SelectList(await serviceRol.GetAllAsync(), "Id", "Adi");    
            return View();
        }

        // POST: KullaniciController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Kullanici kullanici)
        {
            var getAllUsers = await serviceKullanici.GetAllAsync();
            if (ModelState.IsValid)
            {
                try
                {
                    await serviceKullanici.AddAsync(kullanici);
                    await serviceKullanici.SaveAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Bir Hata Oluştu");
                }
            }
            
            return View(kullanici);
          
        }

        // GET: KullaniciController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id != 0)
            {
                ViewBag.RolId = new SelectList(await serviceRol.GetAllAsync(), "Id", "Adi");
                var userId = await serviceKullanici.FindAsync(id);
                return View(userId);
            }
            else
            {
                return NotFound();
            }
         
        }

        // POST: KullaniciController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Kullanici kullanici)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ViewBag.RolId = new SelectList(await serviceRol.GetAllAsync(), "Id", "Adi");
                    serviceKullanici.Update(kullanici);
                    await serviceKullanici.SaveAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Bir hata oluştu");
                }
            }
            return View(kullanici);
          
        }

        // GET: KullaniciController/Delete/5
        public IActionResult Delete(int id)
        {
            var getUserId =  serviceKullanici.Get(x=>x.Id ==id);
            return View(getUserId);
        }

        // POST: KullaniciController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Kullanici kullanici)
        {
            try
            {
                serviceKullanici.Delete(kullanici);
                await serviceKullanici.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
