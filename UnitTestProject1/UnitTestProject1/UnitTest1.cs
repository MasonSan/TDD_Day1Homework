using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        private List<Product> _testItem = new List<Product>();

        public UnitTest1()
        {
            //Initialize data
            _testItem.Add(new Product { Id = 1, Cost = 1, Revenue = 11, SellPrice = 21 });
            _testItem.Add(new Product { Id = 2, Cost = 2, Revenue = 12, SellPrice = 22 });
            _testItem.Add(new Product { Id = 3, Cost = 3, Revenue = 13, SellPrice = 23 });
            _testItem.Add(new Product { Id = 4, Cost = 4, Revenue = 14, SellPrice = 24 });
            _testItem.Add(new Product { Id = 5, Cost = 5, Revenue = 15, SellPrice = 25 });
            _testItem.Add(new Product { Id = 6, Cost = 6, Revenue = 16, SellPrice = 26 });
            _testItem.Add(new Product { Id = 7, Cost = 7, Revenue = 17, SellPrice = 27 });
            _testItem.Add(new Product { Id = 8, Cost = 8, Revenue = 18, SellPrice = 28 });
            _testItem.Add(new Product { Id = 9, Cost = 9, Revenue = 19, SellPrice = 29 });
            _testItem.Add(new Product { Id = 10, Cost = 10, Revenue = 20, SellPrice = 30 });
            _testItem.Add(new Product { Id = 11, Cost = 11, Revenue = 21, SellPrice = 31 });
        }

        [TestMethod]
        public void testItem_三筆一組拿Cost總和_6_15_24_21()
        {
            
            List<int> expected = new List<int> { 6, 15, 24, 21 };

            List<int> actual = _testItem.GroupSum(x => x.Cost, 3).ToList();

            CollectionAssert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void testItem_四筆一組取Revenue總和_50_66_60()
        {
            List<int> expected = new List<int> { 50, 66, 60 };

            List<int> actual = _testItem.GroupSum(x => x.Revenue, 4).ToList();

            CollectionAssert.AreEqual(expected, actual);
        }

    }

    internal class Product
    {
        public int Id { get; set; }
        public int Cost { get; set; }
        public int Revenue { get; set; }
        public int SellPrice { get; set; }
    }

    internal static class ListExtension
    {

        public static IEnumerable<int> GroupSum<T>(this List<T> source, Func<T, int> selector, int groupSize)
        {
            var sum = 0;

            for (int index = 0; index < source.Count; index++)
            {
                T item = source.ElementAt(index);

                sum += selector(item);
                if ((index + 1) % groupSize == 0 || index == source.Count - 1)
                {
                    yield return sum;
                    sum = 0;
                }
            }
        }
    }
}
