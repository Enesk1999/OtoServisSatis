using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OtoServisSatis.Entities;
using OtoServisSatis.Service.Abstract;

namespace OtoServisSatisWebUI.Areas.Admin.Controllers
{

    [Area("Admin"), Authorize(Policy = "AdminPolicy")] 
    public class MarkaController : Controller
    {
        private readonly IService<Marka> serviceMarka;
        public MarkaController(IService<Marka> service)
        {
            serviceMarka = service;
        }
        // GET: MarkaController
        public async Task<ActionResult> Index()
        {
            var getAllBrands = await serviceMarka.GetAllAsync();
            return View(getAllBrands);
        }

        

        // GET: MarkaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MarkaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Marka marka)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await serviceMarka.AddAsync(marka);
                    await serviceMarka.SaveAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }
            return View(marka);
            
        }

        // GET: MarkaController/Edit/5
        public ActionResult Edit(int id)
        {
            var getId = serviceMarka.Get(x => x.Id == id);
            return View(getId);
        }

        // POST: MarkaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Marka marka)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    serviceMarka.Update(marka);
                    serviceMarka.Save();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Bir hata oluştu.");
                }
            }
            return View(marka);
           
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var get = serviceMarka.Get(x => x.Id == id);
            return View(get);
        }

        // POST: MarkaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, Marka marka)
        {
            try
            {
             
               
                serviceMarka.Delete(marka);
                await serviceMarka.SaveAsync();
               
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
