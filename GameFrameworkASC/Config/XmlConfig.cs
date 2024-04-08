using GameFrameworkASC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace GameFrameworkASC.Config
{
    public static class XmlConfig
    {
        
        public static GameWorld ConfigWorld(string filepath)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filepath);

            XmlNode xNode = doc.DocumentElement.SelectSingleNode("XWidth");
            XmlNode yNode = doc.DocumentElement.SelectSingleNode("YWidth");

            string xString = xNode.InnerText.Trim();
            string yString = yNode.InnerText.Trim();

            int x = int.Parse(xString);
            int y = int.Parse(yString);


            GameWorld gameWorld = new GameWorld(x, y);
            return gameWorld;

        }
    }
}
