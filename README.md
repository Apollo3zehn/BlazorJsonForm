# BlazorJsonForm

Build Blazor forms from JSON Schema using MudBlazor.

How to support the helper text:

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
            ["x-helper-text"] = text
        };
    }

    public IReadOnlyDictionary<string, object> ExtensionData  { get; }
}

internal record MyConfigurationType(
    [property: HelperText("Example: /path/to/mission/data")],
    string MissionDataPath,
);
```