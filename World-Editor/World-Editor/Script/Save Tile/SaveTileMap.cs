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

namespace World_Editor
{
    public class SaveTileMap
    {
        private SaveLoad saveLoad = new SaveLoad();


        public void SaveTile()
        {
            List<Component> tiles = GameWorld.tiles;

            XElement root = new XElement("root");
            XElement tile = new XElement("tiles");

            foreach (Tile x in tiles)
            {
                tile.Add(new XElement("tile",
                            new XElement("SpriteName", x.Sprite.Name),
                            new XElement("Color", x.Color),
                            // Transform
                            new XElement("Origin", x.Transform.Origin),
                            new XElement("Rotation", x.Transform.Rotation),
                            new XElement("Position", x.Transform.Position),
                            new XElement("Scale", x.Transform.Scale)));
            }
            root.Add(tile);

            XDocument xd = new XDocument(root);

            saveLoad.SaveFile(xd, "SaveTest");
        }

        public void LoadTile(/*ContentManager content*/)
        {
            GameWorld.tiles.Clear();

            

            XDocument xd = saveLoad.LoadFile("SaveTest");

            List<XElement> loadList = (from t in xd.Element("root").Element("tiles").Descendants("tile")
                                select t).ToList<XElement>();

            List<Tile> newtiles = new List<Tile>();

            foreach (var attribute in loadList.Attributes())
            {
                string value = attribute.Value;
                
            }



        }


        public void Tseatata()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Tile>));

            using (FileStream stream = File.OpenWrite("filename"))
            {
                List<Tile> list = new List<Tile>();
                serializer.Serialize(stream, list);
            }

            using (FileStream stream = File.OpenRead("filename"))
            {
                List<Tile> dezerializedList = (List<Tile>)serializer.Deserialize(stream);
            }
        }
    }
}
