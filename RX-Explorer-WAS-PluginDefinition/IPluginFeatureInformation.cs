using RX_Explorer_WAS.PluginDefinition.Enum;
using System;
using System.Collections.Generic;
using System.Threading;

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
        /// If this flag is set to true, host will call <see cref="IInvokablePluginComponent{T}.InvokeFeatureAsync(IPluginFeatureInformation, FeatureStatus, IEnumerable{object}, CancellationToken)"/> only have elevated privilege.<br/>
        /// Host will also display a message to the user to indicator that you needs elevation to work properly. If no elevated privilege is available, host will ignore the feature automatically. <br/>
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

        /// <summary>
        /// Get the reason about why this feature is being disabled. <br/> If the feature's <see cref="IPluginFeatureInformation.IsEnabled"/> is <see langword="false"/>, this message would help user know what is going wrong. 
        /// </summary>
        /// <remarks>
        /// Do not return <see langword="null"/> or <see cref="string.Empty"/> if <see cref="IPluginFeatureInformation.IsEnabled"/> is <see langword="false"/>.
        /// </remarks>
        /// <param name="Locale">Locale code for localization.</param>
        /// <returns>Localized description.</returns>
        public string GetLocaleUnavailableReason(string Locale);
    }
}
