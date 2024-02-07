using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Triangle_Decoder
{
    class Program
    { 
        static string DecodeInternal(Dictionary<int, string> triangleComponents)
        {
            string result = "";
            int lastIndex = 0;
            int delayedLastIndex = lastIndex;
            int rightIndex = 1;

            while (rightIndex < triangleComponents.Count)
            {
                result += $"{triangleComponents[rightIndex]} ";

                delayedLastIndex = rightIndex;
                rightIndex += (rightIndex + 1) - lastIndex;
                lastIndex = delayedLastIndex;
            }

            return result;
        }

        static string Decode(string path)
        {
            string line;
            Dictionary<int, string> lines = new Dictionary<int, string>();

            try
            {
                StreamReader sr = new StreamReader(path);
                for (int i = 0; i < File.ReadAllLines(path).Length; i++)
                {
                    line = sr.ReadLine();
                    string[] res = line.Split(' ');

                    int key = Convert.ToInt32(res[0]);
                    string value = res[1];

                    lines.Add(key, value);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }

            return DecodeInternal(lines);
        }

        static void Main(string[] args)
        {
            string path = @"C:\Users\user\Desktop\ExampleTextDocument.txt";
            string decodedText = Decode(path);

            Console.WriteLine(decodedText);
        }
    }
}
