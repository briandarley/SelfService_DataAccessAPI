namespace UNC_SelfService_DataAccessAPI_Common.Entities.SelfServiceDb
{
    public class MenuItem:BaseEntity
    {
        public int Id { get; set; }
        public int RouteItemId { get; set; }
        public string MenuText { get; set; }
        public string Icon { get; set; }
        public string Category { get; set; }
        public int Order { get; set; }
        public int? ParentMenuItemId { get; set; }
        public virtual RouteItem RouteItem { get; set; }
        public virtual MenuItem ParentMenuItem { get; set; }
        public virtual ICollection<MenuItem> ChildMenuItems { get; set; }


    }
}
