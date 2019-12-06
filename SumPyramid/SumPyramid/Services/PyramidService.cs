using SumPyramid.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumPyramid
{
   public class PyramidService
    {
        const string InvalidInputMsg = "Invalid input!";
        public void Show()
        {


            Console.WriteLine("1. Sample Input --------------------------------------------------------------------------");
            Dictionary<int, int[]> piramid = Mocks.GetSimpleInputMock();
            WritePiramid(piramid);
            MyDictionary theWay = new MyDictionary();
            try
            {
                getPosibleWays(ref piramid, null, ref theWay);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            WriteResult(theWay);


            Console.WriteLine("2. Question ------------------------------------------------------------------------------");
            piramid = Mocks.GetTheInputMock();
            WritePiramid(piramid);
            theWay = new MyDictionary();
            try
            {
                getPosibleWays(ref piramid, null, ref theWay);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            WriteResult(theWay);

            Console.WriteLine("3. No way -------------------------------------------------------------------------------");
            piramid = Mocks.GetNoWayInputMock();
            WritePiramid(piramid);
            theWay = new MyDictionary();
            try
            {
                getPosibleWays(ref piramid, null, ref theWay);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            WriteResult(theWay);

            Console.WriteLine("4. Wrong input -------------------------------------------------------------------------");
            piramid = Mocks.GetWrongInputMock();
            WritePiramid(piramid);
            theWay = new MyDictionary();
            try
            {
                getPosibleWays(ref piramid, null, ref theWay);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            WriteResult(theWay);

            Console.WriteLine("5. Wrong input version second ---------------------------------------------------------");
            piramid = Mocks.GetWrong2InputMock();
            WritePiramid(piramid);
            theWay = new MyDictionary();
            try
            {
                getPosibleWays(ref piramid, null, ref theWay);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            WriteResult(theWay);

            Console.ReadKey();
        }

        public  void getPosibleWays(ref Dictionary<int, int[]> piramid, MyDictionary currentWay, ref MyDictionary theWay)
        {

            if (currentWay == null)
            {
                if (piramid.First(x => x.Key == 0).Value.Length != 1) throw new ArgumentException(InvalidInputMsg);
                int value = piramid.First(x => x.Key == 0).Value[0];
                currentWay = new MyDictionary();
                currentWay.Add(0, new FieldModel() { Value = value, Even = (value % 2 == 0), IndexInLvl = 0, Lvl = 0 });
                getPosibleWays(ref piramid, currentWay, ref theWay);
                return;
            }


            FieldModel lastStep = currentWay.Last().Value;
            int nextLvlIndex = lastStep.Lvl + 1;

            if (!piramid.Any(x => x.Key == nextLvlIndex)) throw new ArgumentException(InvalidInputMsg);

            int[] nextLvl = piramid[nextLvlIndex];

            if (nextLvl.Length != piramid[lastStep.Lvl].Length + 1) throw new ArgumentException(InvalidInputMsg);

            //Left
            NextStep(ref piramid, currentWay, ref theWay, lastStep.IndexInLvl, lastStep, nextLvlIndex, nextLvl);

            //Right
            NextStep(ref piramid, currentWay, ref theWay, lastStep.IndexInLvl + 1, lastStep, nextLvlIndex, nextLvl);


        }

        private void NextStep(ref Dictionary<int, int[]> piramid, MyDictionary currentWay, ref MyDictionary theWay, int valueIndex, FieldModel lastStep,  int nextLvlIndex, int[] nextLvl)
        {
            int value = nextLvl[valueIndex];
            bool valueEven = value % 2 == 0;
            if (valueEven != lastStep.Even)
            {
                MyDictionary way = new MyDictionary(currentWay);
                way.Add(nextLvlIndex, new FieldModel() { Value = value, Even = valueEven, IndexInLvl = valueIndex, Lvl = nextLvlIndex });

                if (way.Count >= piramid.Count)
                {
                    if (way.Sum(x => x.Value.Value) > theWay.Sum(x => x.Value.Value))
                    {
                        theWay = new MyDictionary(way); ;
                    }

                }
                else
                {
                    getPosibleWays(ref piramid, way, ref theWay);
                }

            }

        }


        private void WritePiramid(Dictionary<int, int[]> piramid)
        {
            Console.WriteLine("Input:");
            foreach (var item in piramid)
            {
                string line = "";
                foreach (var field in item.Value)
                {
                    line += $"{(line == "" ? "" : ", ")}{field}";
                }
                Console.WriteLine(line);
            }
            Console.WriteLine("");
        }

        static void WriteResult(MyDictionary theWay)
        {
            Console.WriteLine($"Max sum: {theWay.GetSum()}");
            Console.WriteLine($"Path: {theWay.GetPath()}");
            Console.WriteLine("");
        }



    }
}
