namespace BloodbankCore
{
    interface ILogin
    {
        bool AuthenticateLogin(string userName, string password);
    }
}