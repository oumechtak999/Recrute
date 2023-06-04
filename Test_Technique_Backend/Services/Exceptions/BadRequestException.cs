namespace Test_Technique_Backend.Services.Exceptions
{
    // Cette classe définit une exception personnalisée pour les erreurs de requête.
    public class BadRequestException
    : ApplicationException
    {
        public BadRequestException(string message) : base(message)
        { }
    }
}
