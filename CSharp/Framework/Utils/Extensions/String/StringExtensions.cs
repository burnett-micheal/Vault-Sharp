using System;

namespace VaultSharp.Framework.Utils.Extensions.String
{
  public static class StringExtensions
  {
    public static bool StartsWith(this string str, string prefix, bool caseSensitive = true)
    {
      var comparison = caseSensitive
        ? StringComparison.Ordinal
        : StringComparison.OrdinalIgnoreCase;
      return str.StartsWith(prefix, comparison);
    }

    public static bool IsValidString(this string? str)
    {
      if (str == null || str == "")
        return false;
      return true;
    }

    public static int ToInt(this string str)
    {
      return int.Parse(str);
    }

    public static float ToFloat(this string str)
    {
      return float.Parse(str);
    }
  }
}
