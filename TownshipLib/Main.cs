using MelonLoader;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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

        public override void OnGUI()
        {
            headless = GUILayout.Toggle(headless, "Headless?");

            GUILayout.Label(Directory.GetCurrentDirectory());

            if (GUILayout.Button("Start Dedicated Server"))
            {
                Process.Start(Path.Combine(Directory.GetCurrentDirectory(), "A Township Tale"), $"/start_server 1 {headless} 5999");
            }
        }
    }
}
