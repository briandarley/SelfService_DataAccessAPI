namespace UNC_SelfService_DataAccessAPI_Common.Entities.SelfServiceDb
{
    public class RouteScheduleDowntime: BaseEntity
    {
        public int Id { get; set; }
        public int RouteItemId { get; set; }
        public DateTimeOffset ScheduledOnDate { get; set; }
        public DateTimeOffset? ScheduledOffDate { get; set; }
        /// <summary>
        /// The route to switch to during the downtime
        /// </summary>
        public string NewRoute { get; set; }
        /// <summary>
        /// The route to switch back to after the downtime
        /// </summary>
        public string CurrentRoute { get; set; }
        /// <summary>
        /// Scheduled downtime is archived and not used again
        /// </summary>
        public bool Archived { get; set; }
        
        public RouteItem RouteItem { get; set; }
    }
}
