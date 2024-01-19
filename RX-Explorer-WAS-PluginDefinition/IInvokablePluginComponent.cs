using RX_Explorer_WAS.PluginDefinition.Enum;
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
        /// <param name="Parameters">Invoke parameters.</param>
        /// <remarks>
        /// Host will invoke the plugin through this function, plugin developer should implement this function properly.<br/>
        /// Please make sure use <see langword="async"/> execution in this function even you do not actually need <see langword="async"/> so that it would not block the UI thread.<br/>
        /// For example: use <see cref="Task.Run(System.Action)"/> to warp the code you want to execute.<br/>
        /// </remarks>
        public Task InvokePluginFeatureAsync(IPluginFeatureInformation Feature, FeatureStatus Status, params object[] Parameters);
    }
}
