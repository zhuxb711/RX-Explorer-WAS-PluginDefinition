using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace RX_Explorer_WAS.PluginDefinition.Enum
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
        /// Indicator should not invoke automatically in any scenario.
        /// </remarks>
        None = 0,

        /// <summary>
        /// Invoke the feature on application launch. This scenario will only be invoked when <see cref="FeatureStatus"/> is <see cref="FeatureStatus.Active"/>
        /// </summary>
        /// <remarks>
        /// Host will invoke those plugin through <see cref="IInvokablePluginComponent.InvokeFeatureAsync(IPluginFeatureInformation, FeatureStatus, IEnumerable{object}, CancellationToken)"/> and would ignore any return value.
        /// </remarks>
        Launch = 1,

        /// <summary>
        /// Invoke the feature on application shutdown. This scenario will only be invoked when <see cref="FeatureStatus"/> is <see cref="FeatureStatus.Active"/>
        /// </summary>
        /// <remarks>
        /// Host will invoke those plugin through <see cref="IInvokablePluginComponent.InvokeFeatureAsync(IPluginFeatureInformation, FeatureStatus, IEnumerable{object}, CancellationToken)"/> and would ignore any return value.
        /// </remarks>
        Shutdown = 2,

        /// <summary>
        /// Invoke the feature on application needs to elevate itself. This scenario will only be invoked when <see cref="FeatureStatus"/> is <see cref="FeatureStatus.Active"/>
        /// </summary>
        /// <remarks>
        /// Host will invoke those plugin through <see cref="IInvokablePluginComponent{T}.InvokeFeatureAsync(IPluginFeatureInformation, FeatureStatus, IEnumerable{object}, CancellationToken)"/>.<br/>
        /// Especially, the plugin developer should not set <see cref="IPluginFeatureInformation.IsElevationRequired"/> to <see langword="true"/>.<br/>
        /// Plugin developer should return <see cref="Process"/> from <see cref="IInvokablePluginComponent{T}.InvokeFeatureAsync(IPluginFeatureInformation, FeatureStatus, IEnumerable{object}, CancellationToken)"/>.<br/><br/>
        /// Warning: Only the first plugin's feature with <see cref="InvokeScenario.Elevation"/> that return <see cref="Process"/> successfully will be used by host. Which means if multiple plugins provide the feature about <see cref="InvokeScenario.Elevation"/>, will use the first success one.
        /// </remarks>
        Elevation = 4,

        /// <summary>
        /// Invoke the feature on feature status changed. This scenario will be invoked when <see cref="FeatureStatus"/> switching between <see cref="FeatureStatus.Active"/> and <see cref="FeatureStatus.Deactive"/>
        /// </summary>
        /// <remarks>
        /// Host will invoke those plugin through <see cref="IInvokablePluginComponent.InvokeFeatureAsync(IPluginFeatureInformation, FeatureStatus, IEnumerable{object}, CancellationToken)"/> and would ignore any return value.
        /// </remarks>
        FeatureStatusChanged = 8
    }
}
