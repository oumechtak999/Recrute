namespace Test_Technique_Backend.Services.Exceptions
{
    public class BadRequestException
    : ApplicationException
    {
        public BadRequestException(string message) : base(message)
        { }
    }
}
