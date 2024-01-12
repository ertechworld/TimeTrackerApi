namespace TimeTracker.DTO.Userattendance
{
    public class HourListDto
    {
        public decimal TotalDuration { get; private set; }
        public IList<Detail> Details { get; set; }
        public void CalculateTotalDuration()
        {
            if (Details == null || Details.Count == 0)
            {
                TotalDuration = 0;
                return;
            }
            TotalDuration = (decimal)Details
                .Where(detail => !string.IsNullOrWhiteSpace(detail.Duration))
                .Sum(detail => decimal.TryParse(detail.Duration, out decimal duration) ? duration : 0);
        }
        public class Detail
        {
            public int Id { get; set; }
            public string? StatusName { get; set; }
            public DateTime? CheckoutTime { get; set; }
            public int UserId { get; set; }
            public DateTime? CheckInTime { get; set; }
            public string? Description { get; set; }
            public bool? ReportGenerated { get; set; }
            public string? Duration { get; set; }
            public string? TaskName { get; set; }
            public string? ExtraHoursDuration { get; set; }
            public string? ProjectName { get; set; }
            public string? JobTypeName { get; set; }
            public string? UserHourlyRate { get; set; }
            public string? UserWorkingHours { get; set; }
            public bool? UserIsBreakIncluded { get; set; }
            public int? WeekId { get; set; }
            public DateTime WeekStart { get; set; }
            public DateTime WeekEnd { get; set; }
            public string FormattedWeekStart => WeekStart.ToString("dddd, dd MMMM yyyy");
            public string FormattedWeekEnd => WeekEnd.ToString("dddd, dd MMMM yyyy");

        }
    }
}
