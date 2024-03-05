using System.Reflection;
using Nop.Services.Localization;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Web.Framework.Localization;

/// <summary>
/// Extensions
/// </summary>
public static partial class LocalizationServiceExtension
{
    /// <summary>
    /// Gets a resource string and name based on the specified Type and name of property.
    /// </summary>
    /// <param name="localizationService">localization service</param>
    /// <param name="type">Object type</param>
    /// <param name="propertyName">Name of property</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains a string representing the resource string and its name.
    /// </returns>
    public static async Task<(string resourceName, string resourceValue)> GetResourceAsync(this ILocalizationService localizationService, Type type, string propertyName)
    {
        ArgumentNullException.ThrowIfNull(localizationService);

        if (type == null)
            return (null, null);

        var resourceName = type.GetProperty(propertyName)?.GetCustomAttributes(typeof(NopResourceDisplayNameAttribute), true)
            .OfType<NopResourceDisplayNameAttribute>()
            .FirstOrDefault()?.ResourceKey;

        if (string.IsNullOrEmpty(resourceName))
        {
            var localizedAttribute = type.GetCustomAttributes<NopModelResourceDisplayNameAttribute>().FirstOrDefault();

            if (localizedAttribute != null)
                resourceName = $"{localizedAttribute.LocalizationPrefix}{propertyName}";
        }

        string resourceValue = null;

        if (!string.IsNullOrEmpty(resourceName))
            //get locale resource value
            resourceValue = await localizationService.GetResourceAsync(resourceName);

        if (resourceValue?.Equals(resourceName, StringComparison.InvariantCultureIgnoreCase) ?? false)
            resourceValue = null;

        return (resourceName, resourceValue);
    }
}
