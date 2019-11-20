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
    public abstract class GUI : Component
    {
        #region Fields
        //private Transform transform = new Transform();
        //private Texture2D sprite;
        //private float layerDepth;
        #endregion


        #region Properties
        public bool ShowGUI { get; set; }
        //public Transform Transform { get { return transform; } set { transform = value; } }
        //public Texture2D Sprite { get { return sprite; } set { sprite = value; } }
        //public OriginPosition Origin { get; set; }
        //public float LayerDepth { get { return layerDepth; } set { layerDepth = value; } }
        //public bool ShowGUI { get; set; }
        //public Color Color { get; set; }
        #endregion


        #region Methods
        public override void Initialize()
        {
           
        }

        public override void LoadContent(ContentManager content)
        {
            
        }
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            //if (ShowGUI == true)
            //{
            //    spriteBatch.Draw(sprite, Transform.Position, null, Color, Transform.Rotation, Transform.Origin, Transform.Scale, SpriteEffects.None, layerDepth);
            //}
        }

        public override void Update(GameTime gameTime)
        {

        }



      
        #endregion
    }
}
