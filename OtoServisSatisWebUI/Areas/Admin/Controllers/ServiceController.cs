using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OtoServisSatis.Entities;
using OtoServisSatis.Service.Abstract;

namespace OtoServisSatisWebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ServiceController : Controller
    {
        private readonly IService<Servis> serviceServis;
        public ServiceController(IService<Servis> service)
        {
            serviceServis = service;
        }
        // GET: ServiceController
        public async Task<ActionResult> Index()
        {
            var getAllServices = await serviceServis.GetAllAsync();
            return View(getAllServices);
        }

        // GET: ServiceController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ServiceController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Servis servis)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await serviceServis.AddAsync(servis);
                    await serviceServis.SaveAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Bir hata oluştu sorun devam ederse site sahibiyle iletişime geçiniz.");
                }
            }
            return View(servis);
           
        }

        // GET: ServiceController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var getById = await serviceServis.FindAsync(id);
            return View(getById);
        }

        // POST: ServiceController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Servis servis)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    serviceServis.Update(servis);
                    await serviceServis.SaveAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Bir hata oluştu");
                }
            }
            return View(servis); 
            
        }

        // GET: ServiceController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var getFindByDeleteService = await serviceServis.FindAsync(id);
            return View(getFindByDeleteService);
        }

        // POST: ServiceController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, Servis servis)
        {
            try
            {
                serviceServis.Delete(servis);
                await serviceServis.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
