using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MywebApiApp.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MywebApiApp.Controllers
{
    [Route("api/[controller]")]
    public class TasksController : Controller
    {
        private static List<TaskItem> tasks = new List<TaskItem>
        {
            new TaskItem { Id = 1, Title = "Learn Angular", IsCompleted = false },
            new TaskItem { Id = 2, Title = "Build Web API", IsCompleted = true }
        };

        [HttpGet]
        public ActionResult<IEnumerable<TaskItem>> Get() => Ok(tasks);

        [HttpGet("{id}")]
        public ActionResult<TaskItem> Get(int id)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);
            return task == null ? NotFound() : Ok(task);
        }

        [HttpPost]
        public ActionResult<TaskItem> Post([FromBody] TaskItem task)
        {
            task.Id = tasks.Max(t => t.Id) + 1;
            Console.WriteLine($"Received title: {task.Title}");

            // Simulate saving — be sure you're not overwriting title accidentally
            
            tasks.Add(task);
            return CreatedAtAction(nameof(Get), new { id = task.Id }, task);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, TaskItem updatedTask)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task == null) return NotFound();

            task.Title = updatedTask.Title;
            task.IsCompleted = updatedTask.IsCompleted;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task == null) return NotFound();

            tasks.Remove(task);
            return NoContent();
        }
    }
}

