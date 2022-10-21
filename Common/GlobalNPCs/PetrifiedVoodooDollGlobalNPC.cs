using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria.GameContent.ItemDropRules;
using ReLogic.Content;

namespace PetrifiedVoodooDoll.Common.GlobalNPCs
{
    public class PetrifiedVoodooDollGlobalNPC : GlobalNPC
    {
        private Asset<Texture2D> voodooDemonTexture;

        public override bool InstancePerEntity => true;

        public override bool AppliesToEntity(NPC entity, bool lateInstantiation) => entity.type == NPCID.VoodooDemon;

        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            foreach (var rule in npcLoot.Get())
            {
                if (rule is CommonDrop drop && drop.itemId == ItemID.GuideVoodooDoll)
                {
                    drop.itemId = ModContent.ItemType<Content.Items.PetrifiedVoodooDoll>();
                }
            }
        }

        public override bool PreDraw(NPC npc, SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            if (voodooDemonTexture == null)
                voodooDemonTexture = ModContent.Request<Texture2D>("PetrifiedVoodooDoll/Common/GlobalNPCs/VoodooDemon");
            
            Vector2 drawPosition = npc.position - screenPos;
            int frameHeight = voodooDemonTexture.Value.Height / Main.npcFrameCount[npc.type];
            Rectangle sourceRect = new Rectangle(0, npc.frame.Y, voodooDemonTexture.Value.Width, frameHeight);
            Vector2 origin = sourceRect.Size() / 2;
            SpriteEffects effects = npc.direction == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;

            spriteBatch.Draw(voodooDemonTexture.Value, drawPosition, sourceRect, drawColor, npc.rotation, origin, npc.scale, effects, 0f);

            return false;
        }
    }
}