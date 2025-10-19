using VaultSharp.Framework.Data.InternalModels;
using Nav = VaultSharp.Features.System.Commands.Navigation;

namespace VaultSharp.Framework.Rendering.Markdown
{
  public class Components
  {
    public static string NavBar()
    {
      string backLink = Nav.Back.Link("<- Nav Back");
      string forwardLink = Nav.Forward.Link("Nav Forward ->");

      return $"{backLink} ----- {forwardLink}";
    }

    public static string LineBreak(int numOfLineBreaks = 1)
    {
      string result = "";
      for (int i = 0; i < numOfLineBreaks; i++)
        result += "\n";
      return result;
    }

    public static string Link(string label, string url, bool disabled = false)
    {
      if (disabled)
        return $"~~{label}~~";

      return $"[{label}]({url})";
    }

    public static string Header(string text, int level = 1)
    {
      string hashes = new string('#', level);
      return $"{hashes} {text}";
    }

    public static string Table(List<string> headers, List<List<string>> rows)
    {
      string content = "";
      content += "| " + string.Join(" | ", headers) + " |\n";
      content += "|" + string.Join("|", headers.Select(_ => "---")) + "|\n";
      foreach (var row in rows)
      {
        content += "| " + string.Join(" | ", row) + " |\n";
      }
      return content;
    }

    // Format a single labeled field: **Label:** Value
    public static string Field(string label, string value)
    {
      return $"**{label}:** {value}";
    }

    // Format multiple labeled fields with line breaks
    public static string Fields(List<Field> fields)
    {
      string content = "";
      foreach (var field in fields)
      {
        content += Field(field.Label, field.Value);
        content += LineBreak();
      }
      return content;
    }

    // Optional: Table from Fields (if you want columns: Label | Value)
    public static string FieldsAsTable(List<Field> fields)
    {
      var headers = new List<string> { "Field", "Value" };
      var rows = fields.Select(f => new List<string> { f.Label, f.Value }).ToList();
      return Table(headers, rows);
    }

    public static string Join(List<string> parts, string? seperator = null)
    {
      if (seperator == null)
        seperator = LineBreak(2);
      return string.Join(seperator, parts);
    }
  }
}
