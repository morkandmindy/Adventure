using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace objectModel
{
    [XmlRoot("Game"), Serializable]
    public class Game
    {
        [XmlElement("Rooms")]
        public Rooms Rooms { get; set; }
    }
}
