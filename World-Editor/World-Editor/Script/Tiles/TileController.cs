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

        public Texture2D CurrentSprite { get { return currentSprite; } set { currentSprite = value; } }

        public void LoadContent(ContentManager content)
        {
            currentSprite = content.Load<Texture2D>("Texture/Tiles/grass_tile_3");
        }

        public void Update()
        {
            MakeTile();
            RemoveTile();
        }
        public void CheckForGUI()
        {
            MouseState currentMouse = Mouse.GetState();
            var mouseRectangle = new Rectangle(currentMouse.X, currentMouse.Y, 1, 1);

            foreach (GameObject x in GameWorld.guis)
            {
                if ((x is GUI) && mouseRectangle.Intersects((x as GUI).GUImouseBlockCollision))
                {
                    GameWorld.isMouseOverUI = true;
                }
            }
        }
        public void MakeTile()
        {
            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                CheckForGUI();

                if (GameWorld.isMouseOverUI == false)
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
                    float scaleNumber = (float)((float)sizeOfTile / (float)currentSprite.Height);
                    newTile.Transform.Scale = new Vector2(scaleNumber, scaleNumber);
                    newTile.Color = Color.White;
                    newTile.Sprite = currentSprite;

                    // Remove tile if got the same position
                    foreach (GameObject _tile in GameWorld.tiles)
                    {
                        if (_tile.Transform.Position == newTile.Transform.Position)
                        {
                            GameWorld.Destroy(_tile);
                        }
                    }

                    GameWorld.Instatiate(newTile);
                }
            }
        }


        public void RemoveTile()
        {
            if (Mouse.GetState().RightButton == ButtonState.Pressed)
            {
                CheckForGUI();

                if (GameWorld.isMouseOverUI == false)
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

                    // Remove tile if got the same position
                    foreach (GameObject _tile in GameWorld.tiles)
                    {
                        if (_tile.Transform.Position == removeTilePosition)
                        {
                            GameWorld.Destroy(_tile);
                        }
                    }
                }
            }
        }


    }
}
