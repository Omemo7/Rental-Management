public interface IIdentityService
{
    Task<bool> IsEmailTaken(string email);
    Task<Guid> CreateUser(string email, string password);
}