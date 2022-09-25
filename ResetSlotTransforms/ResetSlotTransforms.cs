using FrooxEngine;
using FrooxEngine.UIX;
using HarmonyLib;
using NeosModLoader;

namespace NeosModConfigurationExample
{
    public class NeosModConfigurationExample : NeosMod
    {
        public override string Name => "ComponentInspectorColor";
        public override string Author => "Zandario";
        public override string Version => "0.1.0";
        public override string Link => "https://github.com/Zandario/NeosModConfigurationExample";

        public override void OnEngineInit()
        {
            Harmony harmony = new Harmony("me.Zandario.ResetSlotTransform");
            harmony.PatchAll();
        }


        [HarmonyPatch(typeof(Slot), nameof(Slot.BuildInspectorUI))]
        class ResetSlotTransform
        {
            static void Postfix(Slot __instance, SyncRef<Sync<string>> ____componentText, SyncRef<Slot> ____componentsContentRoot, UIBuilder ui)
            {
                var newButton = ui.Button("TRS");
               // UIBuilder ui = new UIBuilder(____componentText.Target.Slot.Parent);
                // Fit with the size of other buttons
                ui.Style.FlexibleWidth = -1f;
                ui.Style.MinWidth = 64f;

            }
        }
    }
}
