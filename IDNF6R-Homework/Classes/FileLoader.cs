using System.Collections.Generic;
using System.Linq;
using System;
using System.IO;

namespace IDNF6R_Homework
{
    public class FileLoader
    {
        public List<Work> LoadFile(string filePath)
        {
            List<Work> works = new List<Work>();

            // Read all lines from the file
            string[] lines = File.ReadAllLines(filePath);

            // Skip the header line
            for (int i = 1; i < lines.Length; i++)
            {
                string[] columns = lines[i].Split(';');

                FileParser fileParser = new FileParser();

                // Create a new Work instance using the parser
                Work work = fileParser.Parse(columns);

                // Add the Work instance to the list
                works.Add(work);
            }

            return works;
        }
    }
}