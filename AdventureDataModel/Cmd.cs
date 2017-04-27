using System;
using System.Collections.Generic;

namespace AdventureDataModel
{
    public class Cmd
    {
        private readonly List<string> _commandMatches = new List<string>();

        public Cmd(string userInput)
        {
            foreach (var twoWordCommand in userInput.Split('|'))
            {
                // at this point, we're expecting two words separated by a space.
                // each of those words could be a comma-separated list of words that need xproduct-ing
                //produce xproduct of x1, x2 (notice how we ignore any extra words? hahahahahaha!!!)
                var words = twoWordCommand.Split(' ');
                var x1 = words.Length == 1 ? words[0] : string.Empty;
                var x2 = words.Length == 2 ? words[1] : string.Empty;
                var terms1 = x1.Split(',');
                var terms2 = x2.Split(',');
                foreach (var t1 in terms1)
                {
                    foreach (var t2 in terms2)
                    {
                        _commandMatches.Add(t1.ToUpper() + " " + t2.ToUpper());
                    }
                }
            }
        }

        public bool Matches(string input)
        {
            return _commandMatches.Contains(input.ToUpper());
        }

        //public bool Matches<T>(string input, out T val)
        //{
        //    var matches = new List<string>();
        //    //input has a ? in it. find it and replace it with every string representation of T enum.
        //    foreach (var name in Enum.GetNames(typeof(T)))
        //    { 
        //        matches.Add(name.ToUpper());
        //    }

        //    val = (T) Enum.Parse(typeof(Directions), input);

        //    return matches.Contains(input.ToUpper());
        //}

    }
}