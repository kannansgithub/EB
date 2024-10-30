using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Data.Common;
using System.Diagnostics;

namespace EB.Persistence.Interceptors;

public class PerformanceInterceptor : DbCommandInterceptor
{
    private const long QuerySlowThreshold = 100; // milliseconds

    public override InterceptionResult<DbDataReader> ReaderExecuting(
        DbCommand command,
        CommandEventData eventData,
        InterceptionResult<DbDataReader> result)
    {
        Stopwatch stopwatch = Stopwatch.StartNew();
        //command.CommandText += "IsActive=1";
        var originalResult = base.ReaderExecuting(command, eventData, result);

        stopwatch.Stop();
        if (stopwatch.ElapsedMilliseconds > QuerySlowThreshold)
        {
            Console.WriteLine($"Slow Query Detected: {command.CommandText}");
        }

        return originalResult;
    }
}
