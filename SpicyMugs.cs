namespace SpicyMugs
{
    using BepInEx;
    using BepInEx.Logging;
    using HarmonyLib;
    using UnityEngine;

    [BepInPlugin(modGUID, modName, modVersion)]
    public class Plugin : BaseUnityPlugin
    {
        public const string modGUID = "Oksamies.SpicyMugs";
        public const string modName = "SpicyMugs";
        public const string modVersion = "0.1.0";

        private readonly Harmony harmony = new Harmony(modGUID);

        public static ManualLogSource mls;

        void Awake()
        {
            mls = BepInEx.Logging.Logger.CreateLogSource(modGUID);
            mls.LogInfo($"{modGUID} is now awake!");

            harmony.PatchAll();
        }

        [HarmonyPatch(typeof(ValuableDirector), "Spawn")]
        public class ValuableDirectorPatch
        {
            static bool Prefix(ref GameObject _valuable, ValuableVolume _volume, ref string _path)
            {
                // mls.LogInfo(ValuableDirector.instance.tinyValuables);
                // mls.LogInfo(ValuableDirector.instance.tinyValuables.Count);
                // mls.LogInfo(ValuableDirector.instance.tinyValuables[0]); // Goblet
                // mls.LogInfo(ValuableDirector.instance.tinyValuables[1]); // Uranium mug
                // mls.LogInfo(ValuableDirector.instance.tinyValuables[2]); // Emerald Bracelet
                // mls.LogInfo(ValuableDirector.instance.tinyValuables[3]); // Ocarina
                // mls.LogInfo(ValuableDirector.instance.tinyValuables[4]); // Diamond
                // mls.LogInfo(ValuableDirector.instance.tinyValuables[5]); // Pocket Watch
                _valuable = ValuableDirector.instance.tinyValuables[1];
                _path = ValuableDirector.instance.tinyPath;

                return true;
            }
        }
    }
}
