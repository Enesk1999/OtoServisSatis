using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OtoServisSatis.Entities;
using OtoServisSatis.Service.Abstract;
using OtoServisSatisWebUI.Utils;

namespace OtoServisSatisWebUI.Areas.Admin.Controllers
{

    [Area("Admin"), Authorize(Policy = "AdminPolicy")]
    public class OtomobilController : Controller
    {
        private readonly IService<Arac> serviceArac;
        private readonly IService<Marka> serviceMarka;
        private readonly ICarService carService;
        public OtomobilController(IService<Arac> service,IService<Marka> service1, ICarService carService)
        {
            serviceArac = service;
            serviceMarka = service1;
            this.carService = carService;

        }
        // GET: OtomobilController
        public async Task<IActionResult> Index()
        {
            var getAllCars = await carService.GetCarAndBrandList();
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
        public async Task<ActionResult> Create(Arac arac,IFormFile? Resim1, IFormFile? Resim2, IFormFile? Resim3)
        {
            ViewBag.MarkaId = new SelectList(await serviceMarka.GetAllAsync(), "Id", "Adi");
            if (ModelState.IsValid)
            {
                try
                {
                    arac.Resim1 = await FileHelper.FileLoaderAsync(Resim1, "/Img/Cars/");
                    arac.Resim2 = await FileHelper.FileLoaderAsync(Resim2, "/Img/Cars/");
                    arac.Resim3 = await FileHelper.FileLoaderAsync(Resim3, "/Img/Cars/");
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
        public async Task<ActionResult> Edit(Arac arac, IFormFile? Resim1, IFormFile? Resim2, IFormFile? Resim3)
        {
            ViewBag.MarkaId = new SelectList(await serviceMarka.GetAllAsync(), "Id", "Adi");
            if (ModelState.IsValid)
            {
                try
                {
                    if(Resim1 is not null)
                    {
                        arac.Resim1 = await FileHelper.FileLoaderAsync(Resim1, filePath: "/Img/Cars/");
                    }
                    if(Resim2 is not null)
                    {
                        arac.Resim2 = await FileHelper.FileLoaderAsync(Resim2, filePath: "/Img/Cars/");
                    }
                    if (Resim3 is not null)
                    {
                        arac.Resim3 = await FileHelper.FileLoaderAsync(Resim3, filePath: "/Img/Cars/");
                    }
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
