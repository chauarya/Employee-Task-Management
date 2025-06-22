
using EmployeeTaskManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeTaskManagement.Controllers
{
    public class TaskController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TaskController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var tasks = await _context.TaskItems.Include(t => t.Employee).ToListAsync();
            return View(tasks);
        }

        public IActionResult Create()
        {
            ViewBag.Employees = _context.Employees.ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(TaskItem task)
        {
            if (ModelState.IsValid)
            {
                _context.Add(task);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            foreach (var key in ModelState.Keys)
            {
                var errors = ModelState[key].Errors;
                foreach (var error in errors)
                {
                    Console.WriteLine($"Validation error for '{key}': {error.ErrorMessage}");
                }
            }

            ViewBag.Employees = _context.Employees.ToList();
            return View(task);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var task = await _context.TaskItems.FindAsync(id);
            ViewBag.Employees = _context.Employees.ToList();
            return View(task);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(TaskItem task)
        {
            if (ModelState.IsValid)
            {
                _context.Update(task);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // 🛠️ Optional: Add this line too for consistency
            ViewBag.Employees = _context.Employees.ToList();
            return View(task);
        }
    }
}
