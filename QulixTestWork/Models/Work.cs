using System;

namespace QulixTestWork
{
    public class Work
    {
        public int Id { get; set; }
        public string WorkName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int ImplementerId { get; set; }
        public Implementer Implementer { get; set; }
        public Status Status { get; set; }
    }


    public enum Status
    {
        Wait = 1,
        InProgrees,
        IsFinished,
        Postponed
    }
}
