using Microsoft.EntityFrameworkCore;
using TaskManagementApi.Core.Entities.TaskManagementApi.Core.Entities;

namespace TaskManagementApi.Infrastructure.Data
{
    public class TaskContext : DbContext
    {
        public TaskContext(DbContextOptions<TaskContext> options) : base(options) { }

        public DbSet<TaskItem> TaskItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Datos iniciales
            modelBuilder.Entity<TaskItem>().HasData(
                new TaskItem
                {
                    Id = Guid.NewGuid(),
                    Title = "Tarea inicial 1",
                    Description = "Descripción de la tarea inicial 1",
                    Priority = Priority.High,
                    Status = Status.Pending,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new TaskItem
                {
                    Id = Guid.NewGuid(),
                    Title = "Tarea inicial 2",
                    Description = "Descripción de la tarea inicial 2",
                    Priority = Priority.Medium,
                    Status = Status.Completed,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }
            );
        }
    }
}
