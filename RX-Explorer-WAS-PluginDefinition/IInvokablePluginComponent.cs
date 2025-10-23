using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RX_Explorer_WAS.PluginDefinition
{
    /// <summary>
    /// Provide the definition of invokable plugin.
    /// </summary>
    /// <remarks>
    /// Plugin developer should implement this interface to get feature invoked when specific scenario happened.
    /// </remarks>
    public interface IInvokablePluginComponent : IPluginComponent
    {
        /// <summary>
        /// Invokes the specified feature asynchronously using the provided feature identifier and optional arguments.
        /// </summary>
        /// <remarks>
        /// Host will call this function when scenario matched and might provide different arguments depends on the scenario that feature belongs to.
        /// </remarks>
        /// <param name="FeatureGuid">The unique identifier of the feature to invoke.</param>
        /// <param name="Arguments">An optional collection of arguments to pass to the feature. If null, no arguments are provided.</param>
        /// <param name="CancelToken">A cancellation token that can be used to cancel the operation. The default value is <see cref="CancellationToken.None"/>.</param>
        /// <returns>A task that represents the asynchronous operation. The task completes when the feature invocation is finished.</returns>
        public Task<object> InvokeFeatureAsync(Guid FeatureGuid, IEnumerable<string> Arguments = null, CancellationToken CancelToken = default);
    }
}
