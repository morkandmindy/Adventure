using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

using AdventureDataModel;

namespace Adventure
{
    [XmlRoot("Game"), Serializable]
    public class Game
    {
        private IConsole _console;

        [XmlArray(ElementName = "Rooms")]
        [XmlArrayItem(ElementName = "Room")]
        public List<Room> Rooms { get; set; }

        public void Run(IConsole console)
        {
            if (console != null)
            {
                _console = console;
            }
            else
            {
                throw new ArgumentNullException();
            }

            OfferInstructions();

            GameLoop(1); //by convention we start in room 1.
        }

        private void GameLoop(int startingRoom)
        {
            Room currRoom = GetRoomFromId(startingRoom);

            while (true) //keep running until Ctrl+C
            {
                if (currRoom == null)
                {
                    //we fell off the map!
                    throw new NullReferenceException();
                }
                bool commandProcessed = false;

                _console.WriteLine(currRoom.LongDescription);
                _console.Write("> ");

                var readLine = _console.ReadLine();
                if (readLine != string.Empty)
                {
                    Command command = new Command(readLine.ToLower());

                    _console.WriteLine();

                    //process direction commands
                    if (command.Direction != null)
                    {
                        var passage = currRoom.Passages.FirstOrDefault(p => p.Direction == command.Direction);
                        if (passage != null)
                        {
                            currRoom = GetRoomFromId(passage.Destination);
                            commandProcessed = true;
                        }
                        else
                        {
                            _console.WriteLine("There is no way to go in that direction.");
                            commandProcessed = true;
                        }
                    }

                    //process verb-only commands

                    //process verb-noun commands

                }
                else
                {
                    _console.WriteLine("Tell me to do something.");
                    commandProcessed = true;
                }
                if (!commandProcessed)
                {
                    _console.WriteLine("Sorry, I don't understand your command.");
                }
                _console.WriteLine();
            }
        }

        private Room GetRoomFromId(int id)
        {
            return Rooms.FirstOrDefault(r => r.Id == id);
        }

        private void OfferInstructions()
        {
            bool instructionsHandled = false;
            while (!instructionsHandled)
            {
                _console.WriteLine("Welcome to Adventure!! Would you like instructions?");
                _console.Write("> ");
                var yesno = _console.ReadLine().ToLower();
                if (yesno == "yes" || yesno == "y")
                {
                    _console.WriteLine(@"Somewhere nearby is Colossal Cave, where others have found fortunes in treasure and gold, though it is rumored that some who enter are never seen again. Magic is said to work in the cave. I will be your eyes and hands. Direct me with commands of 1 or 2 words.");
                    instructionsHandled = true;
                }
                else if (yesno == "no" || yesno == "n")
                {
                    _console.WriteLine("OK.");
                    instructionsHandled = true;
                }
                else
                {
                    _console.WriteLine("Please answer Yes or No.");
                }
                _console.WriteLine();
            }
        }
    }
}
