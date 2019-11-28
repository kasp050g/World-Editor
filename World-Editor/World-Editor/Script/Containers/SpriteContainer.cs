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
        public Dictionary<string, Texture2D> sprites = new Dictionary<string, Texture2D>();
        public SpriteFont normalFont;

        public void LoadContent(ContentManager content)
        {
            // Tile's
            AddSprite(content.Load<Texture2D>("Texture/Tiles/grass_tile_1"), "grass1");
            AddSprite(content.Load<Texture2D>("Texture/Tiles/grass_tile_3"), "grass3");
            AddSprite(content.Load<Texture2D>("Texture/Tiles/sand_tile"), "sand");
            AddSprite(content.Load<Texture2D>("Texture/Tiles/21"), "water1");
            AddSprite(content.Load<Texture2D>("Texture/Tiles/20"), "water2");

            // Description's 
            //  ---Tree's
            AddSprite(content.Load<Texture2D>("Texture/Description/tree/AppleTree"), "AppleTree");
            AddSprite(content.Load<Texture2D>("Texture/Description/tree/tree_1"), "tree_1");
            AddSprite(content.Load<Texture2D>("Texture/Description/tree/tree_2"), "tree_2");
            //  ---Stuff
            AddSprite(content.Load<Texture2D>("Texture/Description/chest_1"), "chest_1");

            // Enemy Spawn's
            AddSprite(content.Load<Texture2D>("Texture/Tiles/20"), "asdasdasd");



            // Game Stuff
            AddSprite(content.Load<Texture2D>("Texture/Collision/CollisionTexture"), "CollisionTexture");

            // font Text
            normalFont = content.Load<SpriteFont>("Font/NormalFont");
        }

        private void AddSprite(Texture2D texture2D, string name)
        {
            sprites.Add(name, texture2D);
        }
    }
}
