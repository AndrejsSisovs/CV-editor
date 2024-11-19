using CV_creator.Database;
using CV_creator.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace CV_creator.Controllers
{
    public class AddressController : Controller
    {
        private readonly CvDbContext _context;

        public AddressController(CvDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> AddressDetailsOfEducation(int educationId)
        {
            var education = await _context.Educations
                .Include(e => e.InstitutionAddress)
                .FirstOrDefaultAsync(e => e.Id == educationId);

            if (education == null)
            {
                return NotFound();
            }

            return View(education);
        }
        
        public IActionResult AddAddress(int? educationId, int? basicInformationId)
        {
            var model = new Address
            {
                EducationId = educationId,
                BasicInformationId = basicInformationId
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddAddress(Address address)
        {
            _context.Add(address);
            await _context.SaveChangesAsync();

            if (address.EducationId != null)
                return RedirectToAction("AddressDetailsOfEducation", "Address", new { educationId = address.EducationId });
            
            if (address.BasicInformationId != null)
                return RedirectToAction("Details", "CVs", new { id = address.BasicInformationId });

            return RedirectToAction("Index");
        }
        
        public async Task<IActionResult> EditAddress(int id)
        {
            var address = await _context.Addresses.FindAsync(id);

            if (address == null)
            {
                return NotFound();
            }

            return View(address);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAddress(Address address)
        {
            _context.Update(address);
            await _context.SaveChangesAsync();

            if (address.EducationId != null)
                return RedirectToAction("AddressDetailsOfEducation", "Address", new { educationId = address.EducationId });

            if (address.BasicInformationId != null)
                return RedirectToAction("Details", "CVs", new { id = address.BasicInformationId });
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteAddress(int addressId)
        {
            var address = await _context.Addresses.
                FirstOrDefaultAsync(a => a.Id == addressId);

            if (address == null)
            {
                return NotFound();
            }

            _context.Addresses.Remove(address);
            await _context.SaveChangesAsync();

            if (address.BasicInformationId != null)
            {
                return RedirectToAction("Details", "CVs", new { id = address.BasicInformationId });
            }
            
            if (address.EducationId != null)
            {
                return RedirectToAction("AddressDetailsOfEducation", "Address", new { educationId = address.EducationId});
            }

            return RedirectToAction("Index", "CVs");
        }
    }
}
