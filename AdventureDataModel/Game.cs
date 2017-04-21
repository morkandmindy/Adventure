using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Adventure
{
    [XmlRoot("Game"), Serializable]
    public class Game
    { 
        [XmlArray(ElementName = "Rooms")]
        [XmlArrayItem(ElementName = "Room")]
        public List<Room> Rooms { get; set; }
    }
}
