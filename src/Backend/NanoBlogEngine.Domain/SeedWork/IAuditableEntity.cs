namespace NanoBlogEngine.Domain.SeedWork;
public interface IAuditableEntity
{
    string? CreatedBy { get; set; }
    DateTime? Created { get; set; }
    string? UpdatedBy { get; set; }
    DateTime? Updated { get; set; }
}
