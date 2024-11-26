# BlazorJsonForm

[![GitHub Actions page](https://img.shields.io/badge/GitHub_Pages-Live_example-3f9100)](https://apollo3zehn.github.io/BlazorJsonForm)
[![NuGet](https://img.shields.io/nuget/v/BlazorJsonForm.svg?label=Nuget)](https://www.nuget.org/packages/BlazorJsonForm)

## Introduction

Build Blazor forms from JSON Schema using MudBlazor. Inspiration comes from the [JSON Forms](https://jsonforms.io/examples) project.

The main use case for this library is a Single-Page Blazor application (Wasm) that needs to provide a proper UI for configuration data. The corresponding C# types can be defined in the backend (or in plugins loaded by the backend). Using the external library [NJsonSchema](https://github.com/RicoSuter/NJsonSchema) it is then easy to generate a JSON schema from these configuration types, send the resulting JSON to the frontend and finally use this library to render a nice UI. The backing store is a `JsonNode` that can be passed back to the backend as a JSON string when the user's configuration is about to be saved. The backend can easily deserialize the data into a strongly typed instance and validate it afterwards.

Additionally to the validation in the backend, the frontend can validate the input data as well. This can be achieved by using `MudForm` (MudBlazor) or `EditContext` (Microsoft).

[Here is a live example](https://apollo3zehn.github.io/BlazorJsonForm/) with a predefined configuration type. It has many properties to test all kinds of data. The `Nullable mode` button switches between a type without nullable properties and one with only nullable properties (to be able to test both variants).

The `Validate form` button validates the current state of the form in the frontend. And the `Validate object` button causes the JSON form data to be deseralized and validated using data annotations [validator](https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations.validator) class. This would normally be done in the backend.

[![GitHub Actions page](image.avif)](https://apollo3zehn.github.io/BlazorJsonForm)

## Getting started

### Requirements

- .NET 8+
- MudBlazor ([installation guide](https://mudblazor.com/getting-started/installation#online-playground))

Ensure these four components are present at the top level (e.g. in `MainLayout.razor`):

```razor
<MudThemeProvider />
<MudPopoverProvider />
<MudDialogProvider />
<MudSnackbarProvider />
```

- this library: `dotnet add package BlazorJsonForm --prerelease`

### Type definition

The following data types are supported:

- Integer: `byte`, `int`, `ulong`, `long`
- Floating point: `float`, `double`
- Enum, underlying type: `byte`, `sbyte`, `ushort`, `short`, `uint`, `int`, `ulong`, `long`
- `bool`
- `string`
- Object: `class` or `struct` (including `record`)
- Array: `T[]`, `List<T>`, `IList<T>`
- Dictionary: `Dictionary<string, T>`, `IDictionary<string, T>`

All listed types can also be nullable (e.g. `int?` or `string?`).

The simplest way to define you configuration type is to use C# records. Make sure to add proper XML documentation to each property.

```cs
/// <param name="EngineCount">Number of engines</param>
/// <param name="Fuel">Amount of fuel in L</param>
/// <param name="Message">Message from mankind</param>
/// <param name="LaunchCoordinates">Launch coordinates</param>
record RocketData(
    int EngineCount,
    double Fuel,
    string? Message,
    int[] LaunchCoordinates
);
```

> [!NOTE]
> See also [Types.cs](https://github.com/Apollo3zehn/BlazorJsonForm/blob/dev/src/BlazorJsonFormTester.Core/Types.cs) for a complete example.

### JSON Schema

The JSON schema can be easily created in the backend via:

```cs
var schema = JsonSchema.FromType<RocketData>();
```

### Blazor

```html
@if (_schema is not null)
{
    <JsonForm Schema="_schema" @bind-Data="_data" />
}

@code
{
    private JsonSchema _schema;
    private JsonNode? _data;

    protected override async Task OnInitializedAsync()
    {
        _schema = await GetJsonSchemaFromBackendAsync(...);
    }
}
```

### Frontend Validation

Wrap `JsonForm` in a `MudForm` as shown below and validate the form via `_form.Validate()`:

```html
<MudButton 
    OnClick="ValidateForm">
    Validate Form
</MudButton>

<MudForm @ref="_form">
    <JsonForm
        Schema="_schema"
        @bind-Data="_data" />
</MudForm>

@code
{
    // ...
    private MudForm _form = default!;

    private async Task ValidateForm()
    {
        await _form.Validate();

        if (_form.IsValid)
            ...

        else
            ...
    }
}
```

### Desialization & Backend Validation

As shown above, the actual configuration data is stored in the instance variable `_data` which is of type `JsonNode?`.

When the frontend validation succeeds, you can serialize the data via `var jsonString = JsonSerializer.Serialize(_data)` and send it to the backend.

The backend can then deserialize the JSON string into a strongly-typed object and validate it:

```cs
var config = JsonSerializer.Deserialize<RocketData>();
```

> [!NOTE]
> If you already use .NET 9 you should enable the `RespectNullableAnnotations` property of the `JsonSerializerOptions` which ensures that for instance a non-nullable string (`string`) is not being populated with a `null` value. Otherwise an exception is being thrown.

The deserialized object can be further validated by using the .NET built-in `Validator` class:

```cs
var validationResults = new List<ValidationResult>();

var isValid = Validator.TryValidateObject(
    config,
    new ValidationContext(config),
    validationResults,
    validateAllProperties: true
);
```

The validator validates all properties against certain conditions. These are being expressed using [data annotation attributes](https://learn.microsoft.com/de-de/dotnet/api/system.componentmodel.dataannotations?view=net-8.0). Currently, the following three data annotation attributes are supported and tested:

```cs
[Range(...)]
int Foo { get; set; }

[StringLength(...)]
string Bar { get; set; }

[RegularExpression(...)]
string FooBar { get; set; }
```

> [!NOTE]
> You should consider adding the `Required` attribute next to `RegularExpression` attribute because otherwise [empty strings are always valid](https://stackoverflow.com/a/32945086).

## Extras

You can define custom attrbutes which will change the generated JSON schema as described below.

### Helper text

Add a [helper text](https://mudblazor.com/components/textfield#form-props-helper-text) to inputs:

```cs
using NJsonSchema.Annotations;

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

### Enum display names

Specify custom enum member names to be displayed in the UI:

```cs
using NJsonSchema.Annotations;

[AttributeUsage(AttributeTargets.Enum)]
internal class EnumDisplayNamesAttribute : Attribute, IJsonSchemaExtensionDataAttribute
{
    public EnumDisplayNamesAttribute(params string[] displayNames)
    {
        ExtensionData = new Dictionary<string, object>()
        {
            ["x-enumDisplayNames"] = displayNames
        };
    }

    public IReadOnlyDictionary<string, object> ExtensionData  { get; }
}

[EnumDisplayNames(
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

# Known issues

- When using `[RegularExpression]` attribute on a string property, `null` values are not supported anymore. This is because the library `NJsonSchema` which is used to generate the schema is treating a `[RegularExpression]` annotated property as non-nullable and so the schema does not carry nullability information anymore.