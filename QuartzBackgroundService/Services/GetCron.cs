namespace QuartzBackgroundService.Services
{
    public static class GetCron
    {
        public static string GetNotiDayEndCron()
        {
            return "0 0 10 ? * MON-FRI";
        }

        public static string GetRemindDueDateCron()
        {
            var now = DateTime.Now;

            if (now.Month == 2) // ถ้าเดือนกุมภาพันธ์
            {
                return "0 0 18 7,17,27 * ?";
            }
            else
            {
                return "0 0 18 7,17,29 * ?";
            }
        }
    }
}
