using EB.Domain.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace EB.Domain.Bases;

public abstract class BaseEntity : IHasSequentialId
{
    [Key]
    public string Id { get; set; } = null!;

    public BaseEntity()
    {
        Id = GenerateSequentialGuid();
    }

    private static readonly object _lock = new(); // Thread safety

    private static string GenerateSequentialGuid()
    {
        byte[] guidArray = Guid.NewGuid().ToByteArray();

        DateTime baseDate = new(1900, 1, 1);
        DateTime now = DateTime.UtcNow;

        TimeSpan timeSpan = now - baseDate;
        byte[] daysArray = BitConverter.GetBytes(timeSpan.Days);
        byte[] msecsArray = BitConverter.GetBytes((long)(timeSpan.TotalMilliseconds % 86400000));

        if (BitConverter.IsLittleEndian)
        {
            Array.Reverse(daysArray);
            Array.Reverse(msecsArray);
        }

        lock (_lock) // Ensure thread safety
        {
            Array.Copy(daysArray, daysArray.Length - 2, guidArray, guidArray.Length - 6, 2);
            Array.Copy(msecsArray, msecsArray.Length - 4, guidArray, guidArray.Length - 4, 4);
        }
        return new Guid(guidArray).ToString();
    }
}
