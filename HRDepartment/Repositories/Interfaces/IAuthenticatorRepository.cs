namespace HRDepartment
{
    public interface IAuthenticatorRepository
    {
        bool ChangePassword(int id, string previousPassword, string newPassword);
        int FindEmployee(string email, string password);
    }
}