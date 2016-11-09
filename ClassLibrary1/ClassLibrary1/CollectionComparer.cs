using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public static class CollectionComparer
    {
        public static bool Compare(IEnumerable<int> collection1, IEnumerable<int> collection2 )
        {
            var res = collection1.Count() == collection2.Count();
            if (!res)
                return false;

            var array1 = collection1.ToArray();
            var list2 = collection2.ToList();
            for (int i = 0; i < array1.Length; i++)
            {
                if (!array1[i].Equals(list2.IndexOf(i)))
                    //list2.IndexOf(i).
                    return false;
            }
            return true;
        }
    }
}
