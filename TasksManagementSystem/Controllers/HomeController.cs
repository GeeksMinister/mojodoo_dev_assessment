using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TasksManagementSystem.DataAccess.Data.TodoData;
using TasksManagementSystem.Models;

namespace TasksManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITodoData _todoData;

        public HomeController(ILogger<HomeController> logger, ITodoData todoData)
        {
            _logger = logger;
            _todoData = todoData;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _todoData.GetAll());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Todo todo)
        {
            if (ModelState.IsValid)
            {
                _todoData.InsertTodo(todo);
                return RedirectToAction(nameof(Index));
            }
            return View(todo);
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null || id <= 0) return NotFound();
            var todo = await _todoData.GetById(id);
            if (todo == null) return NotFound();
            return View(todo);
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePost(Todo todo)
        {
            if (ModelState.IsValid)
            {
                await _todoData.UpdateTodo(todo);
                return RedirectToAction(nameof(Index));
            }
            return View(todo);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id <= 0) return NotFound();
            var todo = _todoData.GetById(id);
            if (todo == null) return NotFound();
            return View(todo);
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int? id)
        {
            await _todoData.DeleteTodo(id);
            return RedirectToAction(nameof(Index));
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}