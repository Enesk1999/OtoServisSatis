using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OtoServisSatis.Entities;
using OtoServisSatis.Service.Abstract;

namespace OtoServisSatisWebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OtomobilController : Controller
    {
        private readonly IService<Arac> serviceArac;
        private readonly IService<Marka> serviceMarka;
        public OtomobilController(IService<Arac> service,IService<Marka> service1)
        {
            serviceArac = service;
            serviceMarka = service1;
        }
        // GET: OtomobilController
        public async Task<IActionResult> Index()
        {
            var getAllCars = await serviceArac.GetAllAsync();
            return View(getAllCars);
        }

        // GET: OtomobilController/Create
        public async Task<ActionResult> Create()
        {
            ViewBag.MarkaId = new SelectList(await serviceMarka.GetAllAsync(), "Id", "Adi");
            return View();
        }

        // POST: OtomobilController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Arac arac)
        {
            ViewBag.MarkaId = new SelectList(await serviceMarka.GetAllAsync(), "Id", "Adi");
            if (ModelState.IsValid)
            {
                try
                {
                    await serviceArac.AddAsync(arac);
                    await serviceArac.SaveAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }
            return View(arac);
           
        }

        // GET: OtomobilController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            ViewBag.MarkaId = new SelectList(await serviceMarka.GetAllAsync(), "Id", "Adi");
            var getById = serviceArac.Get(x => x.Id == id);
            return View(getById);
        }

        // POST: OtomobilController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Arac arac)
        {
            ViewBag.MarkaId = new SelectList(await serviceMarka.GetAllAsync(), "Id", "Adi");
            if (ModelState.IsValid)
            {
                try
                {
                    serviceArac.Update(arac);
                    await serviceArac.SaveAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }
            return View(arac);

        }

        // GET: OtomobilController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var reserachByDeletedId = await serviceArac.FindAsync(id);
            return View(reserachByDeletedId);
        }

        // POST: OtomobilController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Arac arac)
        {
            try
            {
                serviceArac.Delete(arac);
                serviceArac.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
