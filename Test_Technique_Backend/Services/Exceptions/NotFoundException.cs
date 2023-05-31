namespace Test_Technique_Backend.Services.Exceptions
{
    public class NotFoundException
    : ApplicationException
    {
        public NotFoundException(string name, object key)
            : base($"{name} ({key}) is not found")
        {

        }
    }

}
