using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TodoApp.Models;

namespace TodoApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        // Sample list of TodoItems (used for demonstration purposes; usually, this data would be fetched from a database)
        private static List<TodoItem> todoItems = new List<TodoItem>
        {
            new TodoItem { ID = 1, Title = "Buy Groceries", Description = "Milk, Eggs, Bread", IsDone = false }
        };

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // Action to display the ToDo list on the home screen
        public IActionResult Index()
        {
            return View(todoItems);
        }

        // Action to mark a task as done
        public IActionResult MarkAsDone(int id)
        {
            var todoItem = todoItems.Find(item => item.ID == id);
            if (todoItem != null)
            {
                todoItem.IsDone = true;
            }
            return RedirectToAction("Index");
        }

        // Action to delete a task
        public IActionResult Delete(int id)
        {
            var todoItem = todoItems.Find(item => item.ID == id);
            if (todoItem != null)
            {
                todoItems.Remove(todoItem);
            }
            return RedirectToAction("Index");
        }

        // Action to display the form for creating a new task (not requested but added for completeness)
        public IActionResult Create()
        {
            return View();
        }

        // POST Action to create a new task
        [HttpPost]
        public IActionResult Create(TodoItem newItem)
        {
            if (ModelState.IsValid)
            {
                // Assign a unique ID to the new item
                int newId = todoItems.Count > 0 ? todoItems.Max(item => item.ID) + 1 : 1;
                newItem.ID = newId;
                todoItems.Add(newItem);
                return RedirectToAction("Index");
            }
            // If the ModelState is not valid (e.g., validation failed), return the view with the newItem model to show the validation errors
            return View(newItem);
        }
    }
}
