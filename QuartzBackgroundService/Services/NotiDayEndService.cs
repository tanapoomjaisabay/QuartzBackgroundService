using Quartz;

namespace QuartzBackgroundService.Services
{
    public class NotiDayEndService : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            Console.WriteLine($"[NotiDayEndJob] Start: {DateTime.Now}");
            Console.WriteLine($"[NotiDayEndJob] End: {DateTime.Now}");
        }
    }
}
