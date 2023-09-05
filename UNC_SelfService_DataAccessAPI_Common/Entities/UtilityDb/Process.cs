namespace UNC_SelfService_DataAccessAPI_Common.Entities.UtilityDb
{
    public class Process:BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ProcessType { get; set; }
        public string Arguments { get; set; }
        public string Description { get; set; }
        public bool? Enabled { get; set; }
        public string AppDomain { get; set; }
        public string QueueName { get; set; }
        public int? ExpiryTimeSeconds { get; set; }
        public virtual List<ProcessSchedule> ProcessSchedules { get; set; }
    }
}
