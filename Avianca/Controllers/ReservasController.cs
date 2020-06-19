using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Avianca.Data;
using Avianca.Models;
using RestSharp;

namespace Avianca.Controllers
{
    public class ReservasController : Controller
    {
        private readonly AvianContext _context;

        public ReservasController(AvianContext context)
        {
            _context = context;
        }

        // GET: Reservas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Reservas.ToListAsync());
        }
     
       /*public async Task<IActionResult> GetSilla(Reserva reserva)
        {
            bool status = false;

            var sillacontext = _context.Reservas
              .Select(x => new
              {
                  idReserva=x.IDReserva,
                  silla = x.Silla
              }).Where(x => x.silla == reserva.Silla && x.idReserva ==reserva.IDReserva );

            if (sillacontext.Count() == 0)
            {
                status = true;
                return Json(status);
            }
            else
            {
                    return Json(Response.StatusCode = 404);
            }


        }*/


        [HttpPost]
        public async Task<IActionResult> SaveReservaAPI(Reserva reserva)
        {
            bool status = false;

            if (ModelState.IsValid)
            {
                Reserva data = new Reserva();

                data.IDReserva = reserva.IDReserva;
                data.Origen = reserva.Origen;
                data.Destino = reserva.Destino;
                data.FechayHoraSalida = reserva.FechayHoraSalida;
                data.Silla = reserva.Silla;
                data.Clase = reserva.Clase;
                data.Precio = reserva.Precio;
                data.NombreCliente = reserva.NombreCliente;
                data.NumeroDocumento = reserva.NumeroDocumento;
                _context.Add(data);

                await _context.SaveChangesAsync();
                status = true;
                return Json(status);

            }

            return Json(status);
        }

        // GET: Reservas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reservas
                .FirstOrDefaultAsync(m => m.ID == id);
            if (reserva == null)
            {
                return NotFound();
            }

            return View(reserva);
        }


        // GET: Reservas/Create
        public IActionResult Create()
        {
            return View();
        }


        // POST: Reservas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,IDReserva,Origen,Destino,FechayHoraSalida,Silla,Clase,Precio,NombreCliente,NumeroDocumento,Status")] Reserva reserva)
        {

            if (ModelState.IsValid)
            {
                _context.Add(reserva);
                await _context.SaveChangesAsync();
            }
            //return RedirectToAction(nameof(Index));

            return Json(reserva);
        }




        // GET: Reservas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reservas.FindAsync(id);
            if (reserva == null)
            {
                return NotFound();
            }
            return View(reserva);
        }

        // POST: Reservas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,IDReserva,Origen,Destino,FechayHoraSalida,Silla,Clase, Clase,Precio,NombreCliente,NumeroDocumento,Status")] Reserva reserva)
        {
            if (id != reserva.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reserva);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservaExists(reserva.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(reserva);
        }

        // GET: Reservas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reservas
                .FirstOrDefaultAsync(m => m.ID == id);
            if (reserva == null)
            {
                return NotFound();
            }

            return View(reserva);
        }

        // POST: Reservas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reserva = await _context.Reservas.FindAsync(id);
            _context.Reservas.Remove(reserva);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservaExists(int id)
        {
            return _context.Reservas.Any(e => e.ID == id);
        }
    }
}
