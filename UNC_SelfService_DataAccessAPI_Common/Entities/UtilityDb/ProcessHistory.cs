namespace UNC_SelfService_DataAccessAPI_Common.Entities.UtilityDb
{
    public class ProcessHistory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? Failed { get; set; }
        public string Source { get; set; }
        public string MachineName { get; set; }
        public string Remarks { get; set; }
        public string Arguments { get; set; }
        public string ErrorMessage { get; set; }
    }
}
