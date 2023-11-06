namespace Apps.Wise.Utils;

public static class SensitiveHandler
{
    public static async Task<T> HandleSensitiveRequest<T>(Func<Task<T>> func)
    {
        try
        {
            return await func();
        }
        catch (Exception ex)
        {
            var message = ex.Message == "unauthorized"
                ? "Forbidden. Make sure you were granted an access to cards sensitive data"
                : ex.Message;

            throw new(message);
        }
    }
}