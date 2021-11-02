using System;
using System.Collections.Generic;
using System.Linq;
using Hospital.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;

namespace Hospital.Controllers
{
    public class TurnoController : Controller
    {
        private readonly HospitalContext context;

        private IConfiguration configuration;
        public TurnoController(HospitalContext hospitalContext, IConfiguration configuration)
        {
            this.context = hospitalContext;
            this.configuration = configuration;
        }

        public IActionResult Index()
        {
            ViewData["IdMedico"] = new SelectList((from medico in context.Medico.ToList()
                                                   select new { IdMedico = medico.IdMedico, NombreCompleto = medico.Nombre + " " + medico.Apellido }), "IdMedico", "NombreCompleto");

            ViewData["IdPaciente"] = new SelectList((from paciente in context.Paciente.ToList()
                                                     select new { IdPaciente = paciente.IdPaciente, NombreCompleto = paciente.Nombre + " " + paciente.Apellido }), "IdPaciente", "NombreCompleto");

            return View();
        }

        public JsonResult ObtenerTurnos(int idMedico)
        {
            List<Turno> turnos = new List<Turno>();
            turnos = context.Turno.Where(t => t.IdMedico == idMedico).ToList();
            return Json(turnos);
        }
        [HttpPost]
        public JsonResult GrabarTurno(Turno turno)
        {
            var ok = false;
            try
            {
                context.Turno.Add(turno);
                context.SaveChanges();
                ok = true;
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exepcion encontrada", e);
            }
            var jsonResult = new { ok = ok };
            return Json(jsonResult);
        }
        [HttpPost]
        public JsonResult EliminarTurno(int idTurno)
        {
            var ok = false;
            try
            {
                var turnoEliminar = context.Turno.Where(t => t.IdTurno == idTurno)
                .FirstOrDefault();
                if (turnoEliminar != null)
                {
                    context.Turno.Remove(turnoEliminar);
                    context.SaveChanges();
                    ok = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exepcion encontrada", e);
            }
            var jsonResult = new { ok = ok };
            return Json(jsonResult);
        }
    }
}