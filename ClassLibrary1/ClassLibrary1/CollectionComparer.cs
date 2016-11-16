using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ClassLibrary1
{
    public static class CollectionComparer
    {
        public static bool Compare<T>(IEnumerable<T> collection1, IEnumerable<T> collection2)    // INumarable interface is needed when we have to use foreach operator
        {
            if (collection1 == null && collection2 != null)
            {
                Console.WriteLine("Collection2 items: {0}", string.Join(", ", collection2));     // verify for collection1 = null from 2
                return false;
            }

            if (collection2 == null && collection1 != null)
            {
                Console.WriteLine("Collection2 items: {0}", string.Join(", ", collection1));     // verify for collection2 = null from 2
                return false;
            }

            if (collection1 == null && collection2 == null)
            {
                Console.WriteLine("Two collections with null");
                return true;    // verify for 2 null collections
            }

            Console.WriteLine("Two collections are presented:");
            Console.WriteLine("Collection1 items: {0}", string.Join(", ", collection1));
            Console.WriteLine("Collection2 items: {0}", string.Join(", ", collection2));

            var array1 = collection1.ToArray();               // declare 1 collection as array
            var listFounded = collection2.ToList();           // declare 2 collection as list 
            var listNotFounded = new List<T>();

            for (int i = 0; i < array1.Length; i++)           // create cycle 
            {
                var index = listFounded.IndexOf(array1[i]);   // declare index with condition to sort items in both collections
                if (index > -1)                               // check for index with existed item
                    listFounded.RemoveAt(index);              // remove item with existed index from list2 
                else
                    listNotFounded.Add(array1[i]);
            }

            if (listNotFounded.Count() != 0)
                Console.WriteLine("Founded items from collection1 not existed in collection2: {0}", string.Join(", ", listNotFounded));

            if (listFounded.Count() != 0)
                Console.WriteLine("Founded items from collection2 not existed in collection1: {0}", string.Join(", ", listFounded));

            return listNotFounded.Count() == 0 && listFounded.Count() == 0;
        }
    }
}
