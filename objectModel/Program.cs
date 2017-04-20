using System.Collections.Generic;

namespace objectModel
{
    internal class Program
    {
        private void Main(string[] args)
        {
            var r = new Room();
            r.Id = 1;
            r.Passages = new List<Passage>();
            r.Passages.Add(new Passage
            {
                Direction = Directions.North,
                LongDescription = "An Oaken Door",
                Destination = r.Id
            });


            //suppose player said "OPEN DOOR"
            //first, recognizing KNOWNVERB-KNOWNOBJECT form,
            //second, checking for the object in Player.Room and Player.Inventory combined,
            //        if not found, give message
            //third, send the verb to the object, passing it player via Unity and receiving String ExplanitoryText for caller to display in console 
            foreach (var passage in r.Passages)
            {
                if (passage.Door != null)
                {
                    //try unlock
                    var keyFoundInPlayerInventory = new Key();
                    passage.Door.Unlock();
                    //unlock will explain what happened and adjust its properties
                }
            }
        }
    }

    internal enum Directions
    {
        North,
        South,
        East,
        West,
        Up,
        Down,
        NorthEast,
        NorthWest,
        SouthEast,
        SouthWest
    }

    internal class Key : IDescribable
    {
        public string LongDescription { get; set; }
        public string ShortDescription { get; set; }
    }

    internal class Door : IDescribable
    {
        public bool IsLocked { get; set; }
        public List<Key> WorkingKeys { get; set; }
        public string LongDescription { get; set; }
        public string ShortDescription { get; set; }

        public bool Unlock(object player)
            //IPlayer should be supplied by Unity
            //Door examines the player (and his inventory) to see if it will unlock
        {
            return true;
        }
    }

    internal class Passage : IDescribable
    {
        public Directions Direction { get; set; }
        public int Destination { get; set; }
        public Door Door { get; set; }
        public string LongDescription { get; set; }
        public string ShortDescription { get; set; }
    }

    internal interface IDescribable
    {
        string LongDescription { get; set; }
        string ShortDescription { get; set; }
    }


    internal class Room : IDescribable
    {
        public List<Passage> Passages { get; set; }
        //public List<IGameObject> Objects { get; set; }
        public int Id { get; set; }
        public string LongDescription { get; set; }
        public string ShortDescription { get; set; }
    }
}