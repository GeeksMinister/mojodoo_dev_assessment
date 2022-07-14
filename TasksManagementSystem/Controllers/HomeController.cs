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
        [Route("byOldest")]
        [Route("byNewest")]
        [Route("byPriority")]
        [Route("Name")]
        [Route("byStatus")]
        [Route("byName")]
        public async Task<IActionResult> Index()
        {
            try
            {
                string route = Request?.Path.Value!;
                var result = await SortOutTasks(route);
                return View(result);
            }
            catch (Exception ex)
            {
                return Problem("[Database Was NOT Found]" + ex.Message);
            }
        }

        public async Task<IEnumerable<Todo>> SortOutTasks(string? route)
        {
            var result = await _todoData.GetAll();
            switch (route)
            {
                case "/byNewest":
                    return result.ToList().OrderByDescending(todo => todo.Id);
                case "/byName":
                    return result.ToList().OrderBy(todo => todo.TaskName);
                case "/byPriority":
                    return result.ToList().OrderBy(todo => todo.Priority);
                case "/byStatus":
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
            try
            {
                if (ModelState.IsValid)
                {
                    _todoData.InsertTodo(todo);
                    return RedirectToAction(nameof(Index));
                }
                return View(todo);
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }
        }

        public async Task<IActionResult> Update(int? id)
        {
            try
            {
                if (id == null || id <= 0) return NotFound();
                var todo = await _todoData.GetById(id);
                if (todo == null) return NotFound();
                return View(todo);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update_Post(Todo todo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _todoData.UpdateTodo(todo);
                    return RedirectToAction(nameof(Index));
                }
                return View(todo);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (id == null || id <= 0) return NotFound();
                var todo = await _todoData.GetById(id);
                if (todo == null) return NotFound();
                return View(todo);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete_Post(int? id)
        {
            try
            {
                await _todoData.DeleteTodo(id);
                return RedirectToAction(nameof(Index));

            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        public IActionResult Search()
        {
            return View();
        }

        public async Task<IActionResult> ShowSearchResults(string status, string tag, string searchTerm)
        {
            try
            {
                var result = await _todoData.SearchTodo(status, tag, searchTerm);
                return View(result);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}