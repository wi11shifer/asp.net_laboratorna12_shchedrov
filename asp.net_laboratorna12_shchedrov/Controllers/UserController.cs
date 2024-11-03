using asp.net_laboratorna12_shchedrov.Data;
using asp.net_laboratorna12_shchedrov.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace asp.net_laboratorna12_shchedrov.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _context.Users.ToListAsync();
            return View(users);
        }

        [HttpPost]
        public async Task<IActionResult> Create()
        {
            var users = new List<User>
            {
                new User { FirstName = "Bohdan", LastName = "Shschedrov", Age = 19 },
                new User { FirstName = "Jane", LastName = "Smith", Age = 30 },
                new User { FirstName = "Sam", LastName = "Johnson", Age = 22 }
            };

            await _context.Users.AddRangeAsync(users);
            await _context.SaveChangesAsync();

            var savedUsers = await _context.Users.ToListAsync();
            foreach (var user in savedUsers)
            {
                Console.WriteLine($"ID: {user.Id}, Name: {user.FirstName} {user.LastName}, Age: {user.Age}");
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
