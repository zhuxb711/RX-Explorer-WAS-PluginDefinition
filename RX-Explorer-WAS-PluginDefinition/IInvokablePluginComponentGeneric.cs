using System.Threading.Tasks;

namespace RX_Explorer_WAS.PluginDefinition
{
    public interface IInvokablePluginComponent<T> : IPluginComponent
    {
        public Task<T> InvokePluginFeatureAsync(IPluginFeatureInformation Feature, params object[] Parameters);
    }
}
