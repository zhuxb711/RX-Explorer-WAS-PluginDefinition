using RX_Explorer_WAS.PluginDefinition.Enum;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace RX_Explorer_WAS.PluginDefinition
{
    /// <summary>
    /// Provide the definition of status motivation plugin.
    /// </summary>
    /// <remarks>
    /// Plugin developer should implement this interface to get feature invoked when user change the status of specific feature.
    /// </remarks>
    public interface IStatusMotivationPluginComponent : IPluginComponent
    {
        /// <summary>
        /// Updates the feature status and triggers any necessary actions based on the new status.
        /// </summary>
        /// <remarks>
        /// Host will call this function when feature state transitions and give plugin chance to trigger additional processes depending on the new status.
        /// </remarks>
        /// <param name="FeatureGuid">The unique identifier of the feature whose status is being updated.</param>
        /// <param name="NewStatus">The new status to assign to the feature.</param>
        /// <param name="CancelToken">An optional token to cancel the operation. Defaults to <see cref="CancellationToken.None"/>.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public Task StatusMotivationAsync(Guid FeatureGuid, FeatureStatus NewStatus, CancellationToken CancelToken = default);
    }
}
