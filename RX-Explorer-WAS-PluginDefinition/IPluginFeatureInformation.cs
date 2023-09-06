using System;

namespace RX_Explorer_WAS.PluginDefinition
{
    /// <summary>
    /// Provide the description about every feature in the plugin.
    /// </summary>
    public interface IPluginFeatureInformation
    {
        /// <summary>
        /// Feature unique id.
        /// </summary>
        /// <remarks>
        /// Id should be unique in the same plugin dll.
        /// </remarks>
        public Guid UniqueId { get; }

        /// <summary>
        /// Indicate whether this feature should be enabled.
        /// </summary>
        /// <remarks>
        /// You could use this flag to disable the feature, user could not invoke this feature if this flag is set to false.
        /// It is very useful if you developed a feature but still not ready for user to use it.
        /// </remarks>
        public bool IsEnabled { get; }

        /// <summary>
        /// Indicate whether this feature should be executed with elevated privilege.
        /// </summary>
        /// <remarks>
        /// If this flag is set to true, Host will make sure that the plugin is executed in elevated privilege.<br/>
        /// However, any return value from <see cref="IInvokablePluginComponent{T}.InvokePluginFeatureAsync(IPluginFeatureInformation, object[])"/> will be ignore.<br/>
        /// Which means that host will invoke through <see cref="IInvokablePluginComponent.InvokePluginFeatureAsync(IPluginFeatureInformation, object[])"/> instead.<br/>
        /// So you should use this flag to process the task that requires elevated privilege and no need to exchange data with the host.<br/>
        /// </remarks>
        public bool IsElevationRequired { get; }

        /// <summary>
        /// Specific the scenario that you want to be invoked.
        /// </summary>
        /// <remarks>
        /// Host will invoke your plugin if those scenario happened.
        /// </remarks>
        public InvokeScenario InvokeScenario { get; }

        /// <summary>
        /// Get feature name for UI.
        /// </summary>
        /// <remarks>
        /// Do not return <see langword="null"/> or <see cref="string.Empty"/>.
        /// </remarks>
        /// <param name="Locale">Locale code for localization.</param>
        /// <returns>Localized name.</returns>
        public string GetLocaleName(string Locale);

        /// <summary>
        /// Get feature description for UI.
        /// </summary>
        /// <remarks>
        /// Do not return <see langword="null"/> or <see cref="string.Empty"/>.
        /// </remarks>
        /// <param name="Locale">Locale code for localization.</param>
        /// <returns>Localized description.</returns>
        public string GetLocaleDescription(string Locale);
    }
}
