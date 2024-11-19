using CV_creator.Database;
using CV_creator.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CV_creator.Controllers
{
    public class CVsController : Controller
    {
        private readonly CvDbContext _context;

        public CVsController(CvDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var cvs = await _context.BasicInformations
                                     .Include(b => b.Educations)
                                     .Include(b => b.Jobs)
                                     .ToListAsync();

            return View(cvs);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cv = await _context.BasicInformations
                                    .Include(b => b.Educations)
                                    .Include(b => b.Jobs)
                                    .ThenInclude(j => j.Skills)
                                    .Include(b => b.ResidenceAddress)
                                    .FirstOrDefaultAsync(m => m.Id == id);

            if (cv == null)
            {
                return NotFound();
            }

            return View(cv);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstName,LastName,Email,PhoneNumber,BirthDate")] BasicInformation basicInformation)
        {
            ModelState.Remove("ResidenceAddress");
            
            if (ModelState.IsValid)
            {
                _context.Add(basicInformation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(basicInformation);
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cv = await _context.BasicInformations.FindAsync(id);
            if (cv == null)
            {
                return NotFound();
            }

            return View(cv);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, BasicInformation basicInformation)
        {
            if (id != basicInformation.Id)
            {
                return NotFound();
            }

            ModelState.Remove("ResidenceAddress");

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(basicInformation);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CVExists(basicInformation.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            return View(basicInformation);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cv = await _context.BasicInformations
                                   .FirstOrDefaultAsync(m => m.Id == id);
            if (cv == null)
            {
                return NotFound();
            }

            return View(cv);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cv = await _context.BasicInformations.FindAsync(id);
            _context.BasicInformations.Remove(cv);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool CVExists(int id)
        {
            return _context.BasicInformations.Any(e => e.Id == id);
        }
    }
}
