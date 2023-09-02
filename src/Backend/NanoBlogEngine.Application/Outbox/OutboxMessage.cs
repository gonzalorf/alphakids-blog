namespace NanoBlogEngine.Application.Outbox;

public class OutboxMessage
{
    public Guid Id { get; set; }

    public DateTime OccurredOn { get; set; }

    public string Type { get; set; } = string.Empty;

    public string Data { get; set; } = string.Empty;

    public DateTime? ProcessedDate { get; set; }

    public string Error { get; set; } = string.Empty;

    private OutboxMessage()
    {

    }

    public OutboxMessage(DateTime occurredOn, string type, string data)
    {
        Id = Guid.NewGuid();
        OccurredOn = occurredOn;
        Type = type;
        Data = data;
    }
}
