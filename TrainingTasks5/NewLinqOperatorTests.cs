using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Robs.LinqExtensions;

namespace TrainingTasks5
{
    [TestFixture]
    public class NewLinqOperatorTests
    {
        // Implement WhereIf linq operator which takes a boolean condition and a predicate and only evaluates the predicate if the condition is true.
        // eg. list.WhereIf(true, x=>x.IsActive);

        // Implement Alternate which when given an additional list will return the 1 element from the first list then 1 from the second and so on.
        // eg. list.Alternate(list2);

        [Test]
        public void WhereIfLinqTakesBooleanPredicateAndOnlyEvaluatesThePredicateIfTheConditionIsTrue()
        {
            var list = Data.GetProducts().Select(x => new {Product = x, IsActive = (x.UnitPrice>10 ? true : false) });
            list.WhereIf(true, x=>x.IsActive);
        }

        [Test]
        public void PassAlternateListToListAndReturnNewListWithAlternatingValuesFromEachList()
        {
            var list1 = Data.GetProducts().Where(x => x.ProductID <= 5);
            var list2 = Data.GetProducts().Where(x => x.ProductID >= 6).Take(5);

            var listExpected = new List<Product>();
            for (int i = 1; i <= 5; i++)
            {
                listExpected.Add(Data.GetProducts().Single(x => x.ProductID==i));
                listExpected.Add(Data.GetProducts().Single(x => x.ProductID==i+5));
            }

            var listActual = list1.Alternate(list2).ToList();
            for (int i = 0; i < listExpected.Count; i++)
            {
                Assert.AreEqual(listExpected[i].Category, listActual[i].Category);
                Assert.AreEqual(listExpected[i].ProductID, listActual[i].ProductID);
                Assert.AreEqual(listExpected[i].UnitPrice, listActual[i].UnitPrice);
                Assert.AreEqual(listExpected[i].ProductName, listActual[i].ProductName);
                Assert.AreEqual(listExpected[i].UnitsInStock, listActual[i].UnitsInStock);
            }

        }
    }
}