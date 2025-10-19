using System.Web;
using VaultSharp.Framework.Utils.Extensions.String;

namespace VaultSharp.Framework.Routing
{
  public static class UriParser
  {
    // Parse a full URI string into UriData
    public static UriData Parse(string uriString)
    {
      var uri = new Uri(uriString);

      string command = ParseCommand(uri);
      Dictionary<string, string> parameters = ParseQueryParams(uri);

      return new UriData(uriString, command, parameters);
    }

    // Extract command from URI host
    private static string ParseCommand(Uri uri)
    {
      // Combine host and path to get full hierarchical command
      string command = uri.Host;

      if (!string.IsNullOrEmpty(uri.AbsolutePath) && uri.AbsolutePath != "/")
      {
        command += uri.AbsolutePath; // AbsolutePath includes the leading "/"
      }

      return command.ToLower();
    }

    // Parse query parameters into dictionary
    private static Dictionary<string, string> ParseQueryParams(Uri uri)
    {
      Dictionary<string, string> result = new();
      string queryString = uri.Query;

      if (!queryString.IsValidString())
        return result;

      var queryParams = HttpUtility.ParseQueryString(queryString);

      foreach (string? key in queryParams.AllKeys)
      {
        if (string.IsNullOrEmpty(key))
          continue;

        result[key] = queryParams[key] ?? string.Empty;
      }

      return result;
    }
  }
}
