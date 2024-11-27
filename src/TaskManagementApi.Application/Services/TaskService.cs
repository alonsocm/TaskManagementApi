using TaskManagementApi.Application.DTOs;
using TaskManagementApi.Core.Entities.TaskManagementApi.Core.Entities;
using TaskManagementApi.Core.Interfaces;

namespace TaskManagementApi.Application.Services
{
    public class TaskService
    {
        private readonly ITaskRepository _repository;

        public TaskService(ITaskRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<TaskItem>> GetAllTasksAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<TaskItem> GetTaskByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<TaskItem> CreateTaskAsync(TaskDto task)
        {
            var newTask = new TaskItem
            {
                Id = Guid.NewGuid(),
                Title = task.Title,
                Description = task.Description,
                Priority = task.Priority,
                Status = task.Status,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            await _repository.AddAsync(newTask);
            return newTask;
        }

        public async Task<bool> UpdateTaskAsync(TaskUpdateDto task)
        {
            var taskDB = await GetTaskByIdAsync(task.Id);

            if (taskDB == null)
            {
                return false;
            }

            taskDB.Title = task.Title;
            taskDB.Description = task.Description;
            taskDB.Priority = task.Priority;
            taskDB.Status = task.Status;
            taskDB.UpdatedAt = DateTime.Now;

            await _repository.UpdateAsync(taskDB);
            return true;
        }

        public async Task<bool> DeleteTaskAsync(Guid id)
        {
            var taskDB = await GetTaskByIdAsync(id);

            if (taskDB == null)
            {
                return false;
            }

            await _repository.DeleteAsync(id);
            return true;
        }

        public async Task<ReportDto> GenerateReportAsync()
        {
            var tasks = await _repository.GetAllAsync();
            var completedTasks = tasks.Count(t => t.Status == Status.Completed);
            var pendingTasks = tasks.Count(t => t.Status == Status.Pending);
            var totalTasks = tasks.Count();

            return new ReportDto
            {
                TotalTasks = totalTasks,
                CompletedTasks = completedTasks,
                PendingTasks = pendingTasks,
                CompletionRate = totalTasks > 0 ? (completedTasks / (double)totalTasks) * 100 : 0
            };
        }
    }
}
