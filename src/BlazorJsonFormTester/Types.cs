/// <summary>
/// This is my test enum.
/// </summary>
public enum MyTestEnum
{
    /// <summary>
    /// This is option A.
    /// </summary>
    A = 1,

    /// <summary>
    /// This is option B.
    /// </summary>
    B = 2,

    /// <summary>
    /// This is option C.
    /// </summary>
    C = 3
}

/// <summary>
/// This is my nested test type.
/// </summary>
/// <param name="Integer">An integer.</param>
public record MyNestedTestType(
    int Integer
);

/// <summary>
/// This is my test type.
/// </summary>
/// <param name="Integer">A fixed-point number.</param>
/// <param name="Double">A floating-point number.</param>
/// <param name="Text">A text.</param>
/// <param name="Enum">An enumeration.</param>
/// <param name="Object">An object.</param>
/// <param name="Array">An array.</param>
public record MyTestType(
    int Integer,
    double Double,
    string Text,
    MyTestEnum Enum,
    MyNestedTestType Object,
    MyNestedTestType[] Array
);