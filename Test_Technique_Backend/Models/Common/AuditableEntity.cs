namespace Test_Technique_Backend.Models.Common
{
    // Cette classe inclut des propriétés de suivi de l'audit pour la gestion des entités dans l'application.
    public class AuditableEntity
    {
        public Guid Id { get; set; }
        public DateTime Created { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? LastModified { get; set; }
        public string? LastModifiedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}
