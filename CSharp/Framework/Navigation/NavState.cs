namespace VaultSharp.Framework.Navigation
{
  public class NavState(int index, List<string> history)
  {
    public int Index { get; set; } = index;
    public List<string> History { get; set; } = history;
  }
}
