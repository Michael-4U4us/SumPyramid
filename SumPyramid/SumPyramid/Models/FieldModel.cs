using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumPyramid
{
    public struct FieldModel
    {
        public int Lvl { get; set; }
        public bool Even { get; set; }
        public int IndexInLvl { get; set; }
        public int Value { get; set; }
    }
}
