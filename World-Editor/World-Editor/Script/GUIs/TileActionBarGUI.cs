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
        public GUI_Image lowerBar;

        public GUI_Button button;
        //public GUI_Button button_sand;


        public  void Initialize()
        {
            lowerBar = new GUI_Image()
            {
                Sprite = GameWorld.spriteContainer.sprites["CollisionTexture"],
                ShowGUI = true,
                Scale = new Vector2(GameWorld.ScreenSize.X, 150),
                Position = new Vector2(0, GameWorld.ScreenSize.Y),
                Origin = OriginPosition.BottomMid,
                LayerDepth = 0.01f,
                color = Color.LightSlateGray
            };
            GameWorld.Instatiate(lowerBar);

            button = new GUI_Button()
            {
                Sprite = GameWorld.spriteContainer.tileSprite["grass1"],
                ShowGUI = true,
                ButtonScale = new Vector2(0.25f, 0.25f),
                Position = new Vector2(lowerBar.Transform.Position.X + 25, lowerBar.Transform.Position.Y - 125),
                LayerDepth = 0.02f

            };
            button.Click += MakeGrass1;
            GameWorld.Instatiate(button);

            button = new GUI_Button()
            {
                Sprite = GameWorld.spriteContainer.tileSprite["grass3"],
                ShowGUI = true,
                ButtonScale = new Vector2(0.25f, 0.25f),
                Position = new Vector2(lowerBar.Transform.Position.X + 150, lowerBar.Transform.Position.Y - 125),
                LayerDepth = 0.02f

            };
            button.Click += MakeGrass3;
            GameWorld.Instatiate(button);

            button = new GUI_Button()
            {
                Sprite = GameWorld.spriteContainer.tileSprite["sand"],
                ShowGUI = true,
                ButtonScale = new Vector2(0.25f, 0.25f),
                Position = new Vector2(lowerBar.Transform.Position.X + 275, lowerBar.Transform.Position.Y - 125),
                LayerDepth = 0.02f

            };
            button.Click += MakeSand;
            GameWorld.Instatiate(button);

            button = new GUI_Button()
            {
                Sprite = GameWorld.spriteContainer.tileSprite["water1"],
                ShowGUI = true,
                ButtonScale = new Vector2(0.25f, 0.25f),
                Position = new Vector2(lowerBar.Transform.Position.X + 400, lowerBar.Transform.Position.Y - 125),
                LayerDepth = 0.02f

            };
            button.Click += MakeWater1;
            GameWorld.Instatiate(button);

            button = new GUI_Button()
            {
                Sprite = GameWorld.spriteContainer.tileSprite["water2"],
                ShowGUI = true,
                ButtonScale = new Vector2(0.25f, 0.25f),
                Position = new Vector2(lowerBar.Transform.Position.X + 525, lowerBar.Transform.Position.Y - 125),
                LayerDepth = 0.02f

            };
            button.Click += MakeWater2;
            GameWorld.Instatiate(button);
        }

        public void MakeGrass1(object sender, System.EventArgs e)
        {
            GameWorld.editor.tileController.CurrentSprite = GameWorld.spriteContainer.tileSprite["grass1"];
        }
        public void MakeGrass3(object sender, System.EventArgs e)
        {
            GameWorld.editor.tileController.CurrentSprite = GameWorld.spriteContainer.tileSprite["grass3"];
        }
        public void MakeSand(object sender, System.EventArgs e)
        {
            GameWorld.editor.tileController.CurrentSprite = GameWorld.spriteContainer.tileSprite["sand"];
        }
        public void MakeWater1(object sender, System.EventArgs e)
        {
            GameWorld.editor.tileController.CurrentSprite = GameWorld.spriteContainer.tileSprite["water1"];
        }
        public void MakeWater2(object sender, System.EventArgs e)
        {
            GameWorld.editor.tileController.CurrentSprite = GameWorld.spriteContainer.tileSprite["water2"];
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
