﻿using System;

using AdventureDataModel;

namespace Adventure
{
    class Command
    {
        public Command(string val)
        {
            string[] words = val.Split(' ');
            string verb = ReplaceAbbreviations(words[0].ToLower());
            string noun = string.Empty;
            if (words.Length == 2)
            {
                noun = ReplaceAbbreviations(words[1].ToLower());
            }

            Direction = ParseDirection(verb, noun);
        }

        private Directions? ParseDirection(string verb, string noun)
        {
            Directions? retval = null;
            if (verb == "go")
            {
                if (IsDirection(noun))
                {
                    Directions d;
                    Directions.TryParse(noun, out d);
                    retval = d;
                }
                else
                {
                    //throw exception with message handing back the user's input
                }
            }
            else if (IsDirection(verb))
            {
                Directions d;
                Directions.TryParse(verb, true, out d);
                retval = d;
            }
            return retval;
        }

        public Verbs? Verb { get; set; }
        public Nouns? Noun { get; set; }
        public Directions? Direction { get; set; }


        private bool IsDirection(string val)
        {
            Directions d;
            return Directions.TryParse(val, true, out d);
        }

        private bool IsNoun(string val)
        {
            Nouns n;
            return Nouns.TryParse(val, true, out n);
        }

        private bool IsVerb(string val)
        {
            Verbs v;
            return Verbs.TryParse(val, true, out v);
        }

        private static string ReplaceAbbreviations(string command)
        {
            switch (command)
            {
                case "n":
                    {
                        command = "North";
                        break;
                    }

                case "s":
                    {
                        command = "South";
                        break;
                    }
                case "e":
                    {
                        command = "East";
                        break;
                    }
                case "w":
                    {
                        command = "West";
                        break;
                    }
                case "ne":
                    {
                        command = "NorthEast";
                        break;
                    }
                case "nw":
                    {
                        command = "NorthWest";
                        break;
                    }
                case "se":
                    {
                        command = "SouthEast";
                        break;
                    }
                case "sw":
                    {
                        command = "SouthWest";
                        break;
                    }
                case "u":
                    {
                        command = "Up";
                        break;
                    }
                case "d":
                    {
                        command = "Down";
                        break;
                    }
            }
            return command;
        }
    }
}
