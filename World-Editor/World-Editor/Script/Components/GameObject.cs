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
    public abstract class GameObject
    {
        #region Fields
        protected Transform transform = new Transform();
        protected Texture2D sprite;
        protected float layerDepth;
        protected Color color = Color.White;
        #endregion


        #region Properties
        public Transform Transform { get { return transform; } set { transform = value; } }
        public Texture2D Sprite { get { return sprite; } set { sprite = value; } }
        public OriginPositionEnum OriginEnum { get; set; }
        public float LayerDepth { get { return layerDepth; } set { layerDepth = value; } }
        public Color Color { get { return color; } set { color = value; } }
        #endregion


        public abstract void Initialize();
        public abstract void LoadContent(ContentManager content);
        public abstract void Draw(SpriteBatch spriteBatch);
        public abstract void Update(GameTime gameTime);

        public void SetOrigin()
        {
            // --- Top ---

            // top left
            if (OriginPositionEnum.TopLeft == OriginEnum)
            {
                Transform.Origin = new Vector2(0, 0);
            }
            // top mid
            if (OriginPositionEnum.TopMid == OriginEnum)
            {
                Transform.Origin = new Vector2(sprite.Width / 2, 0);
            }
            // top rigth
            if (OriginPositionEnum.TopRigth == OriginEnum)
            {
                Transform.Origin = new Vector2(sprite.Width, 0);
            }

            // --- Mid ---

            // mid left
            if (OriginPositionEnum.MidLeft == OriginEnum)
            {
                Transform.Origin = new Vector2(0, sprite.Height / 2);
            }
            // mid 
            if (OriginPositionEnum.Mid == OriginEnum)
            {
                Transform.Origin = new Vector2(sprite.Width / 2, sprite.Height / 2);
            }
            // mid rigth
            if (OriginPositionEnum.MidRigth == OriginEnum)
            {
                Transform.Origin = new Vector2(sprite.Width, sprite.Height / 2);
            }

            // --- Bottom ---

            // bottom left
            if (OriginPositionEnum.BottomLeft == OriginEnum)
            {
                Transform.Origin = new Vector2(0, sprite.Height);
            }
            // bottom mid
            if (OriginPositionEnum.BottomMid == OriginEnum)
            {
                Transform.Origin = new Vector2(sprite.Width / 2, sprite.Height);
            }
            // bottom rigth
            if (OriginPositionEnum.BottomRigth == OriginEnum)
            {
                Transform.Origin = new Vector2(sprite.Width, sprite.Height);
            }
        }
    }
}
