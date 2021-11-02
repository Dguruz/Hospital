using System.Linq;
using System.Threading.Tasks;
using Hospital.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Controllers
{
    public class EspecialidadController : Controller
    {
        private readonly HospitalContext _hospitalContext;
        public EspecialidadController(HospitalContext context)
        {
            this._hospitalContext = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _hospitalContext.Especialidad.ToListAsync());
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var especialidad = await _hospitalContext.Especialidad.FindAsync(id);
            if (especialidad == null)
            {
                return NotFound();
            }
            return View(especialidad);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("IdEspecialidad,Descripccion")] Especialidad especialidad)
        {
            if (id != especialidad.IdEspecialidad)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _hospitalContext.Update(especialidad);
                await _hospitalContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
                //si todo esta ok deberia quedarse aqui
            }
            return View(especialidad);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var especialidad = await _hospitalContext.Especialidad
            .FirstOrDefaultAsync(x => x.IdEspecialidad == id);
            if (especialidad == null)
            {
                return NotFound();
            }
            return View(especialidad);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var especialidad = await _hospitalContext.Especialidad.FindAsync(id);
            _hospitalContext.Especialidad.Remove(especialidad);
            await _hospitalContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("IdEspecialidad,Descripccion")] Especialidad especialidad)
        {
            if (ModelState.IsValid)
            {
                _hospitalContext.Add(especialidad);
                await _hospitalContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}