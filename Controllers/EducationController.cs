using CV_creator.Database;
using CV_creator.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CV_creator.Controllers
{
    public class EducationController : Controller
    {
        private readonly CvDbContext _context;

        public EducationController(CvDbContext context)
        {
            _context = context;
        }

        public IActionResult AddEducation(int cvId)
        {
            var cv = _context.BasicInformations
                              .Include(b => b.Educations)
                              .FirstOrDefault(b => b.Id == cvId);

            if (cv == null)
            {
                return NotFound();
            }

            var education = new Education { BasicInformationId = cvId };

            return View(education);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddEducation(Education education)
        {
            ModelState.Remove("InstitutionAddress");
            
            var basicInfo = await _context.BasicInformations
                               .FirstOrDefaultAsync(b => b.Id == education.BasicInformationId);

            if (basicInfo == null)
            {
                return NotFound();
            }

            ModelState.Remove("BasicInformation");

            if (ModelState.IsValid)
            {
                _context.Educations.Add(education);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "CVs", new { id = education.BasicInformationId });
            }

            return View(education);
        }

        public IActionResult Edit(int id)
        {
            var education = _context.Educations
                                    .FirstOrDefault(e => e.Id == id);

            if (education == null)
            {
                return NotFound();
            }

            return View(education);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Education education)
        {
            if (id != education.Id)
            {
                return NotFound();
            }

            ModelState.Remove("InstitutionAddress");
            ModelState.Remove("BasicInformation");
            
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(education);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Educations.Any(e => e.Id == education.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", "CVs", new { id = education.BasicInformationId });
            }

            return View(education);
        }

        public IActionResult Delete(int id)
        {
            var education = _context.Educations
                                    .FirstOrDefault(e => e.Id == id);
            if (education == null)
            {
                return NotFound();
            }

            return View(education);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var education = await _context.Educations.FindAsync(id);

            if (education == null)
            {
                return NotFound();
            }

            _context.Educations.Remove(education);
            await _context.SaveChangesAsync();

            return RedirectToAction("Details", "CVs", new { id = education.BasicInformationId }); 
        }

    }
}
