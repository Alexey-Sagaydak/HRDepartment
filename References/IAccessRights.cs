namespace References
{
    public interface IAccessRights
    {
        bool Delete { get; set; }
        bool Edit { get; set; }
        bool Read { get; set; }
        bool Wright { get; set; }
    }
}