using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OtoServisSatis.Entities;
using OtoServisSatis.Service.Abstract;

namespace OtoServisSatisWebUI.Areas.Admin.Controllers
{

    [Area("Admin"), Authorize(Policy = "UserPolicy")]
    public class MusteriController : Controller
    {
        private readonly IService<Musteri> serviceMusteri;
        private readonly IService<Arac> serviceArac;
        public MusteriController(IService<Musteri> service,IService<Arac> service1)
        {
            serviceMusteri = service;
            serviceArac = service1;
        }
        // GET: MusteriController
        public async Task<ActionResult> Index()
        {
            var getAllCustomers = await serviceMusteri.GetAllAsync();
            return View(getAllCustomers);
        }

        // GET: MusteriController/Create
        public async Task<ActionResult> Create()
        {
            ViewBag.AracId = new SelectList(await serviceArac.GetAllAsync(), "Id", "Model");
            return View();
        }

        // POST: MusteriController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Musteri musteri)
        {
            ViewBag.AracId = new SelectList(await serviceArac.GetAllAsync(), "Id", "Model");
            if (ModelState.IsValid)
            {
                try
                {
                    await serviceMusteri.AddAsync(musteri);
                    await serviceMusteri.SaveAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("","Bir hata oluştu lütfen girdiğiniz değerleri kontrol edin ya da site sahibine ulaşın");
                }
            }
            return View(musteri);
           
        }

        // GET: MusteriController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            ViewBag.AracId = new SelectList(await serviceArac.GetAllAsync(), "Id", "Model");
            var getSingleId = await serviceMusteri.FindAsync(id);
            return View(getSingleId);
        }

        // POST: MusteriController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Musteri musteri)
        {
            ViewBag.AracId = new SelectList(await serviceArac.GetAllAsync(), "Id", "Model");

            if (ModelState.IsValid)
            {
                try
                {
                    serviceMusteri.Update(musteri);
                    await serviceMusteri.SaveAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Bir hata oluştu lütfen girdiğiniz değerleri kontrol edin ya da site sahibine ulaşın");
                }
            }
            return View(musteri);
            
        }

        // GET: MusteriController/Delete/5
        public ActionResult Delete(int id)
        {
            var getSinglerData = serviceMusteri.Get(x => x.Id == id);
            return View(getSinglerData);
        }

        // POST: MusteriController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, Musteri musteri)
        {
            try
            {
                serviceMusteri.Delete(musteri);
                await serviceMusteri.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
