namespace GenFu.Utilities;

public static class StringExtensions
{
    public static string UppercaseFirst(this string s) =>
        string.IsNullOrEmpty(s) ? string.Empty :
        char.ToUpper(s[0]) + s.Substring(1);
}
