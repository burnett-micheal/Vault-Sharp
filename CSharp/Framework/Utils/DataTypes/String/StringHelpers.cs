namespace VaultSharp.Framework.Utils
{
  public static partial class DataTypeUtils
  {
    public static class String
    {
      public static string Query(Dictionary<string, string>? queryParams)
      {
        if (queryParams == null || queryParams.Count == 0)
          return "";
        string queryString = string.Join("&", queryParams.Select(kvp => $"{kvp.Key}={kvp.Value}"));
        return $"?{queryString}";
      }
    }
  }
}
