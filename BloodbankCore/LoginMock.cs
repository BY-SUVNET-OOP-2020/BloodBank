namespace BloodbankCore
{
    public class LoginMock : ILogin
    {
        public bool AuthenticateLogin(string userName, string password)
        {
            return true;
        }
    }
}