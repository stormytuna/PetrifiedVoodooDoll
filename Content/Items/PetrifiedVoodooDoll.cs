using Microsoft.Xna.Framework.Graphics;
using PetrifiedVoodooDoll.Common.Configs;
using Terraria;
using Terraria.GameContent;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace PetrifiedVoodooDoll.Content.Items;
public class PetrifiedVoodooDoll : ModItem
{
    public override void SetStaticDefaults() {
        //Tooltip.SetDefault("'You are the worst person'");
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults() {
        Item.width = 16;
        Item.height = 28;
        Item.value = Item.sellPrice(silver: 2);
        Item.maxStack = 9999;
        Item.rare = ItemRarityID.Orange;
        Item.accessory = true;
    }

    public override void AddRecipes() {
        Recipe recipe = Recipe.Create(ItemID.GuideVoodooDoll);
        recipe.AddIngredient(ModContent.ItemType<PetrifiedVoodooDoll>());
        if (ServerConfig.Instance.guideDollUseAnvil) {
            recipe.AddTile(TileID.Anvils);
        }
        recipe.Register();

        recipe = Recipe.Create(ItemID.ClothierVoodooDoll);
        recipe.AddIngredient(ModContent.ItemType<PetrifiedVoodooDoll>());
        recipe.AddIngredient(ItemID.Silk, 5);
        recipe.AddTile(TileID.Anvils);
        recipe.Register();
    }

    public override bool? PrefixChance(int pre, UnifiedRandom rand) => pre == -1 ? false : base.PrefixChance(pre, rand);

    public override void UpdateAccessory(Player player, bool hideVisual) => player.GetModPlayer<PetrifiedVoodooDollPlayer>().petrifiedVoodooDoll = true;

    public override void Load() {
        TextureAssets.Npc[NPCID.VoodooDemon] = ModContent.Request<Texture2D>("PetrifiedVoodooDoll/Common/GlobalNPCs/VoodooDemon");
    }

    public override void Unload() {
        TextureAssets.Npc[NPCID.VoodooDemon] = ModContent.Request<Texture2D>($"Terraria/Images/NPC_{NPCID.VoodooDemon}");
    }
}

public class PetrifiedVoodooDollPlayer : ModPlayer
{
    public bool petrifiedVoodooDoll;

    public override void ResetEffects() => petrifiedVoodooDoll = false;

    public override bool? CanHitNPCWithItem(Item item, NPC target) => target.townNPC ? petrifiedVoodooDoll : base.CanHitNPCWithItem(item, target);

    public override bool? CanHitNPCWithProj(Projectile proj, NPC target) => target.townNPC ? petrifiedVoodooDoll : base.CanHitNPCWithProj(proj, target);
}