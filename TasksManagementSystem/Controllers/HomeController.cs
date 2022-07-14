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

        [Route("/")]
        [Route("Oldest")]
        [Route("Newest")]
        [Route("Name")]
        [Route("Priority")]
        [Route("Status")]
        public async Task<IActionResult> Index()
        {
            string route = Request?.Path.Value!;
            var result = await SortOutTasks(route);
            return View(result);
        }

        public async Task<IEnumerable<Todo>> SortOutTasks(string? route)
        {
            var result = await _todoData.GetAll();
            
            switch (route)
            {
                case "/Newest":
                    return result.ToList().OrderByDescending(todo => todo.Id);
                case "/Name":
                    return result.ToList().OrderBy(todo => todo.TaskName);
                case "/Priority":
                    return result.ToList().OrderBy(todo => todo.Priority);
                case "/Status":
                    return result.ToList().OrderBy(todo => todo.Status);
                default:
                    return result;
            }
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create_Post(Todo todo)
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
        public async Task<IActionResult> Update_Post(Todo todo)
        {
            if (ModelState.IsValid)
            {
                await _todoData.UpdateTodo(todo);
                return RedirectToAction(nameof(Index));
            }
            return View(todo);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id <= 0) return NotFound();
            var todo = await _todoData.GetById(id);
            if (todo == null) return NotFound();
            return View(todo);
        }

        [HttpPost]
        public async Task<IActionResult> Delete_Post(int? id)
        {
            await _todoData.DeleteTodo(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Search()
        {
            return View();
        }

        public async Task<IActionResult> ShowSearchResults(string status, string searchTerm)
        {
            return View(await _todoData.SearchTodo(status, searchTerm));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}