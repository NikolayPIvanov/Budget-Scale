using System;

namespace BudgetScale.Domain.Entities
{
    public class LongRequest
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string RequestDescription { get; set; }

        public string ElapsedMilliseconds { get; set; }

        public DateTime Time { get; set; } = DateTime.UtcNow;
    }
}