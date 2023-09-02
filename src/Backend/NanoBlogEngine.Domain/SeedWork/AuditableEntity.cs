namespace NanoBlogEngine.Domain.SeedWork;

public abstract class AuditableEntity<TIdType> : Entity<TIdType>, IAuditableEntity where TIdType : TypedIdValueBase
{
    public string? CreatedBy { get; set; }
    public DateTime? Created { get; set; }
    public string? UpdatedBy { get; set; }
    public DateTime? Updated { get; set; }

    protected AuditableEntity(TIdType id) : base(id) { }
    protected AuditableEntity() { }

}
