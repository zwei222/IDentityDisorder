namespace IDentityDisorder.Core;

public static class IdGenerator
{
    public static Guid GenerateGuid()
    {
        return Guid.NewGuid();
    }

    public static Ulid GenerateUlid(DateTimeOffset? timestamp = null)
    {
        if (timestamp.HasValue)
        {
            return Ulid.NewUlid(timestamp.Value);
        }

        return Ulid.NewUlid();
    }
}
