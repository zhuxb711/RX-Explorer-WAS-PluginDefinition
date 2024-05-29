using RX_Explorer_WAS.PluginDefinition.Enum;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RX_Explorer_WAS.PluginDefinition
{
    /// <summary>
    /// Provide the definition of invokable plugin.
    /// </summary>
    /// <remarks>
    /// Plugin developer should implement this interface if no need to exchange data with host.
    /// </remarks>
    public interface IInvokablePluginComponent : IPluginComponent
    {
        /// <summary>
        /// Invoke the plugin features through this function.
        /// </summary>
        /// <param name="Feature">Feature that would like to be invoked.</param>
        /// <param name="Status">Feature status</param>
        /// <param name="InputParameters">Invoke parameters.</param>
        /// <param name="CancelToken">Cancellation token</param>
        /// <remarks>
        /// Host will invoke the plugin through this function, plugin developer should implement this function properly.<br/>
        /// Please make sure use <see langword="async"/> execution in this function even you do not actually need <see langword="async"/> so that it would not block the UI thread.<br/>
        /// For example: use <see cref="Task.Run(System.Action)"/> to warp the code you want to execute.<br/>
        /// </remarks>
        public Task InvokeFeatureAsync(IPluginFeatureInformation Feature, FeatureStatus Status, IEnumerable<object> InputParameters = null, CancellationToken CancelToken = default);
    }
}
