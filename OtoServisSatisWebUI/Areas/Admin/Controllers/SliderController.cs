using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OtoServisSatis.Entities;
using OtoServisSatis.Service.Abstract;
using OtoServisSatisWebUI.Utils;

namespace OtoServisSatisWebUI.Areas.Admin.Controllers
{
    [Area("Admin"),Authorize]
    public class SliderController : Controller
    {
        private readonly IService<Slider> serviceSlider;
        public SliderController(IService<Slider> service)
        {
            serviceSlider = service;
        }
        // GET: SliderController
        public async Task<ActionResult> Index()
        {
            var getAllSliders = await serviceSlider.GetAllAsync();
            return View(getAllSliders);
        }


        // GET: SliderController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SliderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IFormFile? Resim, Slider slider)
        {
            try
            {
                slider.Resim = await FileHelper.FileLoaderAsync(Resim, "/Img/Sliders/");
                await serviceSlider.AddAsync(slider);
                await serviceSlider.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SliderController/Edit/5
        public ActionResult Edit(int id)
        {
            var getSingleSlider = serviceSlider.Get(x => x.Id == id);
            return View(getSingleSlider);
        }

        // POST: SliderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, IFormFile? Resim,Slider slider)
        {
            try
            {
                if(slider is not null)
                {
                    slider.Resim = await FileHelper.FileLoaderAsync(Resim, "/Img/Sliders/");
                }
                serviceSlider.Update(slider);
                await serviceSlider.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SliderController/Delete/5
        public ActionResult Delete(int id)
        {
            var getSingleSlider = serviceSlider.Get(x => x.Id == id);
            return View(getSingleSlider);
        }

        // POST: SliderController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Slider slider)
        {
            try
            {
                serviceSlider.Delete(slider);
                serviceSlider.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
