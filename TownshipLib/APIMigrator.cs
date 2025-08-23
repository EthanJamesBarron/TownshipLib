using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alta.Api.Client.Utility;
using HarmonyLib;

namespace TownshipLib
{
    [HarmonyPatch]
    public static class APIMigrator
    {
        [HarmonyPatch(typeof(ApiAccess), nameof(ApiAccess.StartApiAccess)), HarmonyPrefix]
        public static bool APIEndpointRedirect()
        {
            ApiAccess.StartWithEndpoint("http://147.185.221.31:17891/");
            return false;
        }

        [HarmonyPatch(typeof(LoginUtilities), nameof(LoginUtilities.HashString)), HarmonyPrefix]
        public static bool AntiPasswordHasher(string text, ref string __result)
        {
            // Work on this later, for now just disable hashing entirely
            Main.Logger.Warning("The provided text was not hashed and will be returned as-is, This may expose sensitive information");
            
            __result = text;
            return false;
        }
    }
}
