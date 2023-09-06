using System;

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
        /// Not implement yet.
        /// </remarks>
        Launch = 1,

        /// <summary>
        /// Invoke the feature on application shutdown.
        /// </summary>
        /// <remarks>
        /// Not implement yet.
        /// </remarks>
        Shutdown = 2,

        /// <summary>
        /// Invoke the feature on application needs to elevate itself.
        /// </summary>
        Elevation = 4
    }
}
