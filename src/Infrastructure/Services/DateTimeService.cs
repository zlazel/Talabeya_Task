using Talabeya_Task.Application.Common.Interfaces;

namespace Talabeya_Task.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}
