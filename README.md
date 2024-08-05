# BlazorJsonForm

Build Blazor forms from JSON Schema using MudBlazor.

# How to: Helper text

```cs
using NJsonSchema.Annotations;

namespace BlazorJsonFormTester;

[AttributeUsage(AttributeTargets.Property)]
class HelperTextAttribute : Attribute, IJsonSchemaExtensionDataAttribute
{
    public HelperTextAttribute(string text)
    {
        ExtensionData = new Dictionary<string, object>()
        {
            ["x-helperText"] = text
        };
    }

    public IReadOnlyDictionary<string, object> ExtensionData  { get; }
}

internal record MyConfigurationType(
    [property: HelperText("Example: /path/to/mission/data")],
    string MissionDataPath,
);
```

# How to: Enum display names

```cs
using NJsonSchema.Annotations;

namespace BlazorJsonFormTester;

[AttributeUsage(AttributeTargets.Enum)]
internal class EnumDisplayNameAttribute : Attribute, IJsonSchemaExtensionDataAttribute
{
    public EnumDisplayNameAttribute(params string[] displayNames)
    {
        ExtensionData = new Dictionary<string, object>()
        {
            ["x-enumDisplayNames"] = displayNames
        };
    }

    public IReadOnlyDictionary<string, object> ExtensionData  { get; }
}

[EnumDisplayName(
    "The Mercury",
    "The Venus",
    "The Mars",
    "The Jupiter",
    "The Saturn",
    "The Uranus",
    "The Neptune"
)]
internal enum MissionTarget
{
    Mercury,
    Venus,
    Mars,
    Jupiter,
    Saturn,
    Uranus,
    Neptune
}
```