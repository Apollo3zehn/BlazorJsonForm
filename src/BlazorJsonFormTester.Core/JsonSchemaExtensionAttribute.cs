using NJsonSchema.Annotations;

namespace BlazorJsonFormTester;

[AttributeUsage(AttributeTargets.Property)]
internal class JsonSchemaExtensionAttribute(params string[] extensionData) : Attribute, IJsonSchemaExtensionDataAttribute
{
    public IReadOnlyDictionary<string, object> ExtensionData { get; } = extensionData
        .Select((value, index) => new { PairNum = index / 2, value })
        .GroupBy(pair => pair.PairNum)
        .Select(grp => grp.Select(g => g.value).ToArray())
        .ToDictionary(x => x[0], x => (object)x[1]);
}