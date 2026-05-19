using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using NTierTodoApp.Business;

namespace NTierTodoApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly TaskService taskService;

        public HomeController(TaskService service) => taskService = service;

        public IActionResult Index() => View(taskService.GetTasks());
    

        [HttpPost]
        public IActionResult AddTask(string title)
            {
            if (!string.IsNullOrWhiteSpace(title))
                taskService.AddTask(title);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult CompleteTask(int id)
            {
            taskService.CompleteTask(id);
            return RedirectToAction("Index");
        }
        // تنفيذ دالة تعديل عنوان المهمة 
        [HttpPost]
        public IActionResult EditTask(int id, string newTitle)
        {
            if (!string.IsNullOrWhiteSpace(newTitle))
            {
                taskService.EditTask(id, newTitle);
            }
            return RedirectToAction("Index");
        } 


        // TODO: تنفيذ إجراء لحذف المهمة
        [HttpPost]
        public IActionResult DeleteTask(int id)
            {
            taskService.DeleteTask(id);
            return RedirectToAction("Index");
        }
    }
}