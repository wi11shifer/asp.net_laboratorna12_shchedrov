using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using asp.net_laboratorna12_shchedrov.Data;
using asp.net_laboratorna12_shchedrov.Models;

namespace asp.net_laboratorna12_shchedrov.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CompanyController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var companies = await _context.Companies.ToListAsync();
            return View(companies);
        }

        [HttpPost]
        public async Task<IActionResult> Create()
        {
            var companies = new List<Company>
            {
                new Company { Name = "Apple", Address = "123 Tech Lane" },
                new Company { Name = "Google", Address = "456 Business St." },
                new Company { Name = "Mogylyanka", Address = "789 Shop Blvd" },
                new Company { Name = "Miscrosoft", Address = "101 Innovate Ave" },
                new Company { Name = "Valve", Address = "202 Create Rd" }
            };

            await _context.Companies.AddRangeAsync(companies);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}