public static class StringExtensions
{
    public static bool IsValidEmail(this string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            return false;
        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }
    public static string ToTitleCase(this string str)
    {
        if (string.IsNullOrWhiteSpace(str))
            return str;
        var cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
        var textInfo = cultureInfo.TextInfo;
        return textInfo.ToTitleCase(str.ToLower());
    }
    public static string IsNullOrEmpty(this string str, string defaultValue)
    {
        return string.IsNullOrEmpty(str) ? defaultValue : str;
    }
}