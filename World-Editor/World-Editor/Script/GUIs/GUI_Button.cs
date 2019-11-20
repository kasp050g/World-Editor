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
    public class GUI_Button : GUI
    {
        #region Fields
        private MouseState currentMouse;
        private MouseState previousMouse;
        private bool isHovering;

        private SpriteFont font;
        private Texture2D sprite;
        private Color hoverColor = Color.Gray;
        private Color defaultColor = Color.White;
        private Color fontColor = Color.Black;
        #endregion

        #region Properties
        public float layerDepth;
        public event EventHandler Click;
        public bool Clicked { get; private set; }
        public string Text { get; set; }
        public OriginPosition Origin { get; set; }
        public SpriteFont Font { get { return font; } set { font = value; } }
        public Texture2D Sprite { get{ return sprite; } set { sprite = value; } }
        public Vector2 Position { get; set; }
        public Vector2 FontScale { get; set; }
        public Vector2 ButtonScale { get; set; }
        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle(
                    (int)Position.X,
                    (int)Position.Y,
                    (int)(sprite.Width * ButtonScale.X),
                    (int)(sprite.Height * ButtonScale.Y));
            }
        }
        #endregion

        #region Constructor
        public GUI_Button()
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
            SetOrigin();
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);
            if (ShowGUI == true)
            {
                var colour = defaultColor;

                if (isHovering)
                {
                    colour = hoverColor;
                }

                spriteBatch.Draw(sprite, Position, null, colour, 0f, Vector2.Zero, ButtonScale, SpriteEffects.None, layerDepth);

                if (!string.IsNullOrEmpty(Text))
                {
                    var x = (Rectangle.X + (Rectangle.Width / 2)) - (font.MeasureString(Text).X / 2) * FontScale.X;
                    var y = (Rectangle.Y + (Rectangle.Height / 2)) - (font.MeasureString(Text).Y / 2) * FontScale.Y;

                    spriteBatch.DrawString(font, Text, new Vector2(x, y), fontColor, 0f, Vector2.Zero, FontScale, SpriteEffects.None, layerDepth);
                }
            }
        }

        public override void Update(GameTime gameTime)
        {

            base.Update(gameTime);
            if (ShowGUI == true)
            {
                previousMouse = currentMouse;
                currentMouse = Mouse.GetState();

                var mouseRectangle = new Rectangle(currentMouse.X, currentMouse.Y, 1, 1);


                isHovering = false;

                if (mouseRectangle.Intersects(Rectangle))
                {
                    isHovering = true;
                    

                    if (currentMouse.RightButton == ButtonState.Released && previousMouse.RightButton == ButtonState.Pressed)
                    {
                        
                        Click?.Invoke(this, new EventArgs());
                    }

                    
                }
                
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
