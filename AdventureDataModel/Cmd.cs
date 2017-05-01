using System;
using System.Collections.Generic;

namespace AdventureDataModel
{
    public class Cmd
    {
        private readonly List<string> _commandMatches = new List<string>();
        
        
        public Cmd(string userInput)
        {
            Parse(userInput, null);
        }

        public Cmd(string userInput, Object enumType)
        {
            Parse(userInput, Enum.GetNames(enumType.GetType()));
        }

        private void Parse(string userInput, string[] enumValues )
        {

            foreach (var twoWordCommand in userInput.Split('|'))
            {
                // at this point, we're expecting two words separated by a space.
                // each of those words could be a comma-separated list of words that need xproduct-ing
                //produce xproduct of x1, x2
                var words = twoWordCommand.Split(' ');
                var x1 = words[0];
                var x2 = words.Length == 2 ? words[1] : string.Empty;
                var terms1 = x1.Split(',');
                var terms2 = x2.Split(',');
                foreach (var t1 in terms1)
                {
                    foreach (var t2 in terms2)
                    {
                        if (enumValues == null)
                        {
                            _commandMatches.Add(t1.ToUpper() + " " + t2.ToUpper());
                        }
                        else
                        {
                            foreach (var enumValue in enumValues)
                            {
                                _commandMatches.Add(t1.Replace("?", enumValue).ToUpper()
                                    + " " + t2.Replace("?", enumValue).ToUpper());
                            }
                        }
                    }
                }
            }
        }

        public bool Matches(string input)
        {
            return _commandMatches.Contains(input.ToUpper());
        }

        //public bool Matches(string input, out string val)
        //{

        //    return _commandMatches.Contains(input.ToUpper());
        //}

    }
}