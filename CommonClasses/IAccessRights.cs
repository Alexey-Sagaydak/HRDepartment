namespace CommonClasses
{
    public interface IAccessRights
    {
        bool Delete { get; set; }
        bool Edit { get; set; }
        int MenuItemId { get; set; }
        bool Read { get; set; }
        int UserId { get; set; }
        bool Wright { get; set; }
    }
}