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
    public class Description : GameObject
    {
        #region Fields
        #endregion


        #region Properties

        #endregion


        #region Constructor
        public Description()
        {

        }
        #endregion


        #region Methods
        public override void Initialize()
        {

        }

        public override void LoadContent(ContentManager content)
        {
            SetOrigin();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, Transform.Position + Transform.DrawOffSet, null, Color, Transform.Rotation, Transform.Origin, Transform.Scale, SpriteEffects.None, layerDepth);
        }

        public override void Update(GameTime gameTime)
        {

        }


        #endregion
    }
}
