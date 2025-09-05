using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TownshipLib.Patches
{
    [HarmonyPatch]
    public static class ConsoleExposer
    {
        [HarmonyPatch(typeof(ServerConsoleManager), nameof(ServerConsoleManager.CheckPermissions)), HarmonyPrefix]
        public static bool APIEndpointRedirect(ServerConsoleManager __instance)
        {
            if (CommandLineArguments.Contains("/console"))
            {
                __instance.StartUp();
            }
            KeyboardEventTriggers.KeyPressedDown += __instance.CheckForConsoleStart;
            __instance.StartRemoteConsole();

            return false;
        }
    }
}
