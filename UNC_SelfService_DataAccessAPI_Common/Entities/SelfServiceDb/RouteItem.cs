namespace UNC_SelfService_DataAccessAPI_Common.Entities.SelfServiceDb
{
    public class RouteItem:BaseEntity
    {
        public int Id { get; set; }
        public string Route { get; set; }
        public string FilePath { get; set; }
        public string FileName { get; set; }
        public string Description { get; set; }
        public string SearchDescription { get; set; }
        public bool Searchable { get; set; }
        public string LinkText { get; set; }
        public bool RequireAuth { get; set; }
        public bool RequireMfa { get; set; }

        public virtual ICollection<RouteItemTag> RouteItemTags { get; set; }
        
    }
}
