using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace World_Editor
{
    public class SaveLoad
    {
        string fileName = "tileMap.xml";

        string gameName = "AAA_GameName_";
        string appDataFilePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        string baseFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\" + "NameOfGame";

        public void Load()
        {
            if (!File.Exists(fileName))
            {

            }
            else
            {

            }
        }

        public void CreateBaseFolders()
        {
            CreateFolder(appDataFilePath + "\\" + gameName + "");
            CreateFolder(appDataFilePath + "\\" + gameName + "\\XML");
            CreateFolder(appDataFilePath + "\\" + gameName + "\\XML\\SavedGames");
        }

        public void CreateFolder(string folderPath)
        {
            DirectoryInfo CreateSiteDirectory = new DirectoryInfo(folderPath);
            if (!CreateSiteDirectory.Exists)
            {
                CreateSiteDirectory.Create();
            }
        }

        public bool CheckIfFileExists(string path)
        {
            bool fileExists;

            fileExists = File.Exists(appDataFilePath + "\\" + gameName + "\\XML\\" + path);

            return fileExists;
        }

        public void DeleteFile(string path)
        {
            File.Delete(path);
        }

        public XDocument GetFile(string file)
        {
            if (CheckIfFileExists(file))
            {
                return XDocument.Load(appDataFilePath + "\\" + gameName + "\\XML\\" + file);
            }

            return null;
        }

        public XDocument LoadFile(string filePath)
        {
            XDocument xml = GetFile(filePath);

            return xml;
        }

        public void SaveFile(XDocument xml, string path)
        {
            CreateBaseFolders();
            xml.Save(appDataFilePath + "\\" + gameName + "\\XML\\" + path);
        }
    }
}
