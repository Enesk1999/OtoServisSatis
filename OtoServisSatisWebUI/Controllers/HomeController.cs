using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Nest;
using OtoServisSatis.Entities;
using OtoServisSatis.Service.Abstract;
using OtoServisSatisWebUI.Models;
using System.Diagnostics;

namespace OtoServisSatisWebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IService<Slider> serviceSlider;
        private readonly IService<Arac> serviceArac;
        private readonly ICarService serviceCarService;
        private readonly IService<Musteri> serviceMusteri;

        public HomeController(ILogger<HomeController> logger, IService<Slider> service1, IService<Arac> service2, ICarService carService, IService<Musteri> serviceMusteri)
        {
            serviceSlider = service1;
            serviceArac = service2;
            serviceCarService = carService;
            this.serviceMusteri = serviceMusteri;
        }

        //Satıştaki Arabaları Listeleme

        [Route("Satıştaki-Araçlarimiz")]
        public async Task<ActionResult> List()
        {
            var getSaleCarList = await serviceCarService.GetCarAndBrandList(x => x.SatistaMi == true); 
            return View(getSaleCarList);
        }

        //Araç Anasayfası
        public async Task<ActionResult> Index(int id)       //Anasayfanın indexine gösterilmek istenenleri gösteririr
        {
            var viewModel = new HomeViewModel
            {
                Sliders = await serviceSlider.GetAllAsync(),
                Aracs = await serviceCarService.GetCarAndBrandList(x=>x.Anasayfa ==true) 
            };
            return View(viewModel);
        }

        //Erişim Engeli
        [Route("/AccessDenied")]
        public IActionResult AccessDenied()
        {
            return View();
        }

        //Araç Detay Sayfası 
        [Route("Araçlarimiz-Detay")]
        public async Task<IActionResult> Detay(int id)
        {
            var getArac = await serviceCarService.getCarAndBrandSingle(id);
            return View(getArac);
        }

        //Araç Arama Bölümü
        public async Task<ActionResult> Search(string searching)
        {
            var getResearch = await serviceCarService.GetCarAndBrandList(x => x.SatistaMi == true && x.Marka.Adi.Contains(searching)
            || x.Model.Contains(searching) ||  x.KasaTipi.Contains(searching));

            return View(getResearch);
        }


        public async Task<ActionResult> Musteri(Musteri musteri,Arac arac)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await serviceMusteri.AddAsync(musteri);
                    await serviceMusteri.SaveAsync();
                    return View();
                }
                catch
                {
                    return View();
                }
            }
            return Redirect("/Home/Detay"+arac.MarkaId);
        }
    }
}