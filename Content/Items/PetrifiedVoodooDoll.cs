using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria;
using PetrifiedVoodooDoll.Content.Projectiles;
using Terraria.ID;

namespace PetrifiedVoodooDoll.Content.Items
{
    public class PetrifiedVoodooDoll : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("A voodoo doll protected by a stone shell to prevent any accidents...");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 28;
            Item.value = Item.sellPrice(silver: 2);
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.consumable = true;
            Item.shoot = ModContent.ProjectileType<PetrifiedVoodooDollProj>();
            Item.shootSpeed = 5f;
            Item.maxStack = 99;
            Item.rare = ItemRarityID.Orange;
        }
    }
}