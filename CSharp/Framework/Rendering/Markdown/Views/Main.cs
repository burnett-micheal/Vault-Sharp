using VaultSharp.Framework.Data;
using VaultSharp.Framework.IO.DocumentEditors;

namespace VaultSharp.Framework.Rendering.Markdown.Views
{
  public class Main
  {
    private static MDDocEditor MainEditor = new MDDocEditor(AppConfig.MAIN_VIEW_PATH);

    public static void Render(string content)
    {
      MainEditor.SetContent(content);
      MainEditor.Save();
    }
  }
}
