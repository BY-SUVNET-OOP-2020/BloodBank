namespace BloodbankCore
{
    public interface ILogin
    {
        bool AuthenticateLogin(string userName, string password);
    }
}