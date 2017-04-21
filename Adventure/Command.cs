using AdventureDataModel;

namespace Adventure
{
    class Command
    {
        public Command(string val)
        {
            string[] words = val.Split(' ');
            string verb = words[0].ToLower();
            if (words.Length == 2)
            {
                string noun = words[1].ToLower();
            }

            if (verb == "go")
            {
                if (IsDirection(noun))
                {
                    Directions d;
                    Directions.TryParse(noun, out d);
                    Direction = d;
                }
                else
                {
                    //throw exception with message handing back the user's input
                }
            }
            else if (IsDirection(verb))
            {
                Directions d;
                Directions.TryParse(noun, out d);
                Direction = d;
            }
        }

        public Verbs Verb { get; set; }
        public Nouns Noun { get; set; }
        public Directions Direction { get; set; }


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
    }
}
