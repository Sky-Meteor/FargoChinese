using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria.ModLoader;

namespace FargoChinese.BuildIgnore.ObsoleteSystems
{
    public class FargoMenu : ModMenu
    {
        public override bool IsLoadingEnabled(Mod mod)
        {
            return false;
        }

        public override Asset<Texture2D> Logo => ModContent.Request<Texture2D>("FargoChinese/ModSystems/Logo_(Fargo's_Mod)");

        public override Asset<Texture2D> MoonTexture => ModContent.Request<Texture2D>("FargoChinese/ModSystems/OncomingMutant");
    }
}