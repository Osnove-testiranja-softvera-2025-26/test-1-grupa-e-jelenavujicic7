using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS2026_GrupaE.Test
{
    internal class TestDataFromFile
    {
        public static IEnumerable Get_ValidatePosition_OKInput_SuccesfulValidation_Test(string filename)
        {
            string path = $@"{AppDomain.CurrentDomain.BaseDirectory}\{filename}";
            string[] lines=File.ReadAllLines(path);

            List<TestDataCase> cases = new List<TestDataCase>();
            
            foreach(string line in lines)
            {
                string[] values=line.Split(null);
                int x=Int32.Parse(values[0]);
                int y = Int32.Parse(values[1]);
                int z = Int32.Parse(values[2]);
                string TypeField = values[3];
                bool planCrop = values[4] == "yes";
                bool position = values[5] == "yes"; 
                cases.Add(new TestDataCase(x,y, z, position));

            }
            return TestDataCase;
        }
        public static IEnumerable Get_ValidatePosition_OKInput_SuccesfulValidation_Test(string filename)
        {
            string path = $@"{AppDomain.CurrentDomain.BaseDirectory}\{filename}";
            string[] lines = File.ReadAllLines(path);

            List<TestDataCase> cases = new List<TestDataCase>();

            foreach (string line in lines)
            {
                string[] values = line.Split(null);
                int plantCrop = Int32.Parse(values[0]);
                int seed = Int32.Parse(values[1]);
                bool plant = values[2] == "yes";
                Income? expected = GetIncomeFromString(values[3]);
                cases.Add(new TestCaseData(plantCrop, seed, plant, expected));
            }
            return cases;
        }
        private static Income? GetIncomeFromString(string income)
        {
            if (income.ToLower().Equals("average"))
                return Income.Average;
            if (income.ToLower().Equals("good"))
                return Income.Good;
            if (income.ToLower().Equals("bad"))
                return Income.Bad;
            return null;
        }
    }
}
