using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Avianca.Data;
using Avianca.Models;

namespace Avianca.Controllers
{
    public class ReservaDespeguesController : Controller
    {
        private readonly AvianContext _context;

        public ReservaDespeguesController(AvianContext context)
        {
            _context = context;
        }

        // GET: ReservaDespegues
        public async Task<IActionResult> Index()
        {
            return View(await _context.ReservaDespegue.ToListAsync());
        }

        // GET: ReservaDespegues/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservaDespegue = await _context.ReservaDespegue
                .FirstOrDefaultAsync(m => m.ID == id);
            if (reservaDespegue == null)
            {
                return NotFound();
            }

            return View(reservaDespegue);
        }

        // GET: ReservaDespegues/Create
        public IActionResult Create(int ID, int idReserevadespegue, string pista, string clima, string aeropuerto, DateTime? FechayHora)
        {
            Avianca.Models.ReservaDespegue  reserva = new ReservaDespegue();
            reserva.IDReservaDespegue = idReserevadespegue;
            reserva.Pista = pista;
            reserva.Clima = clima;
            reserva.Aeropuerto = aeropuerto;
            reserva.FechayHora = FechayHora;           
            return View(reserva);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,IDReservaDespegue,Pista,Clima,Aeropuerto,FechayHora")] ReservaDespegue reservaDespegue)
        {
            if (ModelState.IsValid)
            {
                var status = "";
                if (reservaDespegue.Aeropuerto.Equals("Alfonso Bonilla"))
                {
                    status = Services.AviancaServices.SaveReservaAeropuerto(reservaDespegue).ToString();
                }
                if (!status.Equals(""))
                {
                    _context.Add(reservaDespegue);
                    await _context.SaveChangesAsync();
                }

                return RedirectToAction(nameof(Index));                
            }
            return View(reservaDespegue);          
           
        }

        // GET: ReservaDespegues/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservaDespegue = await _context.ReservaDespegue.FindAsync(id);
            if (reservaDespegue == null)
            {
                return NotFound();
            }
            return View(reservaDespegue);
        }

        // POST: ReservaDespegues/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,IDReservaDespegue,Pista,Clima,Aeropuerto,FechayHora")] ReservaDespegue reservaDespegue)
        {
            if (id != reservaDespegue.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reservaDespegue);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservaDespegueExists(reservaDespegue.ID))
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
            return View(reservaDespegue);
        }

        // GET: ReservaDespegues/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservaDespegue = await _context.ReservaDespegue
                .FirstOrDefaultAsync(m => m.ID == id);
            if (reservaDespegue == null)
            {
                return NotFound();
            }

            return View(reservaDespegue);
        }

        // POST: ReservaDespegues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reservaDespegue = await _context.ReservaDespegue.FindAsync(id);
            _context.ReservaDespegue.Remove(reservaDespegue);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservaDespegueExists(int id)
        {
            return _context.ReservaDespegue.Any(e => e.ID == id);
        }
    }
}
