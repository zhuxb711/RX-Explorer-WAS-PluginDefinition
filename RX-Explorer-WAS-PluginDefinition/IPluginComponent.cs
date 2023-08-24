using System;
using System.Collections.Generic;

namespace RX_Explorer_WAS.PluginDefinition
{
    public interface IPluginComponent : IAsyncDisposable, IDisposable
    {
        public Guid UniqueId { get; }

        public string GetLocaleName(string Locale);

        public string GetLocaleDescription(string Locale);

        public IEnumerable<IPluginFeatureInformation> SupportedFeatures { get; }
    }
}
