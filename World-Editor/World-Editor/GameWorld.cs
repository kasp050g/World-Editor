using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace World_Editor
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class GameWorld : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;


        static public List<Component> components = new List<Component>();
        static private List<Component> componentsToBeDelete = new List<Component>();
        static private List<Component> componentsToBeInstatiate = new List<Component>();

        public static Vector2 ScreenSize { get; private set; }
        public Camera camera = new Camera();

        public Player player = new Player();

        public GameWorld()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            ScreenSetting();
        }
        private void ScreenSetting()
        {
            graphics.IsFullScreen = false;
            graphics.PreferredBackBufferWidth = 1800;
            graphics.PreferredBackBufferHeight = 1000;

            ScreenSize = new Vector2(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
            



            IsMouseVisible = true;
            GUI jamen = new GUI();
            jamen.Transform.Scale = 100f;
            jamen.Color = Color.Red;
            jamen.ShowGUI = true;
            jamen.Transform.Position = new Vector2(100, 100);


            Instatiate(jamen);

            Instatiate(player);
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        #region Instatiate And Destroy
        // Instatiate
        public static void Instatiate(Component component)
        {
            componentsToBeInstatiate.Add(component);
        }
        private void CallInstatiate()
        {
            for (int i = 0; i < componentsToBeInstatiate.Count; i++)
            {
                componentsToBeInstatiate[i].Initialize();
                componentsToBeInstatiate[i].LoadContent(Content);
            }
            components.AddRange(componentsToBeInstatiate);
            componentsToBeInstatiate.Clear();
        }
        // Destroy
        public static void Destroy(Component gameObject)
        {
            componentsToBeDelete.Add(gameObject);
        }
        private void CallDestroy()
        {
            foreach (Component go in componentsToBeDelete)
            {
                components.Remove(go);
            }
            componentsToBeDelete.Clear();
        }
        #endregion

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);

            foreach (Component _component in components)
            {
                _component.Update(gameTime);
            }


            MakeBox();
            

            camera.Follow(player);

            CallInstatiate();
            CallDestroy();

        }

        public void MakeBox()
        {
            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                var mousex = Mouse.GetState().Position.X;
                var mousey = Mouse.GetState().Position.Y;
                Vector2 newPosition = new Vector2(mousex, mousey);

                Vector2 worldPosition = Vector2.Transform(newPosition, Matrix.Invert(camera.Transform));

                int positonX = (int)(worldPosition.X / 10) * 10;
                int positonY = (int)(worldPosition.Y / 10) * 10;

                if (positonX < 0)
                {
                    positonX -= 10;
                }
                if (positonY < 0)
                {
                    positonY -= 10;
                }


                GUI jamen = new GUI();
                jamen.Transform.Position = new Vector2(positonX, positonY);
                jamen.Transform.Scale = 10f;
                jamen.Color = Color.Red;
                jamen.ShowGUI = true;

                foreach (Component _component in components)
                {
                    if (_component.Transform.Position == jamen.Transform.Position)
                    {
                        Destroy(_component);
                    }
                }

                Instatiate(jamen);
            }

            if (Mouse.GetState().RightButton == ButtonState.Pressed)
            {
                var mousex = Mouse.GetState().Position.X;
                var mousey = Mouse.GetState().Position.Y;
                Vector2 newPosition = new Vector2(mousex, mousey);

                Vector2 worldPosition = Vector2.Transform(newPosition, Matrix.Invert(camera.Transform));

                int positonX = (int)(worldPosition.X / 10) * 10;
                int positonY = (int)(worldPosition.Y / 10) * 10;

                if (positonX < 0)
                {
                    positonX -= 10;
                }
                if (positonY < 0)
                {
                    positonY -= 10;
                }


                GUI jamen = new GUI();
                jamen.Transform.Position = new Vector2(positonX, positonY);
                jamen.Transform.Scale = 10f;
                jamen.Color = Color.Red;
                jamen.ShowGUI = true;

                foreach (Component _component in components)
                {
                    if (_component.Transform.Position == jamen.Transform.Position)
                    {
                        Destroy(_component);
                    }
                }

                
            }
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin(SpriteSortMode.FrontToBack, transformMatrix: camera.Transform);
            foreach (Component _component in components)
            {
                _component.Draw(gameTime, spriteBatch);
            }
            spriteBatch.End();



            //spriteBatch.Begin(SpriteSortMode.FrontToBack);
            //foreach (Component _component in components)
            //{
            //    _component.Draw(gameTime, spriteBatch);
            //}
            //spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
