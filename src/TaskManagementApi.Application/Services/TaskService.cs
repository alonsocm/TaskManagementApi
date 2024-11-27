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

        public async Task CreateTaskAsync(TaskItem task)
        {
            await _repository.AddAsync(task);
        }

        public async Task UpdateTaskAsync(TaskItem task)
        {
            await _repository.UpdateAsync(task);
        }

        public async Task DeleteTaskAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
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
