using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using PetrifiedVoodooDoll.Common.Configs;

namespace PetrifiedVoodooDoll.Content
{
    public class PetrifiedVoodooDollRecipes : ModSystem
    {
        public override void AddRecipes()
        {
            Recipe recipe = Recipe.Create(ItemID.GuideVoodooDoll);
            recipe.AddIngredient(ModContent.ItemType<Items.PetrifiedVoodooDoll>());
            if (ServerConfig.Instance.guideDollUseAnvil)
                recipe.AddTile(TileID.Anvils);
            recipe.Register();

            recipe = Recipe.Create(ItemID.ClothierVoodooDoll);
            recipe.AddIngredient(ModContent.ItemType<Items.PetrifiedVoodooDoll>());
            recipe.AddIngredient(ItemID.Silk, 5);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}