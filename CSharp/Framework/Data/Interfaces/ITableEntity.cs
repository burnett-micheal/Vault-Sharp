namespace VaultSharp.Framework.Data.Interfaces
{
  public interface ITableEntity
  {
    int Id { get; }
    List<string> ToRow();
  }
}
