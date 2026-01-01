namespace MVCSaller.Services.Exceptions
{
    public class DbConCurrrencyException : ApplicationException
    {
        public DbConCurrrencyException(string message) : base(message)
        {
        }
    }
}
