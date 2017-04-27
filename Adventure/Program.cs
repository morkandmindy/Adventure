using System.IO;
using System.Net.Configuration;
using System.Xml.Serialization;
using AdventureDataModel;

namespace Adventure
{
    internal class Program
    {
        private static void Main(string[] args)
        {

            var cmd = new Cmd("this,that,theother one,two,three|red,green up,down|xyzzy pig,sow|alpha beta|xyzzy");
            bool huh = cmd.Matches("that two");
            //Directions x;
            //bool huh2 = cmd.Matches("get ?", out x);




            var game = LoadGame(@"..\..\GameData.xml");
            IConsole console = new WordWrapConsole(); //a better console with word-wrap!
            game.Run(console);
        }

        private static Game LoadGame(string fileName)
        {
            var serializer = new XmlSerializer(typeof(Game));
            var loadStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            var game = (Game) serializer.Deserialize(loadStream);
            loadStream.Close();
            return game;
        }
    }
}