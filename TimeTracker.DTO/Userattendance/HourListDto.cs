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
           
            public DateTime? CheckoutTime { get; set; }
           
            public DateTime? CheckInDateTime { get; set; }
         
            public string? Duration { get; set; }
           
        }
    }
}
