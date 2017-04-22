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
        private Room _currRoom;
        private bool _gameRunning = true;

        [XmlArray(ElementName = "Rooms")]
        [XmlArrayItem(ElementName = "Room")]
        public List<Room> Rooms { get; set; }

        public void Run(IConsole console)
        {
            _console = console;
            OfferInstructions();
            GameLoop(1);
        }

        private void GameLoop(int startingRoom)
        {
            _currRoom = GetRoomFromId(startingRoom);

            while (_gameRunning)
            {
                _console.WriteLine(_currRoom.LongDescription);
                _console.Write("> ");
                var userInput = _console.ReadLine();
                _console.WriteLine();

                Command command = new Command(userInput.ToLower());

                if (!ProcessCommands(command))
                {
                    _console.WriteLine(userInput == string.Empty
                        ? "Tell me to do something."
                        : "Sorry, I don't understand your command.");
                    _console.WriteLine();
                }
            }
        }

        private bool ProcessCommands(Command command)
        {
            var commandProcessed = ProcessDirectionCommands(command);
            if (!commandProcessed)
            {
                commandProcessed = ProcessVerbOnlyCommands(command);
                if (!commandProcessed)
                {
                    commandProcessed = ProcessVerbNounCommands(command);
                }
            }
            return commandProcessed;
        }

        private bool ProcessDirectionCommands(Command command)
        {
            bool commandProcessed = false;
            if (command.Direction != null)
            {
                var passage = _currRoom.Passages.FirstOrDefault(p => p.Direction == command.Direction);
                if (passage != null)
                {
                    _currRoom = GetRoomFromId(passage.Destination);
                    commandProcessed = true;
                }
                else
                {
                    _console.WriteLine("There is no way to go in that direction.");
                    commandProcessed = true;
                }
            }
            return commandProcessed;
        }

        private bool ProcessVerbOnlyCommands(Command command)
        {
            bool commandProcessed = false;
            if (command.Verb == Verbs.Quit)
            {
                _console.WriteLine("Do you really want to quit now?");
                //TODO: extract the Y/N input logic from OfferInstructions for reuse here.
                _gameRunning = false;
                commandProcessed = true;
            }
            return commandProcessed;
        }

        private bool ProcessVerbNounCommands(Command command)
        {
            bool commandProcessed = false;
            return commandProcessed;
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
                    _console.WriteLine(
                        @"Somewhere nearby is Colossal Cave, where others have found fortunes in treasure and gold, though it is rumored that some who enter are never seen again. Magic is said to work in the cave. I will be your eyes and hands. Direct me with commands of 1 or 2 words.");
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
