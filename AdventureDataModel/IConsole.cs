using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AdventureDataModel
{
    public interface IConsole
    {
        string ReadLine();
        void Write(string value);
        void WriteLine(string value);
        void WriteLine();
    }
}
