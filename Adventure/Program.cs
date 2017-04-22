using System;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

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
            OfferInstructions();

            int currRoomId = 1;
            while (true) //keep running until Ctrl+C
            {
                Room currRoom = game.Rooms.FirstOrDefault(r => r.Id == currRoomId);
                bool commandProcessed = false;
                Command command = null;

                if (currRoom != null)
                {
                    ConsoleHelper.WriteLineWordWrap(currRoom.LongDescription);
                    Console.Write("> ");

                    var readLine = Console.ReadLine();
                    if (readLine != null)
                    {
                        command = new Command(readLine.ToLower());

                        Console.WriteLine();

                        //process move
                        if (command.Direction != null
                            && currRoom.Passages.FirstOrDefault(p => p.Direction == command.Direction) != null)
                        {
                            var firstOrDefault = currRoom.Passages.FirstOrDefault(p => p.Direction == command.Direction);
                            if (firstOrDefault != null)
                            {
                                currRoomId = firstOrDefault.Destination;
                                commandProcessed = true;
                            }
                        }

                    }
                }
                if (!commandProcessed)
                {
                    Console.WriteLine("Sorry, I don't know the word '" + command.Verb + "");
                }
                Console.WriteLine();
            }
        }

        private static void OfferInstructions()
        {
            bool InstructionsHandled = false;
            while (!InstructionsHandled)
            {
                Console.WriteLine("Welcome to Adventure!! Would you like instructions?");

                Console.Write("> ");
                var yesno = Console.ReadLine().ToLower();
                if (yesno == "yes" || yesno == "y")
                {
                    ConsoleHelper.WriteLineWordWrap(
                        @"Somewhere nearby is Colossal Cave, where others have found fortunes in treasure and gold, though it is rumored that some who enter are never seen again. Magic is said to work in the cave. I will be your eyes and hands. Direct me with commands of 1 or 2 words.");
                    InstructionsHandled = true;
                }
                else if (yesno == "no" || yesno == "n")
                {
                    Console.WriteLine("OK.");
                    InstructionsHandled = true;
                }
                else
                {
                    Console.WriteLine("Please answer Yes or No.");
                }
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
