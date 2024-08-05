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