namespace PlanBuild.Client
{
    // Gating for Buildheim's own inventory-only material checks. These checks exist only to
    // preflight ordinary hammer placement; when another mod handles resource availability and
    // withdrawal through Valheim's normal placement path (for example a chest-resource mod),
    // Buildheim must stand down and let that mod's Player.TryPlacePiece hooks decide and consume
    // resources instead. See ClientConfig.DelegateMaterialChecks.
    internal static class ResourceAvailability
    {
        public static bool Permits(bool delegateToExternalProvider, bool hasInventoryResources) =>
            delegateToExternalProvider || hasInventoryResources;
    }
}
