using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.Audio;
using Terraria.ID;

namespace PetrifiedVoodooDoll.Content.Projectiles
{
    public class PetrifiedVoodooDollProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Petrified Voodoo Doll");
        }

        public override void SetDefaults()
        {
            Projectile.width = 16;
            Projectile.height = 28;
            Projectile.friendly = true;
            Projectile.aiStyle = 1;
            Projectile.tileCollide = true;
            Projectile.extraUpdates = 1;
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            #region Effects
            SoundEngine.PlaySound(SoundID.Dig, Projectile.Center);
            for (int i = 0; i < 6; i++)
            {
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Stone);
            }
            for (int i = 0; i < 20; i++)
            {
                Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Stone, 0f, 0f, 0, default(Color), 0.7f);
                d.noGravity = true;
                Dust dust = d;
                dust.velocity *= 2.9f;
                d.velocity.Y *= 0.8f;
                d.fadeIn = 1.1f;
            }
            for (int i = 0; i < 7; i++)
            {
                Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Stone, 0f, 0f, 0, default(Color), 0.7f);
                d.noGravity = true;
                Dust dust = d;
                dust.velocity *= 2.9f;
                d.velocity.Y *= 0.8f;
                d.fadeIn = 1.1f;
                d.noLight = true;
            }
            #endregion

            int item = Item.NewItem(Projectile.GetSource_Loot(), Projectile.position, Projectile.Size, ItemID.GuideVoodooDoll);
            if (Main.netMode == NetmodeID.MultiplayerClient)
                NetMessage.SendData(MessageID.SyncItem, -1, -1, null, item, 1f);

            return true;
        }
    }
}