using System.IO;
using System.Xml.Serialization;

using AdventureDataModel;

namespace Adventure
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = LoadGame(@"..\..\GameData.xml");
            IConsole console = new WordWrapConsole(); //a better console with word-wrap!
            game.Run(console);
        }

        private static Game LoadGame(string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Game));
            FileStream loadStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            Game game = (Game)serializer.Deserialize(loadStream);
            loadStream.Close();
            return game;
        }
    }
}
