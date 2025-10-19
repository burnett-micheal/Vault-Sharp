using System.Web;
using VaultSharp.Framework.Data;

namespace VaultSharp.Framework.Routing
{
  public static class UriBuilder
  {
    // Build a URI from command and optional parameters
    public static string Build(string command, Dictionary<string, string>? parameters = null)
    {
      string uri = $"{AppConfig.VAULT_BRIDGE_URI_SCHEME}://{command}";

      if (parameters != null && parameters.Count > 0)
      {
        uri += "?" + BuildQueryString(parameters);
      }

      return uri;
    }

    // Helper overload for single parameter
    public static string Build(string command, string paramKey, string paramValue)
    {
      return Build(command, new Dictionary<string, string> { { paramKey, paramValue } });
    }

    // Build query string from parameters
    private static string BuildQueryString(Dictionary<string, string> parameters)
    {
      var encodedParams = parameters.Select(kvp =>
        $"{HttpUtility.UrlEncode(kvp.Key)}={HttpUtility.UrlEncode(kvp.Value)}"
      );

      return string.Join("&", encodedParams);
    }
  }
}
