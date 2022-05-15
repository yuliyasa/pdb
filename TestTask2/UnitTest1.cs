using NUnit.Framework;
using Sorting;

namespace TestTask2
{
    public class Tests
    {
        int[][] test_sum = {
                            new int[4]{1,2,3,4},
                            new int[4]{10,30,20,10},
                            new int[4]{1,100,3,2},
                            new int[4]{99,10,3,7}
                           };
        int[][] test_sum_rev = {
            new int[4]{99,10,3,7},
            new int[4]{1,100,3,2},
            new int[4]{10,30,20,10},
            new int[4]{1,2,3,4}                                       
                           };
        int[][] test_max = {
                            new int[4]{1,2,3,4},
                            new int[4]{10,30,20,10},
                            new int[4]{99,10,3,7},
                            new int[4]{1,100,3,2}
                            
                           };
        int[][] test_max_rev = {
                            new int[4]{1,100,3,2},
                            new int[4]{99,10,3,7},
                            new int[4]{10,30,20,10},
                            new int[4]{1,2,3,4}                               
                           };
        int[][] test_min = {
                             new int[4]{1,2,3,4},                 
                            new int[4]{1,100,3,2},
                            new int[4]{99,10,3,7},
                            new int[4]{10,30,20,10},
                           };
        int[][] test_min_rev = {

                            new int[4]{10,30,20,10},                        
                            new int[4]{99,10,3,7},
                            new int[4]{1,100,3,2},
                            new int[4]{1,2,3,4}
                           };
        public int[][] GetTestArray()
        {
            int[][] arr = {
                            new int[4]{1,2,3,4},
                            new int[4]{10,30,20,10},
                            new int[4]{1,100,3,2},
                            new int[4]{99,10,3,7}
                           };
            return arr;
        }

        [Test]
        public void TestSumSort()
        {
            int[][] arr = GetTestArray();
            Context context = new Context(new SumSorting().Sort);       
            context.Sort(ref arr, false);
            Assert.AreEqual(arr, test_sum);
        }
        [Test]
        public void TestSumSortRev()
        {
            int[][] arr = GetTestArray();
            Context context = new Context(new SumSorting().Sort);
            context.Sort(ref arr, true);
            Assert.AreEqual(arr, test_sum_rev);
        }

        [Test]
        public void TestMinSort()
        {
            int[][] arr = GetTestArray();
            Context context = new Context(new MinSorting().Sort);
            context.Sort(ref arr, false);
            Assert.AreEqual(arr, test_min);
        }

        [Test]
        public void TestMinSortRev()
        {
            int[][] arr = GetTestArray();
            Context context = new Context(new MinSorting().Sort);
            context.Sort(ref arr, true);
            Assert.AreEqual(arr, test_min_rev);
        }

        [Test]
        public void TestMaxSort()
        {
            int[][] arr = GetTestArray();
            Context context = new Context(new MaxSorting().Sort);
            context.Sort(ref arr, false);
            Assert.AreEqual(arr, test_max);
        }

        [Test]
        public void TestMaxSortRev()
        {
            int[][] arr = GetTestArray();
            Context context = new Context(new MaxSorting().Sort);
            context.Sort(ref arr, true);
            Assert.AreEqual(arr, test_max_rev);
        }
        [Test]
        public void TestAlreadySorted()
        {
            foreach (SortDelegate myDelegate in new SortDelegate[3] 
            { new SumSorting().Sort,
              new MinSorting().Sort,
              new MaxSorting().Sort})
            {
                int[][] arr = {
                            new int[1]{-1},
                            new int[1]{0},
                            new int[1]{2}
                           };
                int[][] true_arr = {
                            new int[1]{-1},
                            new int[1]{0},
                            new int[1]{2}
                           };
                Context context = new Context(new MinSorting().Sort);
                context.Sort(ref arr, false);
                Assert.AreEqual(arr, true_arr);
            }
        }
            [Test]
            public void TestAlreadySortedRev()
            {
                foreach (SortDelegate myDelegate in new SortDelegate[3]
                { new SumSorting().Sort,
                  new MinSorting().Sort,
                  new MaxSorting().Sort})
                {
                    int[][] arr = {
                            new int[1]{-1},
                            new int[1]{0},
                            new int[1]{2}
                           };
                    int[][] true_arr = {
                            new int[1]{2},
                            new int[1]{0},
                            new int[1]{-1}
                           };
                    Context context = new Context(new MinSorting().Sort);
                    context.Sort(ref arr, true);
                    Assert.AreEqual(arr, true_arr);
                }
            }
    }
}