using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDNF6R_Homework
{
    public class FileParser
    {
        public Work Parse(string[] columns)
        {
            string name = columns[0];
            int requiredTime = int.Parse(columns[1]);
            int materialCosts = int.Parse(columns[2]);

            return new Work(name, requiredTime, materialCosts);
        }
    }
}

