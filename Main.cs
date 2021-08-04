using HarmonyLib;
using Steamworks;
using System.Reflection;
using Verse;
using Verse.Steam;

namespace Rimworld_Steam
{
    [StaticConstructorOnStartup]
    public class Main
    {
        static public bool Initialized;
        static Main()
        {
            var instance = new Harmony("hiteke.steam");
            instance.PatchAll(Assembly.GetExecutingAssembly());
            Initialized = SteamAPI.Init();
        }
    }

    [HarmonyPatch(typeof(SteamManager))]
    [HarmonyPatch("Initialized", MethodType.Getter)]
    class PatchInitialized
    {
        [HarmonyPrefix]
        public static bool Prefix(ref bool __result)
        {
            __result = Main.Initialized;
            return false;
        }
    }
}
