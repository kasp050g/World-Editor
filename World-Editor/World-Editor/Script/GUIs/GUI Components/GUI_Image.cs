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

        public Vector2 Position { get { return Transform.Position; } set { Transform.Position = value; } }
        public Vector2 Scale { get { return Transform.Scale; } set { Transform.Scale = value; } }

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

        #region Constructor
        public GUI_Image()
        {

        }
        #endregion


        #region Methods

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void LoadContent(ContentManager content)
        {
            base.LoadContent(content);
        }
        public override void Draw( SpriteBatch spriteBatch)
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
