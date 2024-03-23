using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OtoServisSatis.Entities;
using OtoServisSatis.Service.Abstract;

namespace OtoServisSatisWebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SatisController : Controller
    {
        private readonly IService<Satis> serviceSatis;
        private readonly IService<Musteri> serviceMusteri;
        private readonly IService<Arac> serviceArac;
        public SatisController(IService<Satis> service0,IService<Musteri> service1,IService<Arac> service2)
        {
            serviceSatis = service0;
            serviceMusteri = service1;
            serviceArac = service2;
        }

        // GET: SatisController
        public async Task<ActionResult> Index()
        {
            var getAllSales = await serviceSatis.GetAllAsync();
            return View(getAllSales);
        }


        // GET: SatisController/Create
        public async Task<ActionResult> Create()
        {
            ViewBag.AracId = new SelectList(await serviceArac.GetAllAsync(), "Id", "Model");
            ViewBag.MusteriId = new SelectList(await serviceMusteri.GetAllAsync(), "Id", "Adi");
            return View();
        }

        // POST: SatisController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Satis satis)
        {
            ViewBag.MusteriId = new SelectList(await serviceMusteri.GetAllAsync(), "Id", "Adi");
            ViewBag.AracId = new SelectList(await serviceArac.GetAllAsync(), "Id", "Model");
            
            if (ModelState.IsValid)
            {
                try
                {
                    await serviceSatis.AddAsync(satis);
                    await serviceSatis.SaveAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Bir hata oluştu yeniden deneyiniz ya da site sahibine mesaj yollayınız");
                }
            }
            return View(satis);
           
        }

        // GET: SatisController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            ViewBag.MusteriId = new SelectList(await serviceMusteri.GetAllAsync(), "Id", "Adi");
            ViewBag.AracId = new SelectList(await serviceArac.GetAllAsync(), "Id", "Model");
            var getSingleId = await serviceSatis.FindAsync(id);
            return View(getSingleId);
        }

        // POST: SatisController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Satis satis)
        {
            ViewBag.MusteriId = new SelectList(await serviceMusteri.GetAllAsync(), "Id", "Adi");
            ViewBag.AracId = new SelectList(await serviceArac.GetAllAsync(), "Id", "Model");
            if (ModelState.IsValid)
            {
                try
                {
                    serviceSatis.Update(satis);
                    await serviceSatis.SaveAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Bir hata oluştu siteyi yenile ya da site sahibi ile iletişime geceniz");
                }
            }
            return View(satis);
            
        }

        // GET: SatisController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var getSingleDeletedById = await serviceSatis.FindAsync(id);
            return View(getSingleDeletedById);
        }

        // POST: SatisController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Satis satis)
        {
            try
            {
                serviceSatis.Delete(satis);
                serviceSatis.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
