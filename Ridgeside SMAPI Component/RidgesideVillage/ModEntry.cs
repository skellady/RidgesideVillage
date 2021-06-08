using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewValley;
using Harmony;

namespace RidgesideVillage
{
    public class ModEntry : Mod
    {
        internal static IMonitor ModMonitor { get; set; }
        internal new static IModHelper Helper { get; set; }
        internal static IJsonAssetsApi JsonAssetsAPI { get; set; }

        internal static ModConfig Config;

        private ConfigMenu ConfigMenu;

        public override void Entry(IModHelper helper)
        {
            ModMonitor = Monitor;
            Helper = helper;

            ConfigMenu = new ConfigMenu(this);

            helper.Events.GameLoop.GameLaunched += OnGameLaunched;
            helper.Events.GameLoop.SaveLoaded += OnSaveLoaded;
        }

        private void OnGameLaunched(object sender, EventArgs e)
        {
            if (!Helper.ModRegistry.IsLoaded("spacechase0.JsonAssets"))
            {
                return;
            }
            JsonAssetsAPI = Helper.ModRegistry.GetApi<IJsonAssetsApi>("spacechase0.JsonAssets");
            var harmony = HarmonyInstance.Create("Rafseazz.RidgesideVillage");
            harmony.Patch(
                original: AccessTools.Method(typeof(GameLocation), nameof(GameLocation.getFish)),
                postfix: new HarmonyMethod(typeof(ModEntry), nameof(ModEntry.GetFish_Postfix))
            );

            //Custom CP Token Set-up

            var cp = Helper.ModRegistry.GetApi<IContentPatcherApi>("Pathoschild.ContentPatcher");
            if (cp is null)
            {
                Monitor.Log("Content Patcher is not installed- RSV requires CP to run. Please install CP and restart your game.", LogLevel.Alert);
                return;
            }

            //Example complex token

            /*
            cp.RegisterToken(this.ModManifest, "InitialsTest", new RidgesideTokens.InitialsToken());
            */

            Config = Helper.ReadConfig<ModConfig>();

            //Register RSV tokens using CP

            {
                cp.RegisterToken(this.ModManifest, "PastoralMapStyle", () =>
                {
                    if (Config.pastoralMapStyle == null)
                        return new string[] { "Default" };

                    return new string[] { Config.pastoralMapStyle };
                });
                cp.RegisterToken(this.ModManifest, "EnableRidgesideMusic", () =>
                {
                    return new string[] { Config.enableRidgesideMusic.ToString() };
                });

                cp.RegisterToken(this.ModManifest, "RepeatCableCarCutscene", () =>
                {
                    return new string[] { Config.repeatCableCarCutscene.ToString() };
                });

                cp.RegisterToken(this.ModManifest, "EnableOtherNPCsInCableCar", () =>
                {
                    return new string[] { Config.enableOtherNPCsInCableCar.ToString() };
                });
                cp.RegisterToken(this.ModManifest, "AguarPortraitStyle", () =>
                {
                    if (Config.aguarPortraitStyle == null)
                        return new string[] { "Default" };

                    return new string[] { Config.aguarPortraitStyle };
                });
                cp.RegisterToken(this.ModManifest, "AlissaPortraitStyle", () =>
                {
                    if (Config.alissaPortraitStyle == null)
                        return new string[] { "Default" };

                    return new string[] { Config.alissaPortraitStyle };
                });
                cp.RegisterToken(this.ModManifest, "BertPortraitStyle", () =>
                {
                    if (Config.bertPortraitStyle == null)
                        return new string[] { "Default" };

                    return new string[] { Config.bertPortraitStyle };
                });
                cp.RegisterToken(this.ModManifest, "CorinePortraitStyle", () =>
                {
                    if (Config.corinePortraitStyle == null)
                        return new string[] { "Default" };

                    return new string[] { Config.corinePortraitStyle };
                });
                cp.RegisterToken(this.ModManifest, "EzekielPortraitStyle", () =>
                {
                    if (Config.ezekielPortraitStyle == null)
                        return new string[] { "Default" };

                    return new string[] { Config.ezekielPortraitStyle };
                });
                cp.RegisterToken(this.ModManifest, "FlorPortraitStyle", () =>
                {
                    if (Config.florPortraitStyle == null)
                        return new string[] { "Default" };

                    return new string[] { Config.florPortraitStyle };
                });
                cp.RegisterToken(this.ModManifest, "FreddiePortraitStyle", () =>
                {
                    if (Config.freddiePortraitStyle == null)
                        return new string[] { "Default" };

                    return new string[] { Config.freddiePortraitStyle };
                });
                cp.RegisterToken(this.ModManifest, "IanPortraitStyle", () =>
                {
                    if (Config.ianPortraitStyle == null)
                        return new string[] { "Default" };

                    return new string[] { Config.ianPortraitStyle };
                });
                cp.RegisterToken(this.ModManifest, "JericPortraitStyle", () =>
                {
                    if (Config.jericPortraitStyle == null)
                        return new string[] { "Default" };

                    return new string[] { Config.jericPortraitStyle };
                });
                cp.RegisterToken(this.ModManifest, "JioPortraitStyle", () =>
                {
                    if (Config.jioPortraitStyle == null)
                        return new string[] { "Default" };

                    return new string[] { Config.jioPortraitStyle };
                });
                cp.RegisterToken(this.ModManifest, "KeahiPortraitStyle", () =>
                {
                    if (Config.keahiPortraitStyle == null)
                        return new string[] { "Default" };

                    return new string[] { Config.keahiPortraitStyle };
                });
                cp.RegisterToken(this.ModManifest, "KennethPortraitStyle", () =>
                {
                    if (Config.kennethPortraitStyle == null)
                        return new string[] { "Default" };

                    return new string[] { Config.kennethPortraitStyle };
                });
                cp.RegisterToken(this.ModManifest, "KiwiPortraitStyle", () =>
                {
                    if (Config.kiwiPortraitStyle == null)
                        return new string[] { "Default" };

                    return new string[] { Config.kiwiPortraitStyle };
                });
                cp.RegisterToken(this.ModManifest, "LennyPortraitStyle", () =>
                {
                    if (Config.lennyPortraitStyle == null)
                        return new string[] { "Default" };

                    return new string[] { Config.lennyPortraitStyle };
                });
                cp.RegisterToken(this.ModManifest, "LolaPortraitStyle", () =>
                {
                    if (Config.lolaPortraitStyle == null)
                        return new string[] { "Default" };

                    return new string[] { Config.lolaPortraitStyle };
                });
                cp.RegisterToken(this.ModManifest, "MaddiePortraitStyle", () =>
                {
                    if (Config.maddiePortraitStyle == null)
                        return new string[] { "Default" };

                    return new string[] { Config.maddiePortraitStyle };
                });
                cp.RegisterToken(this.ModManifest, "OlgaPortraitStyle", () =>
                {
                    if (Config.olgaPortraitStyle == null)
                        return new string[] { "Default" };

                    return new string[] { Config.olgaPortraitStyle };
                });
                cp.RegisterToken(this.ModManifest, "PhillipPortraitStyle", () =>
                {
                    if (Config.phillipPortraitStyle == null)
                        return new string[] { "Default" };

                    return new string[] { Config.phillipPortraitStyle };
                });
                cp.RegisterToken(this.ModManifest, "PikaPortraitStyle", () =>
                {
                    if (Config.pikaPortraitStyle == null)
                        return new string[] { "Default" };

                    return new string[] { Config.pikaPortraitStyle };
                });
                cp.RegisterToken(this.ModManifest, "RichardPortraitStyle", () =>
                {
                    if (Config.richardPortraitStyle == null)
                        return new string[] { "Default" };

                    return new string[] { Config.richardPortraitStyle };
                });
                cp.RegisterToken(this.ModManifest, "ShiroPortraitStyle", () =>
                {
                    if (Config.shiroPortraitStyle == null)
                        return new string[] { "Default" };

                    return new string[] { Config.shiroPortraitStyle };
                });
                cp.RegisterToken(this.ModManifest, "TrinniePortraitStyle", () =>
                {
                    if (Config.trinniePortraitStyle == null)
                        return new string[] { "Default" };

                    return new string[] { Config.trinniePortraitStyle };
                });
                cp.RegisterToken(this.ModManifest, "YsabellePortraitStyle", () =>
                {
                    if (Config.ysabellePortraitStyle == null)
                        return new string[] { "Default" };

                    return new string[] { Config.ysabellePortraitStyle };
                });
                cp.RegisterToken(this.ModManifest, "YuumaPortraitStyle", () =>
                {
                    if (Config.yuumaPortraitStyle == null)
                        return new string[] { "Default" };

                    return new string[] { Config.yuumaPortraitStyle };
                });
                cp.RegisterToken(this.ModManifest, "HelenPortraitStyle", () =>
                {
                    if (Config.helenPortraitStyle == null)
                        return new string[] { "Default" };

                    return new string[] { Config.helenPortraitStyle };
                });
                cp.RegisterToken(this.ModManifest, "UndreyaPortraitStyle", () =>
                {
                    if (Config.undreyaPortraitStyle == null)
                        return new string[] { "Default" };

                    return new string[] { Config.undreyaPortraitStyle };
                });
                cp.RegisterToken(this.ModManifest, "FlorSpriteStyle", () =>
                {
                    if (Config.florSpriteStyle == null)
                        return new string[] { "Default" };

                    return new string[] { Config.florSpriteStyle };
                });
            }
            ConfigMenu.RegisterMenu();
        }

        private void OnSaveLoaded(object sender, EventArgs ex)
        {
            try
            {
                Config = Helper.ReadConfig<ModConfig>();
            }
            catch (Exception e)
            {
                Monitor.Log($"Failed to load config settings. Will use default settings instead. Error: {e}", LogLevel.Debug);
                Config = new ModConfig();
            }
        }

        [HarmonyPostfix]
        public static void GetFish_Postfix(GameLocation __instance, float millisecondsAfterNibble, int bait, int waterDepth, Farmer who, double baitPotency, Vector2 bobberTile, string locationName, ref StardewValley.Object __result)
        {
            try
            {
                if (!__instance.IsUsingMagicBait(who))
                {
                    return;
                }
                string nameToUse = (locationName == null) ? __instance.Name : locationName;
                ModMonitor.Log($"Player {who.Name} using magic bait at {nameToUse} with original fish result is {__result.Name}", LogLevel.Trace);
                float bobberAddition = 0f;
                if (who != null && who.CurrentTool is StardewValley.Tools.FishingRod && (who.CurrentTool as StardewValley.Tools.FishingRod).getBobberAttachmentIndex() == 856) // Curiosity Lure increases chance by 7%
                {
                    bobberAddition += 0.07f;
                }
                List<string> fish_names = new List<string>();
                switch (nameToUse)
                {
                    // Custom locations are added to the game without their prefixes
                    case "RidgesideVillage":
                        fish_names.Add("Bladetail Sturgeon");
                        fish_names.Add("Harvester Trout");
                        fish_names.Add("Lullaby Carp");
                        fish_names.Add("Pebble Back Crab");
                        break;
                    case "Ridge":
                        fish_names.Add("Caped Tree Frog");
                        fish_names.Add("Fixer Eel");
                        fish_names.Add("Golden Rose Fin");
                        break;
                    case "Beach":
                        // Although Beach has it's own location class, it calls the base class getFish function, so we're okay to just postfix that.
                        fish_names.Add("Cardia Septal Jellyfish");
                        fish_names.Add("Crimson Spiked Clam");
                        fish_names.Add("Fairytale Lionfish");
                        break;
                    default:
                        return;
                }
                foreach (string fish in fish_names)
                {
                    int fish_id = JsonAssetsAPI.GetObjectId(fish);
                    // Currently this gives each fish a 20% chance to be caught, could be lower if we add more configuration
                    if (fish_id != -1 && !who.fishCaught.ContainsKey(fish_id) && who.FishingLevel >= 3 && Game1.random.NextDouble() < 0.2 + (double)bobberAddition)
                    {
                        ModMonitor.Log($"Fish {fish} (ID: {fish_id}) is caught: {who.fishCaught.ContainsKey(fish_id)}, setting fish result to this fish", LogLevel.Trace);
                        __result = new StardewValley.Object(fish_id, 1);
                        return;
                    }
                    else
                    {
                        ModMonitor.Log($"Fish {fish} (ID: {fish_id}) is caught: {who.fishCaught.ContainsKey(fish_id)}", LogLevel.Trace);
                    }
                }
                return;
            }
            catch (Exception ex)
            {
                ModMonitor.Log($"Failed in {nameof(GetFish_Postfix)}:\n{ex}", LogLevel.Error);
            }
        }
    }
}
