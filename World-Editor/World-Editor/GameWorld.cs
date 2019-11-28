using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Xml;

namespace World_Editor
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class GameWorld : Game
    {
        #region Fields
        // Public
        public static Camera camera = new Camera();
        public static SpriteContainer spriteContainer = new SpriteContainer();
        public static bool isMouseOverUI = false;
        public static Editor editor = new Editor();
        // UI
        public static List<GameObject> guis = new List<GameObject>();
        // Game Objects
        public static List<GameObject> gameObjects = new List<GameObject>();

        // Tile's
        public static List<GameObject> tiles = new List<GameObject>();
        // Description's
        public static List<GameObject> descriptions = new List<GameObject>();
        // Enemy Spawn's
        public static List<GameObject> enemySpawns = new List<GameObject>();


        // Private
        static private List<GameObject> gameObjectsToBeDelete = new List<GameObject>();
        static private List<GameObject> gameObjectsToBeInstatiate = new List<GameObject>();
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private SaveTileMap saveTileMap = new SaveTileMap();
        #endregion

        #region Properties
        public static Vector2 ScreenSize { get; private set; }
        #endregion

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
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            spriteContainer.LoadContent(Content);
            // TODO: use this.Content to load your game content here

            Instatiate(editor);
        }

        #region Instatiate And Destroy
        // Instatiate
        public static void Instatiate(GameObject component)
        {
            gameObjectsToBeInstatiate.Add(component);
        }
        private void CallInstatiate()
        {
            for (int i = 0; i < gameObjectsToBeInstatiate.Count; i++)
            {
                gameObjectsToBeInstatiate[i].Initialize();
                gameObjectsToBeInstatiate[i].LoadContent(Content);
                if (gameObjectsToBeInstatiate[i] is GUI)
                {
                    guis.Add(gameObjectsToBeInstatiate[i]);
                }
                else if (gameObjectsToBeInstatiate[i] is Tile)
                {
                    tiles.Add(gameObjectsToBeInstatiate[i]);
                }
                else if (gameObjectsToBeInstatiate[i] is Description)
                {
                    descriptions.Add(gameObjectsToBeInstatiate[i]);
                }
                else if (gameObjectsToBeInstatiate[i] is EnemySpawn)
                {
                    enemySpawns.Add(gameObjectsToBeInstatiate[i]);
                }
                else
                {
                    gameObjects.Add(gameObjectsToBeInstatiate[i]);
                }
            }

            gameObjectsToBeInstatiate.Clear();
        }
        // Destroy
        public static void Destroy(GameObject component)
        {
            gameObjectsToBeDelete.Add(component);
        }
        private void CallDestroy()
        {
            for (int i = 0; i < gameObjectsToBeDelete.Count; i++)
            {
                if (gameObjectsToBeDelete[i] is GUI)
                {
                    guis.Remove(gameObjectsToBeDelete[i]);

                }
                else if (gameObjectsToBeDelete[i] is Tile)
                {
                    tiles.Remove(gameObjectsToBeDelete[i]);
                }
                else if (gameObjectsToBeDelete[i] is Description)
                {
                    descriptions.Remove(gameObjectsToBeDelete[i]);
                }
                else if (gameObjectsToBeDelete[i] is EnemySpawn)
                {
                    enemySpawns.Remove(gameObjectsToBeDelete[i]);
                }
                else
                {
                    gameObjects.Remove(gameObjectsToBeDelete[i]);
                }
            }
            gameObjectsToBeDelete.Clear();
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

            foreach (GameObject _component in gameObjects)
            {
                _component.Update(gameTime);
            }
            foreach (Tile _tile in tiles)
            {
                _tile.Update(gameTime);
            }
            foreach (Description _descriptions in descriptions)
            {
                _descriptions.Update(gameTime);
            }
            foreach (EnemySpawn _enemySpawns in enemySpawns)
            {
                _enemySpawns.Update(gameTime);
            }
            foreach (GUI _gui in guis)
            {
                _gui.Update(gameTime);
            }

            camera.Follow(editor);

            CallInstatiate();
            CallDestroy();
            isMouseOverUI = false;

            saveTileMap.SaveAndLoad(Content);
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
            foreach (GameObject _component in gameObjects)
            {
                _component.Draw( spriteBatch);
            }
            foreach (Tile _tile in tiles)
            {
                _tile.Draw( spriteBatch);
            }
            foreach (Description _descriptions in descriptions)
            {
                _descriptions.Draw(spriteBatch);
            }
            foreach (EnemySpawn _enemySpawns in enemySpawns)
            {
                _enemySpawns.Draw(spriteBatch);
            }
            spriteBatch.End();

            spriteBatch.Begin(SpriteSortMode.FrontToBack);
            foreach (GUI _gui in guis)
            {
                _gui.Draw( spriteBatch);
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
