using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Robs.LinqExtensions
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<T> WhereIf<T>(this IEnumerable<T> list, Func<bool> condition, Func<T, bool> predicate)
        {
            var listReturn = new List<T>();
            foreach (var item in list)
            {
                if(condition())
                {
                    if(predicate(item))
                        listReturn.Add(item);
                }
            }

            return listReturn;
        }

        public static IEnumerable<T> Alternate<T>(this IEnumerable<T> list, IEnumerable<T> listAlt)
        {
            using (IEnumerator<T> e1 = list.GetEnumerator())
            using (IEnumerator<T> e2 = listAlt.GetEnumerator())
                while (e1.MoveNext() && e2.MoveNext())
                {
                    yield return e1.Current;
                    yield return e2.Current;
                }

        }

        //public static IEnumerable<T> Alternate<T> (this IEnumerable<T> list, IEnumerable<T> listAlt)
        //{
        //    var listReturn = new List<T>();
        //    var list1 = list.ToList();
        //    var list2 = listAlt.ToList();
        //    if(list1.Count > list2.Count) throw new Exception("Lists are of unequal Lengths");

        //    for (int i = 0; i < list1.Count; i++)
        //    {
        //        listReturn.Add(list1[i]);
        //        listReturn.Add(list2[i]);
        //    }
        //    return listReturn.AsEnumerable();
        //}
    }
}
