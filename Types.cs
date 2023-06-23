namespace BlzWasmTypeInitRepro;

public sealed class TwistedType
{
  public static /*readonly or not*/ IEnumerable<TwistedType> TheTroubleMaker = NestedStatic.ArrayOfTwistedType.Prepend(new());

  public static class NestedStatic
  {
    public static /*readonly or not*/ TwistedType[] ArrayOfTwistedType = { new() };
  }

  public string World { get; } = "World";
}