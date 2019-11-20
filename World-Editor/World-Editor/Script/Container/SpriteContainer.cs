using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Content;

namespace World_Editor
{
    public class SpriteContainer
    {
        public Dictionary<string, Texture2D> tileSprite = new Dictionary<string, Texture2D>();


        public void LoadContent(ContentManager content)
        {
            AddTileSprite(content.Load<Texture2D>("Texture/Tiles/grass_tile_3"), "grass3");  
            AddTileSprite(content.Load<Texture2D>("Texture/Tiles/sand_tile"), "sand");  
        }

        private void AddTileSprite(Texture2D texture2D, string name)
        {
            tileSprite.Add(name, texture2D);
        }
    }
}
