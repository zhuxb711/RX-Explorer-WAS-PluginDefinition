using System;

namespace RX_Explorer_WAS.PluginDefinition
{
    public interface IPluginFeatureInformation
    {
        public Guid UniqueId { get; }

        public bool IsEnabled { get; }

        public string GetLocaleName(string Locale);

        public string GetLocaleDescription(string Locale);
    }
}
