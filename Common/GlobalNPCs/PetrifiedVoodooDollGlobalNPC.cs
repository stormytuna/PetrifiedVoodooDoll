using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace PetrifiedVoodooDoll.Common.GlobalNPCs;

public class PetrifiedVoodooDollGlobalNPC : GlobalNPC
{ 
    public override bool AppliesToEntity(NPC entity, bool lateInstantiation) => entity.type == NPCID.VoodooDemon;

    public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot) {
        foreach (IItemDropRule rule in npcLoot.Get()) {
            if (rule is CommonDrop drop && drop.itemId == ItemID.GuideVoodooDoll) {
                drop.itemId = ModContent.ItemType<Content.Items.PetrifiedVoodooDoll>();
            }
        }
    }
}