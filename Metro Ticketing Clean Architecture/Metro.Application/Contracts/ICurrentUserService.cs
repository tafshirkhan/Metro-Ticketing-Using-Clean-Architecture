namespace Metro.Application.Contracts
{
    public interface ICurrentUserService
    {
        //string ClientId { get; }
        Guid? UserId { get; }
        //string Role { get; }
        //string Token { get; }
    }
}
