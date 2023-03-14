namespace Glitter.Validation;

/// <summary>
/// Represents a guard for a value.
/// </summary>
/// <typeparam name="T">The type of the value to guard.</typeparam>
public class GuardedValue<T>
{
    public GuardedValue(T value, string? name = null)
    {
        Argument = value;
        ArgumentName = name;
    }
    public T Argument { get; set; }
    public string? ArgumentName { get; set; }
}