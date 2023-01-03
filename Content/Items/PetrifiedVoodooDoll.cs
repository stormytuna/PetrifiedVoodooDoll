using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace PetrifiedVoodooDoll.Content.Items {
    public class PetrifiedVoodooDoll : ModItem {
        public override void SetStaticDefaults() {
            Tooltip.SetDefault("'You are the worst person'");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults() {
            Item.width = 16;
            Item.height = 28;
            Item.value = Item.sellPrice(silver: 2);
            Item.maxStack = 99;
            Item.rare = ItemRarityID.Orange;
            Item.accessory = true;
        }

        public override bool? PrefixChance(int pre, UnifiedRandom rand) {
            if (pre == -1) {
                return false;
            }

            return base.PrefixChance(pre, rand);
        }

        public override void UpdateAccessory(Player player, bool hideVisual) {
            player.GetModPlayer<PetrifiedVoodooDollPlayer>().petrifiedVoodooDoll = true;
        }
    }

    public class PetrifiedVoodooDollPlayer : ModPlayer {
        public bool petrifiedVoodooDoll;

        public override void ResetEffects() {
            petrifiedVoodooDoll = false;
        }

        public override bool? CanHitNPC(Item item, NPC target) {
            if (petrifiedVoodooDoll && target.townNPC)
                return true;

            return base.CanHitNPC(item, target);
        }

        public override bool? CanHitNPCWithProj(Projectile proj, NPC target) {
            if (petrifiedVoodooDoll && target.townNPC)
                return true;

            return base.CanHitNPCWithProj(proj, target);
        }
    }
}