namespace TaskManagementApi.Application.DTOs
{
    public class ReportDto
    {
        public int TotalTasks { get; set; }
        public int CompletedTasks { get; set; }
        public int PendingTasks { get; set; }
        public double CompletionRate { get; set; }
    }
}
