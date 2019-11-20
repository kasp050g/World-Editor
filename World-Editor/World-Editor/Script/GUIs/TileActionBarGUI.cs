using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace World_Editor
{
    public class TileActionBarGUI 
    {
        public GUI_Button button_glass;
        public GUI_Button button_sand;


        public  void Initialize()
        {
            button_glass = new GUI_Button()
            {
                Sprite = GameWorld.spriteContainer.tileSprite["grass3"],
                ShowGUI = true,
                ButtonScale = new Vector2(0.25f, 0.25f),
                Position = new Vector2(200, 200)

             };
            GameWorld.Instatiate(button_glass);

            button_sand = new GUI_Button()
            {
                Sprite = GameWorld.spriteContainer.tileSprite["sand"],
                ShowGUI = true,
                ButtonScale = new Vector2(0.25f, 0.25f),
                Position = new Vector2(100, 100)

            };
            GameWorld.Instatiate(button_sand);
        }

        public  void LoadContent(ContentManager content)
        {
            
        }

        public  void Update(GameTime gameTime)
        {
           
        }

        public  void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            
        }
    }
}
