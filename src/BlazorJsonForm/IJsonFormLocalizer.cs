namespace BlazorJsonForm;
/// <summary>
/// Interface for localizing text keys in the JSON form.
/// </summary>
public interface IJsonFormLocalizer
{
    /// <summary>
    /// Retrieves the translation for a given key.
    /// </summary>
    /// <param name="key">The key for which to retrieve the translation.</param>
    /// <returns>The translated text or the key if no translation is found.</returns>
    public string GetString( string key );
}