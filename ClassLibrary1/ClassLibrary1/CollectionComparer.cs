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
            if (collection1 == null && collection2 != null || collection2 == null && collection1 != null) return false;
           
            if (collection1 == null && collection2 == null) return true;

            var res = collection1.Count() == collection2.Count();
            if (!res)
                return false;

            var array1 = collection1.ToArray();
            var list2 = collection2.ToList();
            for (int i = 0; i < array1.Length; i++)
            {
                var index = list2.IndexOf(array1[i]);
                if (index > -1)
                {
                    list2.RemoveAt(index);
                    continue;
                }
                else
                    return false;
            }

            return list2.Count == 0;
        }
    }
}
