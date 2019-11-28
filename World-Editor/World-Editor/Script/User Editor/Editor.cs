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
    public class Editor : GameObject
    {
        #region Fields
        private static int sizeOfTile = 100;
        public EditorController tileController = new EditorController(sizeOfTile);
        public TileActionBarGUI tileActionBarGUI = new TileActionBarGUI();
        #endregion



        #region Properties

        #endregion



        #region Constructor
        public Editor()
        {

        }
        #endregion



        #region Methods
        public override void Initialize()
        {
            tileActionBarGUI.Initialize();
            tileActionBarGUI.editorController = tileController;
        }

        public override void LoadContent(ContentManager content)
        {
            tileController.LoadContent(content);
        }
        public override void Draw( SpriteBatch spriteBatch)
        {

        }

        public override void Update(GameTime gameTime)
        {
            tileController.Update();

            KeyboardState keyState = Keyboard.GetState();

            // if we move, move player and play run Animate
            if (keyState.IsKeyDown(Keys.Up) || keyState.IsKeyDown(Keys.W))
            {
                Transform.Position += new Vector2(0, -10);
            }
            if (keyState.IsKeyDown(Keys.Down) || keyState.IsKeyDown(Keys.S))
            {
                Transform.Position += new Vector2(0, 10);
            }

            if (keyState.IsKeyDown(Keys.Left) || keyState.IsKeyDown(Keys.A))
            {
                Transform.Position += new Vector2(-10, 0);
            }
            if (keyState.IsKeyDown(Keys.Right) || keyState.IsKeyDown(Keys.D))
            {
                Transform.Position += new Vector2(10, 0);
            }
        }


        #endregion
    }
}
