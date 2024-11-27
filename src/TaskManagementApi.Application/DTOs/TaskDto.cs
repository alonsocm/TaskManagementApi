using System.ComponentModel.DataAnnotations;
using TaskManagementApi.Core.Entities.TaskManagementApi.Core.Entities;

namespace TaskManagementApi.Application.DTOs
{
    public class TaskDto
    {
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        [EnumDataType(typeof(Priority))]
        public Priority Priority { get; set; }
        [EnumDataType(typeof(Status))]
        public Status Status { get; set; }
    }
}
