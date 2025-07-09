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
        /// <param name="Feature">Feature that will be invoked.</param>
        /// <param name="Status">Indicate that user active the feature or not.</param>
        /// <param name="InputParameters">Parameters that would pass to the plugin during invoking. Optional.</param>
        /// <param name="CancelToken">Cancellation token. Optional.</param>
        /// <remarks>
        /// Host will invoke the plugin and receive the result through this function, plugin developer should implement this function properly.<br/>
        /// Please make sure use <see langword="async"/> execution in this function even you do not actually need <see langword="async"/> so that it would not block the UI thread.<br/>
        /// For example: use <see cref="Task.Run(System.Action)"/> to warp the code you want to execute.
        /// </remarks>
        public new Task<T> InvokeFeatureAsync(IPluginFeatureInformation Feature, FeatureStatus Status, IEnumerable<object> InputParameters = null, CancellationToken CancelToken = default);

        /// <summary>
        /// Default implementation for <see cref="IInvokablePluginComponent.InvokeFeatureAsync(IPluginFeatureInformation, FeatureStatus, IEnumerable{object}, CancellationToken)"/> method.
        /// </summary>
        /// <param name="Feature">Feature that will be invoked.</param>
        /// <param name="Status">Indicate that user active the feature or not.</param>
        /// <param name="InputParameters">Parameters that would pass to the plugin during invoking. Optional.</param>
        /// <param name="CancelToken">Cancellation token. Optional.</param>
        Task IInvokablePluginComponent.InvokeFeatureAsync(IPluginFeatureInformation Feature, FeatureStatus Status, IEnumerable<object> InputParameters, CancellationToken CancelToken)
        {
            return InvokeFeatureAsync(Feature, Status, InputParameters, CancelToken);
        }
    }
}
