namespace UNC_SelfService_DataAccessAPI_Common.Entities.SelfServiceDb
{
    public class RouteItemTag
    {
        public int Id { get; set; }
        public int RouteItemId { get; set; }
        public string Tag { get; set; }

        public RouteItem RouteItem { get; set; }
    }
}
