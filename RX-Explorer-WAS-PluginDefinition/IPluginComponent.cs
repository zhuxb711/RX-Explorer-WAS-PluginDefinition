using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RX_Explorer_WAS.PluginDefinition
{
    /// <summary>
    /// Provide the basic definition for the plugin component.
    /// </summary>
    public interface IPluginComponent : IAsyncDisposable, IDisposable
    {
        /// <summary>
        /// Plugin unique id.
        /// </summary>
        /// <remarks>
        /// Id should be unique globally in all the plugins.
        /// </remarks>
        public Guid UniqueId { get; }

        /// <summary>
        /// Gets the minimum version of the application required for compatibility.
        /// </summary>
        /// <remarks>
        /// Feel free to use <see langword="null"/> or <see cref="string.Empty"/> if no minimum version is required.<br/>
        /// However, if you specify a version, it should follow the format of <c>Major.Minor.Build.Revision</c>.<br/>
        /// Host application will check its version before using the plugin features. And ask user to upgrade the application if not compatible.
        /// </remarks>
        /// <example>
        /// 1.0.0.0
        /// </example>
        public string AppMinVersion { get; }

        /// <summary>
        /// Get plugin name for UI.
        /// </summary>
        /// <remarks>
        /// For better user understanding. Please do not return <see langword="null"/> or <see cref="string.Empty"/>.
        /// </remarks>
        /// <param name="Locale">Locale code for localization.</param>
        /// <returns>Localized name.</returns>
        public string GetLocaleName(string Locale);

        /// <summary>
        /// Get plugin description for UI.
        /// </summary>
        /// <remarks>
        /// For better user understanding. Please do not return <see langword="null"/> or <see cref="string.Empty"/>.
        /// </remarks>
        /// <param name="Locale">Locale code for localization.</param>
        /// <returns>Localized name.</returns>
        public string GetLocaleDescription(string Locale);

        /// <summary>
        /// List all the features that this plugin supports.
        /// </summary>
        /// <remarks>
        /// If no feature is available for the plugin, you should return a empty <see cref="IEnumerable{IPluginFeatureInformation}"/> rather than <see langword="null"/>.
        /// </remarks>
        public IEnumerable<IPluginFeatureInformation> SupportedFeatures { get; }
    }
}
