using System.Collections.Generic;
using System.Dynamic;
using System.Xml.Serialization;

namespace objectModel
{
    public class Door : IDescribable
    {
        [XmlElement("WorkingKeys")]
        public List<Key> WorkingKeys { get; set; }
        [XmlElement("LongDescription")]
        public string LongDescription { get; set; }
        [XmlElement("ShortDescription")]
        public string ShortDescription { get; set; }

        public bool Unlock(object player)
            //IPlayer should be supplied by Unity
            //Door examines the player (and his inventory) to see if it will unlock
        {
            return true;
        }
    }
}