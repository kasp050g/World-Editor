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
        public event EventHandler Click;

        private MouseState currentMouse;
        private MouseState previousMouse;
        private bool isHovering;

        private SpriteFont font;

        private Color hoverColor = Color.Gray;
        private Color fontColor = Color.Black;
        #endregion

        #region Properties
        public bool Clicked { get; private set; }
        public string Text { get; set; }

        public SpriteFont Font { get { return font; } set { font = value; } }
        public Vector2 Position { get { return transform.Position; } set { transform.Position = value; } }
        public Vector2 FontScale { get; set; }
        public Vector2 ButtonScale { get; set; }
        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle(
                    (int)Transform.Position.X,
                    (int)Transform.Position.Y,
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
            Transform.Scale = ButtonScale;
        }

        public override void LoadContent(ContentManager content)
        {
            base.LoadContent(content);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            if (ShowGUI == true)
            {
                var colour = Color;

                if (isHovering)
                {
                    colour = hoverColor;
                }

                spriteBatch.Draw(sprite, Transform.Position, null, colour, Transform.Rotation, Transform.Origin, ButtonScale, SpriteEffects.None, layerDepth);

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

                    if (currentMouse.LeftButton == ButtonState.Released && previousMouse.LeftButton == ButtonState.Pressed)
                    {
                        
                        Click?.Invoke(this, new EventArgs());
                    }                    
                }                
            }
        }
        #endregion
    }
}
