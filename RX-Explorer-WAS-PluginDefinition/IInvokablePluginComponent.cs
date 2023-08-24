using System.Threading.Tasks;

namespace RX_Explorer_WAS.PluginDefinition
{
    public interface IInvokablePluginComponent : IPluginComponent
    {
        public Task InvokePluginFeatureAsync(IPluginFeatureInformation Feature, params object[] Parameters);
    }
}
