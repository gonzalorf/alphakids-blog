using NanoBlogEngine.Application.Common.Services;

namespace NanoBlogEngine.Infrastructure.Services;

public class DateTimeService : IDateTimeService
{
    public DateTime Now => DateTime.Now;
}
