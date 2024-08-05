using NJsonSchema.Annotations;

namespace BlazorJsonFormTester;

[AttributeUsage(AttributeTargets.Property)]
internal class HelperTextAttribute : Attribute, IJsonSchemaExtensionDataAttribute
{
    public HelperTextAttribute(string text)
    {
        ExtensionData = new Dictionary<string, object>()
        {
            ["x-helperText"] = text
        };
    }

    public IReadOnlyDictionary<string, object> ExtensionData { get; }
}