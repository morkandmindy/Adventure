using System;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Xml.Serialization;

using AdventureDataModel;

namespace Adventure
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = LoadGame(@"..\..\GameData.xml");

            RunGame(game);
        }


        private static void RunGame(Game game)
        {
            int currRoomId = 1;
            while (true) //keep running until Ctrl+C
            {
                Room currRoom = game.Rooms.FirstOrDefault(r => r.Id == currRoomId);

                ConsoleHelper.WriteLineWordWrap(currRoom.LongDescription);
                Console.Write("> ");

                Command cmd = new Command(Console.ReadLine().ToLower());

                Console.WriteLine();

                if (cmd.Direction != null && currRoom.Passages.Where(p => p.Direction == cmd.Direction).FirstOrDefault() != null)
                {
                    currRoomId = currRoom.Passages.Where(p => p.Direction == cmd.Direction).FirstOrDefault().Destination;
                    
                }

                //bool commandHandled = false;
                //Directions x;
                //if (Directions.TryParse(command, true, out x))
                //{
                //    foreach (var passage in currRoom.Passages)
                //    {
                //        if (command == passage.Direction.ToString().ToLower())
                //        {
                //            currRoomId = passage.Destination;
                //            commandHandled = true;
                //        }
                //    }
                //    if (!commandHandled)
                //    {
                //        Console.WriteLine("You cannot move in that direction.");
                //        commandHandled = true;
                //    }
                //}
                //if (!commandHandled)
                //{
                //    Console.WriteLine("I did not recognize that command.");
                //}

                Console.WriteLine();
            }
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
