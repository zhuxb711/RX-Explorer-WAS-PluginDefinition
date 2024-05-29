using RX_Explorer_WAS.PluginDefinition.Enum;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RX_Explorer_WAS.PluginDefinition
{
    /// <summary>
    /// Provide the definition of invokable plugin with exchange data.
    /// </summary>
    /// <remarks>
    /// Plugin developer should implement this interface if need to exchange data with host.
    /// </remarks>
    /// <typeparam name="T"></typeparam>
    public interface IInvokablePluginComponent<T> : IInvokablePluginComponent
    {
        /// <summary>
        /// Invoke the plugin features through this function and return the data that need to exchange with host.
        /// </summary>
        /// <param name="Feature">Feature that would like to be invoked.</param>
        /// <param name="Status">Feature status</param>
        /// <param name="InputParameters">Invoke parameters.</param>
        /// <param name="CancelToken">Cancellation token</param>
        /// <remarks>
        /// Host will invoke the plugin and receive the result through this function, plugin developer should implement this function properly.<br/>
        /// Please make sure use <see langword="async"/> execution in this function even you do not actually need <see langword="async"/> so that it would not block the UI thread.<br/>
        /// For example: use <see cref="Task.Run(System.Action)"/> to warp the code you want to execute.
        /// </remarks>
        public new Task<T> InvokeFeatureAsync(IPluginFeatureInformation Feature, FeatureStatus Status, IEnumerable<object> InputParameters = null, CancellationToken CancelToken = default);
    }
}
