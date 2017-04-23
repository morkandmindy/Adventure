using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AdventureDataModel;

    using System.Diagnostics;
    using System.Runtime.InteropServices;

namespace Adventure
{
class WordWrapConsole : IConsole
    {
        public WordWrapConsole()
        {
            Maximize();
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Clear();
            Console.CursorVisible = true;   //why can't I see the cursor then?! WHY? WHYY??!!
            
        }

    [DllImport("user32.dll")]
    public static extern bool ShowWindow(System.IntPtr hWnd, int cmdShow);

    private static void Maximize()
    {
        Process p = Process.GetCurrentProcess();
        ShowWindow(p.MainWindowHandle, 3); //SW_MAXIMIZE = 3
    }
    
        public string ReadLine()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("> ");
            var retVal = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            return retVal;
        }

        public void Write(string value)
        {
            Console.Write(value);
        }

        public void WriteLine(string value)
        {
            WriteLineWordWrap(value);
        }

        public void WriteLine()
        {
            Console.WriteLine();
        }

        private void WriteLineWordWrap(string paragraph, int tabSize = 8)
        {
            string[] lines = paragraph
                .Replace("\t", new String(' ', tabSize))
                .Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

            for (int i = 0; i < lines.Length; i++)
            {
                string process = lines[i];
                List<String> wrapped = new List<string>();

                while (process.Length > Console.WindowWidth)
                {
                    int wrapAt = process.LastIndexOf(' ', Math.Min(Console.WindowWidth - 1, process.Length));
                    if (wrapAt <= 0) break;

                    wrapped.Add(process.Substring(0, wrapAt));
                    process = process.Remove(0, wrapAt + 1);
                }

                foreach (string wrap in wrapped)
                {
                    Console.WriteLine(wrap);
                }

                Console.WriteLine(process);
            }
        }
    }
}
