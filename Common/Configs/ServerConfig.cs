using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace PetrifiedVoodooDoll.Common.Configs;

public class ServerConfig : ModConfig
{
    public static ServerConfig Instance;

    public override ConfigScope Mode => ConfigScope.ServerSide;

    [Label("[i:35] Guide Voodoo Doll recipe uses anvil")]
    [DefaultValue(true)]
    [ReloadRequired]
    public bool guideDollUseAnvil { get; set; }
}