using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace text_adventure_engine
{
    class Program
    {
        static void Main(string[] args)
        {
            Parser parser = new text_adventure_engine.Parser();

            StreamReader file = new StreamReader("/commands.txt");
            string[] currentLine;
            while (!file.EndOfStream)
            {
                currentLine = file.ReadLine().Split(',');
                parser.AddCommand(currentLine[0],  currentLine[1]);
            }


            // read csv file of commands into a list of Commands
            // parser.AddCommand(command)

            
            
        }
    }
}
