using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD_Day1_Homework
{
    public class GetSum
    {
        public int[] GetSumCost(IEnumerable<TestItem> source, int n)
        {
            var group = source.Select((x, i) => new { Index = i, Value = x }).GroupBy(x => x.Index / n);
            var result = group.Select(t => t.Select(x => x.Value).Sum(y => y.Cost)).ToArray();
            return result;
        }

        public int[] GetSumRevenue(IEnumerable<TestItem> source, int n)
        {
            var group = source.Select((x, i) => new { Index = i, Value = x }).GroupBy(x => x.Index / n);
            var result = group.Select(t => t.Select(x => x.Value).Sum(y => y.Revenue)).ToArray();
            return result;
        }

        public int[] GetSumByPropertyName<T>(IEnumerable<T> source, int n, string name)
        {
            System.Reflection.PropertyInfo prop = typeof(T).GetProperty(name);
            var group = source.Select((x, i) => new { Index = i, Value = x }).GroupBy(x => x.Index / n);
            var result = group.Select(t => t.Select(x => x.Value).Sum(y => (int)prop.GetValue(y))).ToArray();
            return result;
        }

        public int[][] GetSumAllProperty<T>(IEnumerable<T> source, int n)
        {
            System.Reflection.PropertyInfo[] props = typeof(T).GetProperties();
            var group = source.Select((x, i) => new { Index = i, Value = x }).GroupBy(x => x.Index / n);
            List<int[]> li = new List<int[]>();
            foreach (var p in props)
            {
                var subtotal = group.Select(t => t.Select(x => x.Value).Sum(y => (int)p.GetValue(y))).ToArray();
                li.Add(subtotal);
            }
            var result = li.ToArray();
            return result;
        }

    }

    public class TestItem
    {
        public int ID { get; set; }

        public int Cost { get; set; }

        public int Revenue { get; set; }

        public int SellPrice { get; set; }
    }
}
