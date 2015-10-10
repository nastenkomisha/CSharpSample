namespace PayPalTests.Model
{
    public class AccountData
    {
        public AccountData(string username, string password)
        {
            Username = username;
            Password = password;
        }
        public string Username { get; }
        public string Password { get; }
    }
}
