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
    public class TileController
    {
        private int sizeOfTile = 100;

        private Texture2D currentSprite;
        private Texture2D grass;
        private Texture2D sand;

        public Texture2D CurrentSprite { get { return currentSprite; } set { currentSprite = value; } }

        public void LoadContent(ContentManager content)
        {
            grass = content.Load<Texture2D>("Texture/Tiles/grass_tile_3");
            sand = content.Load<Texture2D>("Texture/Tiles/sand_tile");
        }

        public void Update()
        {
            SelectTile();
            MakeTile();
            RemoveTile();
        }

        public void SelectTile()
        {
            KeyboardState keyState = Keyboard.GetState();

            if (keyState.IsKeyDown(Keys.D1))
            {
                currentSprite = grass;
            }
            if (keyState.IsKeyDown(Keys.D2))
            {
                currentSprite = sand;
            }
        }

        public void MakeTile()
        {
            if (currentSprite == null)
            {
                currentSprite = grass;
            }

            if (Mouse.GetState().LeftButton == ButtonState.Pressed && GameWorld.isMouseOverUI == false)
            {
                var mousex = Mouse.GetState().Position.X;
                var mousey = Mouse.GetState().Position.Y;
                Vector2 newPosition = new Vector2(mousex, mousey);

                Vector2 worldPosition = Vector2.Transform(newPosition, Matrix.Invert(GameWorld.camera.Transform));

                int positonX = (int)(worldPosition.X / sizeOfTile) * sizeOfTile;
                int positonY = (int)(worldPosition.Y / sizeOfTile) * sizeOfTile;


                if (positonX < 0)
                {
                    positonX -= sizeOfTile;
                }

                if (positonY < 0)
                {
                    positonY -= sizeOfTile;
                }

                if (worldPosition.X > -sizeOfTile && worldPosition.X < 0.0f)
                {
                    positonX = -sizeOfTile;
                }
                if (worldPosition.Y > -sizeOfTile && worldPosition.Y < 0.0f)
                {
                    positonY = -sizeOfTile;
                }


                Tile newTile = new Tile();
                newTile.Transform.Position = new Vector2(positonX, positonY);
                newTile.Transform.Scale = (float)((float)sizeOfTile / (float)currentSprite.Height);
                newTile.Color = Color.White;
                newTile.Sprite = currentSprite;

                foreach (Component _component in GameWorld.components)
                {
                    if (_component.Transform.Position == newTile.Transform.Position)
                    {
                        if (_component is Tile)
                            GameWorld.Destroy(_component);
                    }
                }

                GameWorld.Instatiate(newTile);
            }            
        }


        public void RemoveTile()
        {
            if (Mouse.GetState().RightButton == ButtonState.Pressed)
            {
                var mousex = Mouse.GetState().Position.X;
                var mousey = Mouse.GetState().Position.Y;
                Vector2 newPosition = new Vector2(mousex, mousey);

                Vector2 worldPosition = Vector2.Transform(newPosition, Matrix.Invert(GameWorld.camera.Transform));


                int positonX = (int)(worldPosition.X / sizeOfTile) * sizeOfTile;
                int positonY = (int)(worldPosition.Y / sizeOfTile) * sizeOfTile;


                if (positonX < 0)
                {
                    positonX -= sizeOfTile;
                }

                if (positonY < 0)
                {
                    positonY -= sizeOfTile;
                }

                if (worldPosition.X > -sizeOfTile && worldPosition.X < 0.0f)
                {
                    positonX = -sizeOfTile;
                }
                if (worldPosition.Y > -sizeOfTile && worldPosition.Y < 0.0f)
                {
                    positonY = -sizeOfTile;
                }

                Vector2 removeTilePosition = new Vector2(positonX, positonY);

                foreach (Component _component in GameWorld.components)
                {
                    if (_component.Transform.Position == removeTilePosition)
                    {
                        if(_component is Tile)
                        GameWorld.Destroy(_component);
                    }
                }


                //Tile newTile = new Tile();
                //newTile.Transform.Position = new Vector2(positonX, positonY);
                //newTile.Transform.Scale = currentSprite.Height / sizeOfTile;
                //newTile.Color = Color.White;
                //newTile.Sprite = currentSprite;

                //foreach (Component _component in GameWorld.components)
                //{
                //    if (_component.Transform.Position == newTile.Transform.Position)
                //    {
                //        GameWorld.Destroy(_component);
                //    }
                //}
            }
        }
    }
}
