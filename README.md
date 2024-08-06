# BlazorJsonForm

Build Blazor forms from JSON Schema using MudBlazor.

The main use case for this library is a Single-Page Blazor application which needs to provide a proper UI for configuration data. The corresponding C# types may be defined in the backend (or in plugins loaded by the backend). With the help of the library `NJsonSchema` it is then easy to generate a JSON schema from these configuration types, send the resulting JSON to the frontend and then use this library to render a nice UI. The backing storage is a `JsonNode` and when the configuration made by the user should be saved, it can be transferred back to the backend as a JSON string. In the backend you can deserialize and validate the data as shown below.

It is also possible to validate everything in the frontend and best practice would be to do both. You can do so by using `MudForm` (MudBlazor) or `EditContext` (Microsoft) which is shown below as well.

[Here](https://apollo3zehn.github.io/BlazorJsonForm/) is a live example with a predefined configuration type. This type has many different property to test all different types of data. The button `Nullable` mode makes the live example to use the same configuration type but now with all types being nullable. The effect is that now all properties are allowed to be null and so the validation is expected to succeed.

The button `Validate form` validates the current state of the form in the frontend. The button `Validate object` causes the JSON form data to be deseralized and validated using data annotations [validator](https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations.validator) class.

The following data annotation attributes are supported and tested:

```cs
[Range(...)]
[StringLength(...)]
[RegularExpression(...)]
```

You should consider addings the `Required` attribute next to `RegularExpression` attribute because otherwise [empty strings are always valid](https://stackoverflow.com/a/32945086).

![Example of BlazorJsonForm](image.avif)

You can define custom attrbutes which will change the generated JSON schema. Here are two example about how to add a [helper text](https://mudblazor.com/components/textfield#form-props-helper-text) to the inputs and about how to specify custom enum member names to be displayed in the UI:

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