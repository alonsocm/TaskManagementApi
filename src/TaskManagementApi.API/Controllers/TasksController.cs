using Microsoft.AspNetCore.Mvc;
using TaskManagementApi.Application.DTOs;
using TaskManagementApi.Application.Services;

namespace TaskManagementApi.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly TaskService _taskService;

        public TasksController(TaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] TaskDto task)
        {
            if (string.IsNullOrWhiteSpace(task.Title))
            {
                return BadRequest("Title is required.");
            }

            var newTask = await _taskService.CreateTaskAsync(task);
            return CreatedAtAction(nameof(GetTaskById), new { id = newTask.Id }, newTask);
        }

        [HttpGet]
        public async Task<IActionResult> GetTasks()
        {
            var tasks = await _taskService.GetAllTasksAsync();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskById(Guid id)
        {
            var task = await _taskService.GetTaskByIdAsync(id);

            if (task == null)
            {
                return NotFound();
            }

            return Ok(task);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(Guid id, [FromBody] TaskUpdateDto task)
        {
            if (id != task.Id)
            {
                return BadRequest();
            }

            if (await _taskService.UpdateTaskAsync(task))
            {
                return NoContent();
            }

            return BadRequest("Task not found");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(Guid id)
        {
            if (await _taskService.DeleteTaskAsync(id))
            {
                return NoContent();
            }

            return BadRequest("Task not found");
        }

        [HttpGet("report")]
        public async Task<IActionResult> GetTasksReport()
        {
            var report = await _taskService.GenerateReportAsync();
            return Ok(report);
        }
    }
}
