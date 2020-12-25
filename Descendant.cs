using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public class Descendant: IComparable
    {
        public double X;
        
        //Это решение фукнции, для дальнейшей оценкии популяции
        public double Y;

        public int Compare(Descendant x, Descendant y)
        {
            var delta = x.Y - y.Y;
            if (delta > 0)
                return 1;
            if (delta < 0)
                return -1;
            return 0;
        }

        public int CompareTo(object obj)
        {
            var y = obj as Descendant;
            var delta = Y - y.Y;
            if (delta > 0)
                return 1;
            if (delta < 0)
                return -1;
            return 0;
        }
    }
}
