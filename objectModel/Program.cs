using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Xml.Serialization;


namespace Adventure
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Game));
            FileStream loadStream = new FileStream(@"..\..\sample.xml", FileMode.Open, FileAccess.Read);
            Game game = (Game)serializer.Deserialize(loadStream);
            loadStream.Close();
            
            foreach (var room in game.Rooms.Room)
            {
                Debug.WriteLine(room.LongDescription);
            }
            
            //    //suppose player said "OPEN DOOR"
            //    //first, recognizing KNOWNVERB-KNOWNOBJECT form,
            //    //second, checking for the object in Player.Room and Player.Inventory combined,
            //    //        if not found, give message
            //    //third, send the verb to the object, passing it player via Unity and receiving String ExplanitoryText for caller to display in console 
            //    foreach (var passage in r.Passages)
            //    {
            //        if (passage.Door != null)
            //        {
            //            //try unlock
            //            var keyFoundInPlayerInventory = new Key();
            //            passage.Door.Unlock();
            //            //unlock will explain what happened and adjust its properties
            //        }
            //    }
        }
    }
}
