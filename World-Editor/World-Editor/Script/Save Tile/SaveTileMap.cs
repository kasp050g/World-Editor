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


namespace World_Editor
{
    public class SaveTileMap
    {
        private SaveLoad saveLoad = new SaveLoad();


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
                            // Transform
                            new XElement("Rotation", x.Transform.Rotation),
                            new XElement("OriginX", x.Transform.Origin.X),
                            new XElement("OriginY", x.Transform.Origin.Y),
                            new XElement("PositionX", x.Transform.Position.X),
                            new XElement("PositionY", x.Transform.Position.Y),
                            new XElement("ScaleX", x.Transform.Scale.X),
                            new XElement("ScaleY", x.Transform.Scale.Y)));
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

                tile.Transform.Rotation = float.Parse(_Rotation.Value);

                Vector2 newPosition = new Vector2(0, 0);
                newPosition.X = float.Parse(_PositionX.Value);
                newPosition.Y = float.Parse(_PositionY.Value);
                tile.Transform.Position = newPosition;

                Vector2 newOrigin = new Vector2(0, 0);
                newOrigin.X = float.Parse(_OriginX.Value);
                newOrigin.Y = float.Parse(_OriginY.Value);
                tile.Transform.Origin = newPosition;

                Vector2 newScale = new Vector2(0, 0);
                newScale.X = float.Parse(_ScaleX.Value);
                newScale.Y = float.Parse(_ScaleY.Value);
                tile.Transform.Scale = newScale;

                tile.Color = Color.White;

                newtiles.Add(tile);
            }

            foreach (Tile x in newtiles)
            {
                GameWorld.Instatiate(x);
            }
        }
    }
}
