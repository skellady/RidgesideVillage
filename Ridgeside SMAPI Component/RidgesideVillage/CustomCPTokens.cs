using StardewModdingAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RidgesideVillage
    {
    class CustomCPTokens
        {
        private IModHelper Helper;
        private IManifest ModManifest;
        private IContentPatcherApi cp;
        private ModConfig Config {
            get => ModEntry.Config;
            set => ModEntry.Config = value;
            }

        public CustomCPTokens(IMod mod) {
            Helper = mod.Helper;
            ModManifest = mod.ModManifest;
            cp = Helper.ModRegistry.GetApi<IContentPatcherApi>("Pathoschild.ContentPatcher");
            }
        public void RegisterTokens() {
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
        }
    }
