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
    public abstract class GUI : GameObject
    {
        #region Fields
        private bool showGUI;
        #endregion


        #region Properties
        public bool ShowGUI { get { return showGUI; } set { showGUI = value; } }

        #endregion


        #region Methods
        public override void Initialize()
        {
            
        }

        public override void LoadContent(ContentManager content)
        {
            SetOrigin();
        }
        public override void Draw( SpriteBatch spriteBatch)
        {

        }

        public override void Update(GameTime gameTime)
        {

        }

        public virtual Rectangle GUImouseBlockCollision
        {
            get
            {
                // returns a new rectangle based on the position, scale, sprite width and height.
                return new Rectangle(
                    (int)Transform.Position.X - (int)(Transform.Origin.X * Transform.Scale.X),
                    (int)Transform.Position.Y - (int)(Transform.Origin.Y * Transform.Scale.Y),
                    (int)(sprite.Width * Transform.Scale.X),
                    (int)(sprite.Height * Transform.Scale.Y)
                    );
            }
        }


        #endregion
    }
}
