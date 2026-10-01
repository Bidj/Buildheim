using System.IO;
using BepInEx;
using BepInEx.Configuration;
using UnityEngine;

namespace PlanBuild.Client
{
    internal sealed class ClientConfig
    {
        public string DataDirectory { get; }
        public ConfigEntry<string> Directory { get; }
        public ConfigEntry<KeyCode> ToggleKey { get; }
        public ConfigEntry<KeyCode> AutoBuildKey { get; }
        public ConfigEntry<KeyCode> PlacementKey { get; }
        public ConfigEntry<KeyCode> HudKey { get; }
        public ConfigEntry<bool> ShowHud { get; }
        public ConfigEntry<bool> DelegateMaterialChecks { get; }

        public ClientConfig(ConfigFile config)
        {
            DataDirectory = ClientPaths.DataDirectory(Paths.ConfigPath);
            Directory = config.Bind("Client", "Blueprint directory",
                Path.Combine(DataDirectory, "blueprints"),
                "Local directory for .blueprint and .vbuild files. Nothing is uploaded to the server.");
            ToggleKey = config.Bind("Client", "Planner key", KeyCode.End, "Open or close the blueprint planner.");
            AutoBuildKey = config.Bind("Client", "Autobuild key", KeyCode.Home, "Toggle autobuild for the current blueprint while the planner is closed.");
            PlacementKey = config.Bind("Client", "Placement key", KeyCode.F7, "Enable or disable the current placement without clearing it. Disabling hides the hologram and stops build assistance.");
            HudKey = config.Bind("Client", "HUD key", KeyCode.F8, "Show or hide Buildheim's HUD while the planner is closed. Does not change placement or build mode.");
            ShowHud = config.Bind("Client", "Show HUD", true, "Show Buildheim's build status and shortcut hints. Hiding the HUD does not stop autobuild or hide the hologram.");
            DelegateMaterialChecks = config.Bind("Compatibility", "Delegate material checks to another mod", false,
                "Opt-in compatibility mode. Skips Buildheim's own inventory-only material checks for click-to-build " +
                "and autobuild, so Valheim's normal hammer placement can run and let another mod (for example a " +
                "chest-resource mod such as Valheim+) decide whether materials are available and consume them. " +
                "This only works if that other mod integrates with normal hammer placement; Buildheim never " +
                "withdraws from chests itself. Leave this off unless you use such a mod.");
        }
    }
}
