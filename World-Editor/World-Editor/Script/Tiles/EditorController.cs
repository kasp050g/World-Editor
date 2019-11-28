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
    public class EditorController
    {
        private int sizeOfTile;
        private Texture2D currentSprite;

        public Texture2D CurrentSprite { get { return currentSprite; } set { currentSprite = value; } }
        public SelectedTileType CurrentSelectedTileType { get; set; }

        public EditorController(int sizeOfTile)
        {
            this.sizeOfTile = sizeOfTile;
        }

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

                    MakeNewTileType(CurrentSelectedTileType, new Vector2(positonX, positonY));
                }
            }
        }

        public void MakeNewTileType(SelectedTileType _selectedTileType, Vector2 _position)
        {
            if(_selectedTileType == SelectedTileType.Tile)
            {
                Tile newTile = new Tile();
                newTile.Transform.Position = new Vector2(_position.X, _position.Y);
                float scaleNumber = (float)((float)sizeOfTile / (float)currentSprite.Height);
                newTile.Transform.Scale = new Vector2(scaleNumber, scaleNumber);
                newTile.Color = Color.White;
                newTile.Sprite = currentSprite;
                newTile.LayerDepth = 0.001f;

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
            else if(_selectedTileType == SelectedTileType.Decoration)
            {
                Description newDescriptions = new Description();
                newDescriptions.Transform.Position = new Vector2(_position.X, _position.Y);
                float scaleNumber = (float)((float)sizeOfTile / (float)currentSprite.Height);
                newDescriptions.Transform.Scale = new Vector2(scaleNumber * 1.5f, scaleNumber * 1.5f);
                newDescriptions.Color = Color.White;
                newDescriptions.Sprite = currentSprite;
                newDescriptions.LayerDepth = 0.002f + (((_position.Y/100) + 10000) / 1000000);
                newDescriptions.OriginEnum = OriginPositionEnum.MidLeft;
                newDescriptions.SetOrigin();


                // Remove tile if got the same position
                foreach (GameObject _descriptions in GameWorld.descriptions)
                {
                    if (_descriptions.Transform.Position == newDescriptions.Transform.Position)
                    {
                        GameWorld.Destroy(_descriptions);
                    }
                }

                GameWorld.Instatiate(newDescriptions);
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

                    RemoveOldTile(CurrentSelectedTileType, removeTilePosition);
                }
            }
        }

        public void RemoveOldTile(SelectedTileType _selectedTileType, Vector2 _position)
        {
            if (_selectedTileType == SelectedTileType.Tile)
            {
                // Remove tile if got the same position
                foreach (GameObject _tile in GameWorld.tiles)
                {
                    if (_tile.Transform.Position == _position)
                    {
                        GameWorld.Destroy(_tile);
                    }
                }
            }
            else if (_selectedTileType == SelectedTileType.Decoration)
            {
                // Remove tile if got the same position
                foreach (GameObject _descriptions in GameWorld.descriptions)
                {
                    if (_descriptions.Transform.Position == _position)
                    {
                        GameWorld.Destroy(_descriptions);
                    }
                }
            }
        }
    }
}
