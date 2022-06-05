using System.Net;

namespace HM.Core.Extensions;

public static class StringExtensions
{
    /// <summary>
    /// Returns true if string is null or empty.
    /// </summary>
    public static bool IsNullOrEmpty(this string s)
    {
        return string.IsNullOrEmpty(s);
    }

    /// <summary>
    /// Returns true if string is null, empty or only whitespaces.
    /// </summary>
    public static bool IsNullOrWhiteSpace(this string s)
    {
        return string.IsNullOrWhiteSpace(s);
    }

    /// <summary>
    /// Returns specified value if string is null/empty/whitespace else same string.
    /// </summary>
    public static string Or(this string s, string or)
    {
        if (!s.IsNullOrWhiteSpace())
        {
            return s;
        }
        return or;
    }

    /// <summary>
    /// Returns empty if string is null/empty/whitespace else same string.
    /// </summary>
    public static string OrEmpty(this string s)
    {
        return s.Or("");
    }

    /// <summary>
    /// Returns null if string is null/empty else same string.
    /// </summary>
    public static string NullIfEmpty(this string s)
    {
        return !s.IsNullOrEmpty() ? s : null;
    }

    /// <summary>
    /// Returns null if string is null/empty/whitespace else same string.
    /// </summary>
    public static string NullIfWhiteSpace(this string s)
    {
        return !s.IsNullOrWhiteSpace() ? s : null;
    }

    /// <summary>
    /// Returns html-encoded string.
    /// </summary>
    public static string HtmlEncode(this string s)
    {
        return WebUtility.HtmlEncode(s);
    }

    /// <summary>
    /// Returns html-decoded string.
    /// </summary>
    public static string HtmlDecode(this string s)
    {
        return WebUtility.HtmlDecode(s);
    }

    /// <summary>
    /// Returns url-encoded string.
    /// </summary>
    public static string UrlEncode(this string s)
    {
        return WebUtility.UrlEncode(s);
    }

    /// <summary>
    /// Returns url-decoded string.
    /// </summary>
    public static string UrlDecode(this string s)
    {
        return WebUtility.UrlDecode(s);
    }

    /// <summary>
    /// Try-parses string to bool, else default value.
    /// </summary>
    public static bool ToBool(this string value, bool defaultValue)
    {
        bool result;
        if (bool.TryParse(value, out result))
        {
            return result;
        }
        return defaultValue;
    }

    /// <summary>
    /// Parses a string in UTC format as DateTime.
    /// </summary>
    public static DateTime ParseAsUtc(this string s)
    {
        return DateTimeOffset.Parse(s).UtcDateTime;
    }

    /// <summary>
    /// Converts a string to title case.
    /// </summary>
    /// <example>"war and peace" -> "War And Peace"</example>
    public static string ToTitleCase(this string s)
    {
        return Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(s);
    }

    /// <summary>
    /// Returns substring from start of length <paramref name="n"/>.
    /// </summary>
    public static string SubstringFromStart(this string source, int n)
    {
        source.ThrowIfArgumentNull(nameof(source));
        n.ThrowIfArgumentOutOfRange(nameof(n));
        if (n >= source.Length)
        {
            return source;
        }
        return source.Substring(0, n);
    }

    /// <summary>
    /// Returns substring till end of length <paramref name="n"/>.
    /// </summary>
    public static string SubstringTillEnd(this string source, int n)
    {
        source.ThrowIfArgumentNull(nameof(source));
        n.ThrowIfArgumentOutOfRange(nameof(n));
        if (n >= source.Length)
        {
            return source;
        }
        return source.Substring(source.Length - n);
    }

    /// <summary>
    /// Returns substring by specifying start index and end index.
    /// </summary>
    public static string SubstringByIndex(this string source, int startIndex, int endIndex)
    {
        source.ThrowIfArgumentNull(nameof(source));
        startIndex.ThrowIfArgumentOutOfRange(nameof(startIndex));
        endIndex.ThrowIfArgumentOutOfRange(nameof(endIndex), maxRange: source.Length);
        return source.Substring(startIndex, endIndex - startIndex);
    }
}