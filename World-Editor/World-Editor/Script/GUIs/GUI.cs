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
        protected Texture2D sprite;
        protected Color defaultColor = Color.White;
        protected  float layerDepth = 0.01f;
        #endregion


        #region Properties
        public bool ShowGUI { get; set; }
        //public Transform Transform { get { return transform; } set { transform = value; } }
        //public Texture2D Sprite { get { return sprite; } set { sprite = value; } }
        //public OriginPosition Origin { get; set; }
        //public float LayerDepth { get { return layerDepth; } set { layerDepth = value; } }
        //public bool ShowGUI { get; set; }
        //public Color Color { get; set; }
        public OriginPosition Origin { get; set; }
        #endregion


        #region Methods
        public override void Initialize()
        {
            
        }

        public override void LoadContent(ContentManager content)
        {
            SetOrigin();
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

        public void SetOrigin()
        {
            // --- Top ---

            // top left
            if (OriginPosition.TopLeft == Origin)
            {
                Transform.Origin = new Vector2(0, 0);
            }
            // top mid
            if (OriginPosition.TopMid == Origin)
            {
                Transform.Origin = new Vector2(sprite.Width / 2, 0);
            }
            // top rigth
            if (OriginPosition.TopRigth == Origin)
            {
                Transform.Origin = new Vector2(sprite.Width, 0);
            }

            // --- Mid ---

            // mid left
            if (OriginPosition.MidLeft == Origin)
            {
                Transform.Origin = new Vector2(0, sprite.Height / 2);
            }
            // mid 
            if (OriginPosition.Mid == Origin)
            {
                Transform.Origin = new Vector2(sprite.Width / 2, sprite.Height / 2);
            }
            // mid rigth
            if (OriginPosition.MidRigth == Origin)
            {
                Transform.Origin = new Vector2(sprite.Width, sprite.Height / 2);
            }

            // --- Bottom ---

            // bottom left
            if (OriginPosition.BottomLeft == Origin)
            {
                Transform.Origin = new Vector2(0, sprite.Height);
            }
            // bottom mid
            if (OriginPosition.BottomMid == Origin)
            {
                Transform.Origin = new Vector2(sprite.Width / 2, sprite.Height);
            }
            // bottom rigth
            if (OriginPosition.BottomRigth == Origin)
            {
                Transform.Origin = new Vector2(sprite.Width, sprite.Height);
            }
        }
        #endregion
    }
}
