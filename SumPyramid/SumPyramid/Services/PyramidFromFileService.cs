using SumPyramid.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumPyramid
{
   public class PyramidFromFileService
    {
        const string InvalidInputMsg = "Invalid input!";
       
        public MyDictionary FindWayInFile(string path)
        {
            MyDictionary theWay = new MyDictionary();

            Dictionary<int, int[]> piramid = new Dictionary<int, int[]>();
            FieldModel lastValue = new FieldModel() { Lvl = -1 };
            IEnumerable<MyDictionary> ways = new List<MyDictionary>();
            foreach (var line in ReadDataFromFile(path))
            {
                if(lastValue.Lvl <0 )
                {
                    lastValue.Lvl = 0;
                    lastValue.Value = line.Value.First();
                    lastValue.IndexInLvl = 0;
                    lastValue.Even = lastValue.Value % 2 == 0;
                    theWay.Add(0, lastValue);
                    continue;
                }
                else
                {
                    lastValue = theWay.Last().Value;
                }

                foreach (var item in GetWays(lastValue, line.Value.ToArray(), new  MyDictionary(theWay)))
                {
                    if (theWay.GetSum() < item.GetSum())
                    {
                        theWay = new MyDictionary(item);
                    }
                }
                
            }
            return theWay;
        }

        
        private IEnumerable<MyDictionary> GetWays(FieldModel lastValue, int[] valuesInLine, MyDictionary currentWay)
        {
            bool stepAdded = false;

            MyDictionary currentWayLeft = addNextStep(ref stepAdded, lastValue, valuesInLine, new MyDictionary(currentWay), lastValue.IndexInLvl);

            if (stepAdded)
            {
                yield return currentWayLeft;
            }

            MyDictionary currentWayRight = addNextStep(ref stepAdded, lastValue, valuesInLine, new MyDictionary( currentWay), lastValue.IndexInLvl+1);

            if (stepAdded)
            {
                yield return currentWayRight;
            }

        }

        private MyDictionary addNextStep(ref bool stepAdded, FieldModel lastValue, int[] valuesInLine, MyDictionary currentWay, int IndexInLvl)
        {
            int nextLvlIndex = lastValue.Lvl + 1;
            if (nextLvlIndex >= valuesInLine.Length) return currentWay;
            int value = valuesInLine[IndexInLvl];
            bool valueEven = value % 2 == 0;
            if (valueEven != lastValue.Even)
            {
                currentWay.Add(nextLvlIndex, new FieldModel() { Value = value, Even = valueEven, IndexInLvl = IndexInLvl, Lvl = nextLvlIndex });
                stepAdded = true;
            }
            return currentWay;
        }

        private IEnumerable<KeyValuePair<int, IEnumerable<int>>> ReadDataFromFile(string path)
        {
            int lineIndex = 0;
            foreach (string line in File.ReadLines(path))
            {
                IEnumerable<int> numbers = null;
                try
                {
                         numbers = line.Trim().Split(' ').Select(Int32.Parse);
                    if (!numbers.Any() || numbers.Count() != lineIndex + 1) throw new Exception();
                }
                catch (Exception)
                {
                    throw new Exception($"Invalid data in the line number { lineIndex + 1 }");
                }
                
                if (numbers == null || numbers.Count() != lineIndex + 1) throw new Exception($"Invalid data in the line number { lineIndex + 1 }");

                yield return new KeyValuePair<int, IEnumerable<int>>(lineIndex, numbers);
                lineIndex++;
            }

        }

    }
}
