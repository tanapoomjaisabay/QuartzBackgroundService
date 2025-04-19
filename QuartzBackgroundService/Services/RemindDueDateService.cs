using Quartz;

namespace QuartzBackgroundService.Services
{
    public class RemindDueDateService : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            Console.WriteLine($"[RemindDueDateJob] Start: {DateTime.Now}");
            Console.WriteLine($"[RemindDueDateJob] End: {DateTime.Now}");
        }
    }
}
