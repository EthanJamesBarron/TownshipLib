using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alta.Api.Client.Utility;
using Alta.Api.DataTransferModels.Extensions;
using HarmonyLib;
using MelonLoader.Logging;

namespace TownshipLib.Patches
{
    [HarmonyPatch]
    public static class APIMigrator
    {
        [HarmonyPatch(typeof(ApiAccess), nameof(ApiAccess.StartApiAccess)), HarmonyPrefix]
        public static bool APIEndpointRedirect()
        {
            ApiAccess.StartWithEndpoint("https://hyphaviper.crypticbren.com/");
            return false;
        }
    }
}
