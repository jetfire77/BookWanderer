namespace Tanuj.BookStore.Service
{
    public interface IUserService
    {
        string GetUserId();

        bool IsAuthenticated();
    }
}