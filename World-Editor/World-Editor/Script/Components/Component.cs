using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace World_Editor
{
    public abstract class Component
    {
        #region Fields
        private Transform transform = new Transform();
        //private Texture2D sprite;
        //private float layerDepth;
        #endregion


        #region Properties
        public Transform Transform { get { return transform; } set { transform = value; } }
        //public Texture2D Sprite { get { return sprite; } set { sprite = value; } }
        //public OriginPosition Origin { get; set; }
        //public float LayerDepth { get { return layerDepth; } set { layerDepth = value; } }
        //public Color Color { get; set; }
        #endregion


        public abstract void Initialize();
        public abstract void LoadContent(ContentManager content);
        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);
        public abstract void Update(GameTime gameTime);
    }
}
