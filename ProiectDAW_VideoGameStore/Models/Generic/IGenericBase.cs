namespace ProiectDAW_VideoGameStore.Models.Generic
{
    public class IGenericBase
    {
        Guid Id { get; set; }
        DateTime? DateCreated { get; set; }
        DateTime? LastModified { get; set; }
    }
}
