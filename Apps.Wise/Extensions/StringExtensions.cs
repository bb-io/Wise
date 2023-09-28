using System.Security.Cryptography;
using System.Text;

namespace Apps.Wise.Extensions;

public static class StringExtensions
{
    public static string AsGuid(this string str)
    {
        using var md5 = MD5.Create();
        var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(str));

        return new Guid(hash).ToString();
    }
}