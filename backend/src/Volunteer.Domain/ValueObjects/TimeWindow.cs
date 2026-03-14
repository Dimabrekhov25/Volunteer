using System.IO.MemoryMappedFiles;
using CSharpFunctionalExtensions;

namespace Volunteer.Domain.ValueObjects;

public sealed record TimeWindow
{

    public TimeWindow()
    {
    }
    private TimeWindow(DateTime start, DateTime end)
    {
        From = start;
        To = end;
    }
    
    
    
    public DateTimeOffset From { get; init; }
    public DateTimeOffset To { get; init; }

    public static Result<TimeWindow,string> Create(DateTime start, DateTime end)
    {
        if (start >= end)
        {
            return Result.Failure<TimeWindow,string>("start must be less than end");
        }

        var timeWindow = new TimeWindow(start, end); 
        return Result.Success<TimeWindow,string>(timeWindow);
    }
    
    
    
}