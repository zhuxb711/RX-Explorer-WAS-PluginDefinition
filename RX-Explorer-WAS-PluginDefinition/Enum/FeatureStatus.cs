namespace RX_Explorer_WAS.PluginDefinition.Enum
{
    /// <summary>
    /// Define the enum on feature status.
    /// </summary>
    public enum FeatureStatus
    {
        /// <summary>
        /// User active the feature
        /// </summary>
        /// <remarks>
        /// Indicate that user active the feature, plugin should execute the operation that active the feature
        /// </remarks>
        Active,

        /// <summary>
        /// User deactive the feature
        /// </summary>
        /// <remarks>
        /// Indicate that user deactive the feature, plugin should execute the operation that deactive the feature
        /// </remarks>
        Deactive
    }
}
