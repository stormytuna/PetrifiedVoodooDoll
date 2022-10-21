using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader.Config;
using System.ComponentModel;

namespace PetrifiedVoodooDoll.Common.Configs
{
    public class ServerConfig : ModConfig
    {
        public static ServerConfig Instance;

        public override ConfigScope Mode => ConfigScope.ServerSide;

        [Label("Guide Voodoo Doll recipe uses anvil")]
        [DefaultValue(true)]
        [ReloadRequired]
        public bool guideDollUseAnvil { get; set; }
    }
}