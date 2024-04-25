using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nest;
using OtoServisSatis.Entities;
using OtoServisSatis.Service.Abstract;

namespace OtoServisSatisWebUI.Areas.Admin.Controllers
{

    [Area("Admin"), Authorize(Policy = "AdminPolicy")]
    public class RoleController : Controller
    {
        private readonly IService<Rol> serviceRol;
        public RoleController(IService<Rol> servisim)
        {
            serviceRol = servisim;
        }
        public async Task<IActionResult> Index()
        {
            var getAll = await serviceRol.GetAllAsync();
            return View(getAll);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public  async Task<IActionResult> Create(Rol rol)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await serviceRol.AddAsync(rol);
                    await serviceRol.SaveAsync();
                    return RedirectToAction("Index", "Role");
                }
                catch
                {
                    return View();
                }
            }
            return View(rol);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (id != 0)
            {
                var researchId = await serviceRol.FindAsync(id);
                return View(researchId);
            }
            else
            {
                return RedirectToAction("Index", "Role");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Rol rol)
        {
            try
            {
                serviceRol.Update(rol);
                await serviceRol.SaveAsync();
                return  RedirectToAction("Index", "Role");
            }
            catch
            {
                return View();
            }
            
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var getId = serviceRol.Get(x => x.Id == id);
            return View(getId);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Rol rol)
        {
            try
            { 
                serviceRol.Delete(rol);
                await serviceRol.SaveAsync();
                return RedirectToAction("Index", "Role");
            }
            catch
            {
                return View();
            }
        }
    }
}
