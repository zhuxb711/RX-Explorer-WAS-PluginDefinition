using System;
using System.Diagnostics;

namespace RX_Explorer_WAS.PluginDefinition
{
    /// <summary>
    /// Define the enum on invoke scenario.
    /// </summary>
    [Flags]
    public enum InvokeScenario
    {
        /// <summary>
        /// Do not invoke on any scenario.
        /// </summary>
        /// <remarks>
        /// Default value and plugin developer should not use this flag on any situation.<br/>
        /// Feature that use this value will never be invoked in any scenario.
        /// </remarks>
        None = 0,

        /// <summary>
        /// Invoke the feature on application launch.
        /// </summary>
        /// <remarks>
        /// Host will invoke those plugin through <see cref="IInvokablePluginComponent.InvokePluginFeatureAsync(IPluginFeatureInformation, object[])"/> and would ignore any return value.
        /// </remarks>
        Launch = 1,

        /// <summary>
        /// Invoke the feature on application shutdown.
        /// </summary>
        /// <remarks>
        /// Host will invoke those plugin through <see cref="IInvokablePluginComponent.InvokePluginFeatureAsync(IPluginFeatureInformation, object[])"/> and would ignore any return value.
        /// </remarks>
        Shutdown = 2,

        /// <summary>
        /// Invoke the feature on application needs to elevate itself.
        /// </summary>
        /// <remarks>
        /// Host will invoke those plugin through <see cref="IInvokablePluginComponent{T}.InvokePluginFeatureAsync(IPluginFeatureInformation, object[])"/>.<br/>
        /// Especially, the plugin developer should not set <see cref="IPluginFeatureInformation.IsElevationRequired"/> to <see langword="true"/>.<br/>
        /// Plugin developer should return <see cref="Process"/> from <see cref="IInvokablePluginComponent{T}.InvokePluginFeatureAsync(IPluginFeatureInformation, object[])"/>.
        /// </remarks>
        Elevation = 4
    }
}
