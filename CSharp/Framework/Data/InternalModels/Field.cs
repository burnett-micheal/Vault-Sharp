namespace VaultSharp.Framework.Data.InternalModels
{
  public class Field
  {
    public string Label { get; set; }
    public string Value { get; set; }

    public Field(string label, string value)
    {
      Label = label;
      Value = value;
    }
  }
}
