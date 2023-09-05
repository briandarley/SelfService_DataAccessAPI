namespace UNC_SelfService_DataAccessAPI_Common.Entities.UtilityDb
{
    public class ProcessSchedule:BaseEntity
    {
        public int Id { get; set; }
        public int ProcessId { get; set; }
        public int? EnabledDays { get; set; }
        public string StartTime { get; set; }
        public bool? Enabled { get; set; }
        public string Comments { get; set; }
        public string RepeatCycle { get; set; }
        public int? RepeatInterval { get; set; }

        public virtual Process Process { get; set; }
    }
}
