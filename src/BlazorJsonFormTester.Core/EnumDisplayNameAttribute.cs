using NJsonSchema.Annotations;

namespace BlazorJsonFormTester;

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