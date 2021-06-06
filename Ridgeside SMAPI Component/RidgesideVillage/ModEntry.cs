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

        private static ModConfig Config;

        public override void Entry(IModHelper helper)
        {
            ModMonitor = Monitor;
            Helper = helper;

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
            //GMCM code
            var gmcm = Helper.ModRegistry.GetApi<IGenericModConfigMenuApi>("spacechase0.GenericModConfigMenu");

            if (gmcm is null)
            {
                //return if GMCM is not installed
                return;
            }
            else
            {

                gmcm.RegisterModConfig(ModManifest, () => Config = new ModConfig(), () => Helper.WriteConfig(Config));

                //Misc Config Page
                gmcm.RegisterLabel(ModManifest, "Mod Appearance Configuration", "Pick your preferred graphics");
                gmcm.RegisterChoiceOption(ModManifest, "Pastoral Map Style", "Pick your preferred Pastoral fall season map-style", () => Config.pastoralMapStyle, (string val) => Config.pastoralMapStyle = val, ModConfig.pastoralMapStyleChoices);
                gmcm.RegisterLabel(ModManifest, "Cable Car Configuration", "Choose how the cable car cutscenes work");
                gmcm.RegisterSimpleOption(ModManifest, "Enable Cable Car Cutscene", "Enable cable car cutscene", () => Config.repeatCableCarCutscene, (bool val) => Config.repeatCableCarCutscene = val);
                gmcm.RegisterSimpleOption(ModManifest, "Enable Other NPCs in Cable Car", "Enable the chances of other NPCs to appear riding the Cable Car (Along with LASV, ES and SVE NPCs)", () => Config.enableOtherNPCsInCableCar, (bool val) => Config.enableOtherNPCsInCableCar = val);
                gmcm.RegisterLabel(ModManifest, "Mod Audio Configuration", "Choose how the mod's audio works");
                gmcm.RegisterSimpleOption(ModManifest, "Enable Ridgeside Village Music", "Enables music for Ridgeside Village", () => Config.enableRidgesideMusic, (bool val) => Config.enableRidgesideMusic = val);
                gmcm.RegisterPageLabel(ModManifest, "Go to: Portrait and Sprite Configuration", "", "Portrait and Sprite Configuration");

                //Portrait Config Page
                gmcm.StartNewPage(ModManifest, "Portrait and Sprite Configuration");
                gmcm.RegisterLabel(ModManifest, "Character Portrait Configuration", "Pick your preferred portraits");
                gmcm.RegisterChoiceOption(ModManifest, "Aguar Portrait Style", "Pick your preferred Aguar Portrait", () => Config.aguarPortraitStyle, (string val) => Config.aguarPortraitStyle = val, ModConfig.aguarPortraitStyleChoices);
                gmcm.RegisterChoiceOption(ModManifest, "Alissa Portrait Style", "Pick your preferred Alissa Portrait", () => Config.alissaPortraitStyle, (string val) => Config.alissaPortraitStyle = val, ModConfig.alissaPortraitStyleChoices);
                gmcm.RegisterChoiceOption(ModManifest, "Bert Portrait Style", "Pick your preferred Bert Portrait", () => Config.bertPortraitStyle, (string val) => Config.bertPortraitStyle = val, ModConfig.bertPortraitStyleChoices);
                gmcm.RegisterChoiceOption(ModManifest, "Corine Portrait Style", "Pick your preferred Corine Portrait", () => Config.corinePortraitStyle, (string val) => Config.corinePortraitStyle = val, ModConfig.corinePortraitStyleChoices);
                gmcm.RegisterChoiceOption(ModManifest, "Ezekiel Portrait Style", "Pick your preferred Ezekiel Portrait", () => Config.ezekielPortraitStyle, (string val) => Config.ezekielPortraitStyle = val, ModConfig.ezekielPortraitStyleChoices);
                gmcm.RegisterChoiceOption(ModManifest, "Flor Portrait Style", "Pick your preferred Flor Portrait", () => Config.florPortraitStyle, (string val) => Config.florPortraitStyle = val, ModConfig.florPortraitStyleChoices);
                gmcm.RegisterChoiceOption(ModManifest, "Freddie Portrait Style", "Pick your preferred Freddie Portrait", () => Config.freddiePortraitStyle, (string val) => Config.freddiePortraitStyle = val, ModConfig.freddiePortraitStyleChoices);
                gmcm.RegisterChoiceOption(ModManifest, "Ian Portrait Style", "Pick your preferred Ian Portrait", () => Config.ianPortraitStyle, (string val) => Config.ianPortraitStyle = val, ModConfig.ianPortraitStyleChoices);
                gmcm.RegisterChoiceOption(ModManifest, "Jeric Portrait Style", "Pick your preferred Jeric Portrait", () => Config.jericPortraitStyle, (string val) => Config.jericPortraitStyle = val, ModConfig.jericPortraitStyleChoices);
                gmcm.RegisterChoiceOption(ModManifest, "Jio Portrait Style", "Pick your preferred Jio Portrait", () => Config.jioPortraitStyle, (string val) => Config.jioPortraitStyle = val, ModConfig.jioPortraitStyleChoices);
                gmcm.RegisterChoiceOption(ModManifest, "Keahi Portrait Style", "Pick your preferred Keahi Portrait", () => Config.keahiPortraitStyle, (string val) => Config.keahiPortraitStyle = val, ModConfig.keahiPortraitStyleChoices);
                gmcm.RegisterChoiceOption(ModManifest, "Kiwi Portrait Style", "Pick your preferred Kiwi Portrait", () => Config.kiwiPortraitStyle, (string val) => Config.kiwiPortraitStyle = val, ModConfig.kiwiPortraitStyleChoices);
                gmcm.RegisterChoiceOption(ModManifest, "Lenny Portrait Style", "Pick your preferred Lenny Portrait", () => Config.lennyPortraitStyle, (string val) => Config.lennyPortraitStyle = val, ModConfig.lennyPortraitStyleChoices);
                gmcm.RegisterChoiceOption(ModManifest, "Lola Portrait Style", "Pick your preferred Lola Portrait", () => Config.lolaPortraitStyle, (string val) => Config.lolaPortraitStyle = val, ModConfig.lolaPortraitStyleChoices);
                gmcm.RegisterChoiceOption(ModManifest, "Maddie Portrait Style", "Pick your preferred Maddie Portrait", () => Config.maddiePortraitStyle, (string val) => Config.aguarPortraitStyle = val, ModConfig.maddiePortraitStyleChoices);
                gmcm.RegisterChoiceOption(ModManifest, "Olga Portrait Style", "Pick your preferred Olga Portrait", () => Config.olgaPortraitStyle, (string val) => Config.olgaPortraitStyle = val, ModConfig.olgaPortraitStyleChoices);
                gmcm.RegisterChoiceOption(ModManifest, "Phillip Portrait Style", "Pick your preferred Phillip Portrait", () => Config.phillipPortraitStyle, (string val) => Config.phillipPortraitStyle = val, ModConfig.phillipPortraitStyleChoices);
                gmcm.RegisterChoiceOption(ModManifest, "Pika Portrait Style", "Pick your preferred Pika Portrait", () => Config.pikaPortraitStyle, (string val) => Config.pikaPortraitStyle = val, ModConfig.pikaPortraitStyleChoices);
                gmcm.RegisterChoiceOption(ModManifest, "Richard Portrait Style", "Pick your preferred Richard Portrait", () => Config.richardPortraitStyle, (string val) => Config.richardPortraitStyle = val, ModConfig.richardPortraitStyleChoices);
                gmcm.RegisterChoiceOption(ModManifest, "Shiro Portrait Style", "Pick your preferred Shiro Portrait", () => Config.shiroPortraitStyle, (string val) => Config.shiroPortraitStyle = val, ModConfig.shiroPortraitStyleChoices);
                gmcm.RegisterChoiceOption(ModManifest, "Trinnie Portrait Style", "Pick your preferred Trinnie Portrait", () => Config.trinniePortraitStyle, (string val) => Config.trinniePortraitStyle = val, ModConfig.trinniePortraitStyleChoices);
                gmcm.RegisterChoiceOption(ModManifest, "Ysabelle Portrait Style", "Pick your preferred Ysabelle Portrait", () => Config.ysabellePortraitStyle, (string val) => Config.ysabellePortraitStyle = val, ModConfig.ysabellePortraitStyleChoices);
                gmcm.RegisterChoiceOption(ModManifest, "Yuuma Portrait Style", "Pick your preferred Yuuma Portrait", () => Config.yuumaPortraitStyle, (string val) => Config.yuumaPortraitStyle = val, ModConfig.yuumaPortraitStyleChoices);
                gmcm.RegisterChoiceOption(ModManifest, "Helen Portrait Style", "Pick your preferred Helen Portrait", () => Config.helenPortraitStyle, (string val) => Config.helenPortraitStyle = val, ModConfig.helenPortraitStyleChoices);
                gmcm.RegisterChoiceOption(ModManifest, "Undreya Portrait Style", "Pick your preferred Undreya Portrait", () => Config.undreyaPortraitStyle, (string val) => Config.undreyaPortraitStyle = val, ModConfig.undreyaPortraitStyleChoices);
                gmcm.RegisterLabel(ModManifest, "Character Sprite Configuration", "Pick your preferred sprites");
                gmcm.RegisterChoiceOption(ModManifest, "Flor Sprite Style", "Pick your preferred Flor Sprite", () => Config.florSpriteStyle, (string val) => Config.florSpriteStyle = val, ModConfig.florSpriteStyleChoices);
                gmcm.RegisterPageLabel(ModManifest, "Back to main page", "", "");

            }
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
