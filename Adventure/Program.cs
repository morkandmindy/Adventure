using System;
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
            var userInput = "that two";
            bool huh = cmd.Matches(userInput);
            
            var cmd2 = new Cmd("go ?|?", new Directions());
            userInput = "go south";
            var huh2 = cmd2.Matches(userInput);
            //which direction was contained in userInput?

            
             


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