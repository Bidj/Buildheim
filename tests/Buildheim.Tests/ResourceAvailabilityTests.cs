using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlanBuild.Client;

namespace PlanBuildTest
{
    [TestClass]
    public class ResourceAvailabilityTests
    {
        [TestMethod]
        public void DefaultBehaviorStillRequiresInventoryResources()
        {
            Assert.IsFalse(ResourceAvailability.Permits(delegateToExternalProvider: false, hasInventoryResources: false));
            Assert.IsTrue(ResourceAvailability.Permits(delegateToExternalProvider: false, hasInventoryResources: true));
        }

        [TestMethod]
        public void DelegatingToAnotherModBypassesTheInventoryOnlyCheckEvenWhenBagsAreEmpty()
        {
            // A chest-resource mod (for example Valheim+) may supply materials through
            // Valheim's normal placement path. Buildheim must not block on its own
            // inventory-only preflight in that case; Valheim's hooks decide and consume.
            Assert.IsTrue(ResourceAvailability.Permits(delegateToExternalProvider: true, hasInventoryResources: false));
        }

        [TestMethod]
        public void DelegatingDoesNotChangeThePermissiveCase()
        {
            Assert.IsTrue(ResourceAvailability.Permits(delegateToExternalProvider: true, hasInventoryResources: true));
        }
    }
}
