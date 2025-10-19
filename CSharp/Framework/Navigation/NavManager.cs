using VaultSharp.Framework.Data;
using VaultSharp.Framework.IO.DocumentEditors;

namespace VaultSharp.Framework.Navigation
{
  public static class NavManager
  {
    private static bool isNavigating = false;

    public static bool IsNavigating()
    {
      return isNavigating;
    }

    public static void ResetNavigationFlag()
    {
      isNavigating = false;
    }

    public static void ResetNavFile()
    {
      Save(new NavState(-1, new List<string>()));
    }

    public static NavState Load()
    {
      JsonDocEditor editor = new JsonDocEditor(AppConfig.NAV_PATH);
      NavState? nav = editor.Read<NavState>();
      if (nav == null)
      {
        nav = new NavState(-1, new List<string>());
        Save(nav);
      }
      return nav;
    }

    public static void Save(NavState nav)
    {
      var editor = new JsonDocEditor(AppConfig.NAV_PATH);
      editor.Write(nav);
    }

    public static void NavTo(string uri)
    {
      if (isNavigating)
      {
        isNavigating = false;
        return;
      }

      NavState nav = Load();

      // Truncate forward history if navigating from middle
      if (nav.Index < nav.History.Count - 1)
      {
        nav.History = nav.History.Take(nav.Index + 1).ToList();
      }

      nav.History.Add(uri);
      nav.Index++;

      Save(nav);
    }

    public static bool CanGoBack()
    {
      NavState nav = Load();
      return nav.Index > 0;
    }

    public static bool CanGoForward()
    {
      NavState nav = Load();
      return nav.Index < nav.History.Count - 1;
    }

    public static string? GoBack()
    {
      NavState nav = Load();
      if (nav.Index <= 0)
        return null;

      nav.Index--;
      Save(nav);

      isNavigating = true;
      return nav.History[nav.Index];
    }

    public static string? GoForward()
    {
      NavState nav = Load();
      if (nav.Index >= nav.History.Count - 1)
        return null;

      nav.Index++;
      Save(nav);

      isNavigating = true;
      return nav.History[nav.Index];
    }
  }
}
