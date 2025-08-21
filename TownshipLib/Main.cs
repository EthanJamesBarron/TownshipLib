using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[assembly: MelonInfo(typeof(TownshipLib.Main), "TownshipLib", "0.0.1", "Ethan Barron")]

namespace TownshipLib
{
    public class Main : MelonMod
    {
        private bool headless;
        public static MelonLogger.Instance Logger;


        public override void OnInitializeMelon()
        {
            Logger = LoggerInstance;
        }

        public override void OnUpdate()
        {
            
        }

        public override void OnGUI()
        {
            headless = GUILayout.Toggle(headless, "Headless?");

            if (GUILayout.Button("Start Dedicated Server"))
            {
                ApplicationStartupManager.AttemptServerStartAsync(new string[]
                {
                    "/start_server", "-1", "true", "5999"
                });
            }
        }
    }
}
