using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Globalization;

namespace World_Editor
{
    public class SaveTileMap
    {
        private SaveLoad saveLoad = new SaveLoad();

        public void SaveAndLoad(ContentManager content)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.K))
            {
                //SaveGame();
                SaveTile();
            }
            if (Keyboard.GetState().IsKeyDown(Keys.L))
            {
                //LoadGame();
                LoadTile(content);
            }
        }

        public void SaveTile()
        {
            List<GameObject> tiles = GameWorld.tiles;

            XElement root = new XElement("root");
            XElement tile = new XElement("tiles");

            foreach (Tile x in tiles)
            {
                tile.Add(new XElement("tile",
                            new XElement("SpriteName", x.Sprite.Name),
                            new XElement("Color", x.Color),
                            new XElement("LayerDepth", x.LayerDepth, CultureInfo.InvariantCulture),
                            new XElement("isWaterTile", x.isWaterTile),
                            // Transform
                            new XElement("Rotation", x.Transform.Rotation, CultureInfo.InvariantCulture),
                            new XElement("OriginX", x.Transform.Origin.X, CultureInfo.InvariantCulture),
                            new XElement("OriginY", x.Transform.Origin.Y, CultureInfo.InvariantCulture),
                            new XElement("PositionX", x.Transform.Position.X, CultureInfo.InvariantCulture),
                            new XElement("PositionY", x.Transform.Position.Y, CultureInfo.InvariantCulture),
                            new XElement("ScaleX", x.Transform.Scale.X.ToString(CultureInfo.InvariantCulture)),
                            new XElement("ScaleY", x.Transform.Scale.Y.ToString(CultureInfo.InvariantCulture))));
            }
            root.Add(tile);

            XDocument xd = new XDocument(root);

            saveLoad.SaveFile(xd, "SaveTest");
        }

        public void LoadTile(ContentManager content)
        {
            GameWorld.tiles.Clear();            

            XDocument xd = saveLoad.LoadFile("SaveTest");
            var allList = xd.Element("root").Element("tiles").Elements("tile");

            List<Tile> newtiles = new List<Tile>();

            foreach (var x in allList)
            {
                // XElement elements
                XElement _SpriteName = x.Element("SpriteName");
                XElement _Color = x.Element("Color");
                XElement _LayerDepth = x.Element("LayerDepth");
                XElement _isWaterTile = x.Element("isWaterTile");

                XElement _Rotation = x.Element("Rotation");

                XElement _PositionX = x.Element("PositionX");
                XElement _PositionY = x.Element("PositionY");

                XElement _OriginX = x.Element("OriginX");
                XElement _OriginY = x.Element("OriginY");

                XElement _ScaleX = x.Element("ScaleX");
                XElement _ScaleY = x.Element("ScaleY");

                // Make new Tile
                Tile tile = new Tile();

                tile.Sprite = content.Load<Texture2D>(_SpriteName.Value);
                tile.Color = Color.White;
                tile.LayerDepth = float.Parse(_LayerDepth.Value, CultureInfo.InvariantCulture);
                tile.isWaterTile = (_isWaterTile.Value == "true" ? true : false);

                // Transform
                tile.Transform.Rotation = float.Parse(_Rotation.Value, CultureInfo.InvariantCulture);

                Vector2 newPosition = new Vector2(0, 0);
                newPosition.X = float.Parse(_PositionX.Value, CultureInfo.InvariantCulture);
                newPosition.Y = float.Parse(_PositionY.Value, CultureInfo.InvariantCulture);
                tile.Transform.Position = newPosition;

                Vector2 newOrigin = new Vector2(0, 0);
                newOrigin.X = float.Parse(_OriginX.Value, CultureInfo.InvariantCulture);
                newOrigin.Y = float.Parse(_OriginY.Value, CultureInfo.InvariantCulture);
                tile.Transform.Origin = newPosition;

                Vector2 newScale = new Vector2(0.0f, 0.0f);
                newScale.X = float.Parse(_ScaleX.Value, CultureInfo.InvariantCulture);
                newScale.Y = float.Parse(_ScaleY.Value, CultureInfo.InvariantCulture);
                tile.Transform.Scale = newScale;

                

                newtiles.Add(tile);
            }

            foreach (Tile x in newtiles)
            {
                GameWorld.Instatiate(x);
            }
        }
    }
}
