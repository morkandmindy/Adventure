using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Adventure
{
    public class Rooms
    {
        [XmlElement("Room")]
        public List<Room> Room { get; set; }
    }
}
