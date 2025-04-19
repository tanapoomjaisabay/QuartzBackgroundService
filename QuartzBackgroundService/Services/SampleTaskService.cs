using Quartz;

namespace QuartzBackgroundService.Services
{
    public class SampleTaskService : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            Console.WriteLine($"[SampleTaskJob] Start: {DateTime.Now}");
            Console.WriteLine($"[SampleTaskJob] End: {DateTime.Now}");
        }
    }
}
