using System.Diagnostics;
using DAL.Interface;
using Microsoft.AspNetCore.Mvc;
using Project.Common.TaskItemModel;
using SimpleTaskProject.Models;

namespace SimpleTaskProject.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly ITaskRepository _taskRepository;
        public HomeController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }
        [HttpPost]
        public async Task Create(TaskModel model)
        {
            await _taskRepository.Create(model);
        }

        [HttpGet]
        public async Task<ActionResult<List<TaskModel>>> GetAllTasks()
        {
            var tasks = await _taskRepository.GetAllTasks();
            return Ok(tasks);
        }
        
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, TaskModel model)
        {
            var result = await _taskRepository.Update(id, model);

            if (result == "Task not found")
            {
                return NotFound();
            }

            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _taskRepository.Delete(id);
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    } 
}
