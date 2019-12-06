using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumPyramid
{
    public class Mocks
    {
        public static Dictionary<int,int[]> GetSimpleInputMock()
        {
            Dictionary<int, int[]> list = new Dictionary<int, int[]>();
            list.Add(0,new int[]{   1   });
            list.Add(1,new int[]{  8,9  });
            list.Add(2,new int[]{ 1,5,9 });
            list.Add(3,new int[]{4,5,2,3});
            return list;
        }

        public static Dictionary<int, int[]> GetTheInputMock()
        {
            Dictionary<int, int[]> list = new Dictionary<int, int[]>();
            
            list.Add(0, new int[] { 215                                                                       });
            list.Add(1, new int[] { 192, 124                                                                  });
            list.Add(2, new int[] { 117, 269, 442                                                             });
            list.Add(3, new int[] { 218, 836, 347, 235                                                        });
            list.Add(4, new int[] { 320, 805, 522, 417, 345                                                   });
            list.Add(5, new int[] { 229, 601, 728, 835, 133, 124                                              });
            list.Add(6, new int[] { 248, 202, 277, 433, 207, 263, 257                                         });
            list.Add(7, new int[] { 359, 464, 504, 528, 516, 716, 871, 182                                    });
            list.Add(8, new int[] { 461, 441, 426, 656, 863, 560, 380, 171, 923                               });
            list.Add(9, new int[] { 381, 348, 573, 533, 448, 632, 387, 176, 975, 449                          });
            list.Add(10, new int[] { 223, 711, 445, 645, 245, 543, 931, 532, 937, 541, 444                     });
            list.Add(11, new int[] { 330, 131, 333, 928, 376, 733, 017, 778, 839, 168, 197, 197                });
            list.Add(12, new int[] { 131, 171, 522, 137, 217, 224, 291, 413, 528, 520, 227, 229, 928           });
            list.Add(13, new int[] { 223, 626, 034, 683, 839, 052, 627, 310, 713, 999, 629, 817, 410, 121      });
            list.Add(14, new int[] { 924, 622, 911, 233, 325, 139, 721, 218, 253, 223, 107, 233, 230, 124, 233 });
            return list;
        }

        public static Dictionary<int, int[]> GetNoWayInputMock()
        {
            Dictionary<int, int[]> list = new Dictionary<int, int[]>();
            list.Add(0, new int[] { 1 });
            list.Add(1, new int[] { 1, 1 });
            list.Add(2, new int[] { 1, 1, 1 });
            list.Add(3, new int[] { 1, 1, 1, 1 });
            return list;

        }

        public static Dictionary<int, int[]> GetWrongInputMock()
        {
            Dictionary<int, int[]> list = new Dictionary<int, int[]>();
            list.Add(0, new int[] { 1 });
            list.Add(2, new int[] { 1, 5, 9 });
            list.Add(3, new int[] { 4, 5, 2, 3 });
            return list;
        }
        public static Dictionary<int, int[]> GetWrong2InputMock()
        {
            Dictionary<int, int[]> list = new Dictionary<int, int[]>();
            list.Add(0, new int[] { 1 });
            list.Add(1, new int[] { 1, 5, 9 });
            list.Add(2, new int[] { 4, 5, 2, 3 });
            return list;
        }

    }
}
