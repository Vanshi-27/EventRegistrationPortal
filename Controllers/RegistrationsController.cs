using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EventRegistrationPortal.Models;
using EventRegistrationPortal;


namespace EventRegistrationPortal.Controllers
{
    public class RegistrationsController : Controller
    {
        private readonly AppDbContext _context;

        public RegistrationsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Registrations
        public async Task<IActionResult> Index()
        {
            var registrations = await _context.Registrations
                .Include(r => r.Event)
                .ToListAsync();
            return View(registrations);
        }

        // GET: Registrations/Create
        public IActionResult Create()
        {
            ViewData["EventId"] = new SelectList(_context.Events, "Id", "Title");
            return View();
        }

        // POST: Registrations/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
       // GET: Registrations/Edit/5
public async Task<IActionResult> Edit(int? id)
{
    if (id == null) return NotFound();
    var registration = await _context.Registrations.FindAsync(id);
    if (registration == null) return NotFound();
    return View(registration);
}

[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Edit(int id, Registration registration)
{
    if (id != registration.Id) return NotFound();

    if (ModelState.IsValid)
    {
        _context.Update(registration);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
    return View(registration);
}

// GET: Registrations/Delete/5
public async Task<IActionResult> Delete(int? id)
{
    if (id == null) return NotFound();
    var registration = await _context.Registrations
        .Include(r => r.Event)
        .FirstOrDefaultAsync(m => m.Id == id);
    if (registration == null) return NotFound();
    return View(registration);
}

// POST: Registrations/Delete/5
[HttpPost, ActionName("Delete")]
[ValidateAntiForgeryToken]
public async Task<IActionResult> DeleteConfirmed(int id)
{
    var registration = await _context.Registrations.FindAsync(id);
    _context.Registrations.Remove(registration);
    await _context.SaveChangesAsync();
    return RedirectToAction(nameof(Index));
}

    }
}
