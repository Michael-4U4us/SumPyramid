using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumPyramid.Models
{
    public class MyDictionary: Dictionary<int, FieldModel>
    {
        public MyDictionary() : base()
        {

        }
        public MyDictionary(MyDictionary keyValuePairs):base(keyValuePairs)
        {
            
        }
        public int GetSum()
        {
           return this.Sum(x => x.Value.Value);
        }

        public string GetPath()
        {
            string way = "";
            foreach (var item in this)
            {
                way += $"{(way == "" ? "" : ", ")}{item.Value.Value}";
            }
            return way;
        }
    }
}
