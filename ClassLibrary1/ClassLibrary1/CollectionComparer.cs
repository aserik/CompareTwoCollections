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
        public static bool Compare <T> (IEnumerable<T> collection1, IEnumerable<T> collection2 )    // INumarable interface is needed when we have to use foreach operator
        {
            if (collection1 == null && collection2 != null || collection2 == null && collection1 != null) return false;     // verify for 1 null collection from 2
           
            if (collection1 == null && collection2 == null) return true;    // verify for 2 null collections

            var res = collection1.Count() == collection2.Count();  // check that collections has the same count of elements
            

            if (!res)
                return false;
                Console.WriteLine("The lenght of colections are different!");
                   
           

            var array1 = collection1.ToArray();         // declare 1 collection as array
            var list2 = collection2.ToList();           // declare 2 collection as list   
            for (int i = 0; i < array1.Length; i++)     // create cycle 
            {


                // Trace.Write(string.Format(" item: ", array1[i]));
                // Trace.Write( "{0}");

                var index = list2.IndexOf(array1[i]);   // declare index with condition to sort items in both collections

                if (index > -1)                         // check for index with existed item
                {
                    list2.RemoveAt(index);              // remove item with existed index from list2 
                    continue;

                }
                else
                    return false;
            }
            return list2.Count == 0;
        }
    }
}
