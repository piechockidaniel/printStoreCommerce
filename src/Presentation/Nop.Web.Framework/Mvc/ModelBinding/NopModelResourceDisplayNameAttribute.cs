namespace Nop.Web.Framework.Mvc.ModelBinding;

/// <summary>
/// Represents model attribute that specifies the display name prefix of the locale resource
/// </summary>
[AttributeUsage(AttributeTargets.Class)]
public class NopModelResourceDisplayNameAttribute : Attribute
{
    public NopModelResourceDisplayNameAttribute(string localizationPrefix)
    {
        LocalizationPrefix = localizationPrefix;
    }

    public string LocalizationPrefix { get; set; }
}
