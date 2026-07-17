using System.Text.RegularExpressions;

public static class PasswordValidator
{
    public static bool IsValidPassword(string password)
    {
        string passwordPattern = @"^(?=.*\d).{8,}$";
        return Regex.IsMatch(password, passwordPattern);
    }
}