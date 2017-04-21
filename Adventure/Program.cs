using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Adventure
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Game));
            FileStream loadStream = new FileStream(@"..\..\GameData.xml", FileMode.Open, FileAccess.Read);
            Game game = (Game)serializer.Deserialize(loadStream);
            loadStream.Close();

            foreach (var room in game.Rooms)
            {
                Console.WriteLine(room.LongDescription);
            }
        }
    }
}
