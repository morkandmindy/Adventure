using System;
using System.IO;
using System.Linq;
using System.Net.Sockets;
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

            int currRoomId = 1;

            while (true)
            {
                Room currRoom = game.Rooms.FirstOrDefault(r => r.Id == currRoomId);

                Console.WriteLine();
                Console.WriteLine(currRoom.LongDescription);
                Console.WriteLine();
                Console.Write(">");
                string command = Console.ReadLine().ToLower();
                Console.WriteLine();

                bool commandHandled = false;

                //substitute abbreviations
                switch (command)
                {
                    case "n":
                        {
                            command = "north";
                            break;
                        }

                    case "s":
                        {
                            command = "south";
                            break;
                        }
                    case "e":
                        {
                            command = "east";
                            break;
                        }
                    case "w":
                        {
                            command = "west";
                            break;
                        }
                    case "ne":
                        {
                            command = "northeast";
                            break;
                        }
                    case "nw":
                        {
                            command = "northwest";
                            break;
                        }
                    case "se":
                        {
                            command = "southeast";
                            break;
                        }
                    case "sw":
                        {
                            command = "southwest";
                            break;
                        }
                    case "u":
                        {
                            command = "up";
                            break;
                        }
                    case "d":
                        {
                            command = "down";
                            break;
                        }
                }

                Directions x;
                if (Directions.TryParse(command, true, out x))
                {
                    foreach (var passage in currRoom.Passages)
                    {
                        if (command == passage.Direction.ToString().ToLower())
                        {
                            currRoomId = passage.Destination;
                            commandHandled = true;
                        }
                       
                    }
                    if (!commandHandled)
                    {
                        Console.WriteLine("You cannot move in that direction.");
                        commandHandled = true;
                    }
                }

                if (!commandHandled)
                {
                    Console.WriteLine("I did not recognize that command.");
                }
                
            }
        }
    }
}
