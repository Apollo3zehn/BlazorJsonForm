using System.Globalization;
using BlazorJsonForm;

namespace BlazorJsonFormTester.Core.Localization;

public class Localizer : IJsonFormLocalizer
{
    public string GetString(string key)
    {
        return Localization.ResourceManager.GetString(key, CultureInfo.CurrentCulture) ?? key;
    }
}