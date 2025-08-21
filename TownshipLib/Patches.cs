using HarmonyLib;
using NLog;
using NLog.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TownshipLib
{
    // Makes the game's usage of NLog visible in the MelonLoader console
    [HarmonyPatch(typeof(Logger))]
    public static class NLogPatches
    {
        [HarmonyPatch(nameof(Logger.WriteToTargets), new Type[] { typeof(LogEventInfo), typeof(TargetWithFilterChain) })]
        public static void Prefix(LogEventInfo logEvent, TargetWithFilterChain targetsForLevel)
        {
            LogAppropriately(logEvent);
        }

        [HarmonyPatch(nameof(Logger.WriteToTargets), new Type[] { typeof(Type), typeof(LogEventInfo), typeof(TargetWithFilterChain) })]
        public static void Prefix(Type wrapperType, LogEventInfo logEvent, TargetWithFilterChain targetsForLevel)
        {
            LogAppropriately(logEvent);
        }

        public static void LogAppropriately(LogEventInfo logEvent)
        {
            string msg = logEvent.CallerMemberName + " ";
            msg += logEvent.FormattedMessage + "Exception next: ";
            msg += logEvent.Exception;

            if (logEvent.Level == LogLevel.Info)
            {
                Main.Logger.Msg("NLOG INFO: " + msg);
            }

            else if (logEvent.Level == LogLevel.Error)
            {
                Main.Logger.Error("NLOG ERROR: " + msg);
            }

            else if (logEvent.Level == LogLevel.Warn)
            {
                Main.Logger.Warning("NLOG WARN: " + msg);
            }

            else if (logEvent.Level == LogLevel.Debug)
            {
                Main.Logger.Msg("NLOG DEBUG: " + msg);
            }

            else if (logEvent.Level == LogLevel.Fatal)
            {
                Main.Logger.Error("NLOG FATAL: " + msg);
            }

            else if (logEvent.Level == LogLevel.Trace)
            {
                Main.Logger.Warning("NLOG TRACE: " + msg);
            }
        }
    }
}
