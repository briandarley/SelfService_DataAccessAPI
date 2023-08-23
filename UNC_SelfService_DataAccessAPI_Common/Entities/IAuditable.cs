namespace UNC_SelfService_DataAccessAPI_Common.Entities
{
    public interface IAuditable
    {
        public DateTime CreateDate { get; set; }
        public DateTime? ChangeDate { get; set; }
        public string CreateUser { get; set; }
        public string ChangeUser { get; set; }
    }
}
