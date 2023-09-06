using System;
using System.Collections.Generic;

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
        /// Get plugin name for UI.
        /// </summary>
        /// <remarks>
        /// Do not return <see langword="null"/> or <see cref="string.Empty"/>.
        /// </remarks>
        /// <param name="Locale">Locale code for localization.</param>
        /// <returns>Localized name.</returns>
        public string GetLocaleName(string Locale);

        /// <summary>
        /// Get plugin description for UI.
        /// </summary>
        /// <remarks>
        /// Do not return <see langword="null"/> or <see cref="string.Empty"/>.
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
