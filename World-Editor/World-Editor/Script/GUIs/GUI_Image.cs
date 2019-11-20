using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace World_Editor
{
    public class GUI_Image : GUI
    {
        #region Fields

        #endregion



        #region Properties
        public Texture2D Sprite { get { return sprite; } set { sprite = value; } }
        public float LayerDepth { get { return layerDepth; } set { layerDepth = value; } }
        public Vector2 Position { get { return Transform.Position; } set { Transform.Position = value; } }
        public Vector2 Scale { get { return Transform.Scale; } set { Transform.Scale = value; } }
        public Color color = Color.White;
        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle(
                    (int)Position.X,
                    (int)Position.Y,
                    sprite.Width,
                    sprite.Height);
            }
            set { }
        }

        #endregion

        #region Methods
        public GUI_Image()
        {
            
        }
        public GUI_Image(Texture2D sprite)
        {
            this.sprite = sprite;
        }
        public GUI_Image(Texture2D sprite, Color defaultColor)
        {
            this.sprite = sprite;
            this.defaultColor = defaultColor;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (ShowGUI == true)
            {
                spriteBatch.Draw(sprite, Transform.Position, null, color, 0f, Transform.Origin, Transform.Scale, SpriteEffects.None, layerDepth);
            }
        }

        public override void Update(GameTime gameTime)
        {

        }
        #endregion
    }
}
