namespace Test_Technique_Backend.Services.Exceptions
{
    // Cette classe définit une exception personnalisée pour les cas où une ressource n'est pas trouvée.

    public class NotFoundException
    : ApplicationException
    {
        public NotFoundException(string name, object key)
            : base($"{name} ({key}) is not found")
        {

        }
    }

}
