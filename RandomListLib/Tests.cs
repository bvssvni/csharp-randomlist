using System;
using NUnit.Framework;

namespace RandomListLib
{
	[TestFixture()]
	public class Tests
	{
		[Test()]
		public void TestCase()
		{
			var list = new RandomList<int>(new Random(239823), new int[]{0,1,2,3,4,5});

			long start = DateTime.Now.ToFileTimeUtc();
			int end = 1 << 6; // 24;
			int last = -1;
			for (int i = 0; i < end; i++) {
				int item = list.RandomItem();
				// Console.Write(item.ToString());
				Assert.True(item != last);
				last = item;
			}
			double seconds = (DateTime.Now.ToFileTimeUtc() - start) / 10000000.0;
			// Console.WriteLine("");
			Console.WriteLine(seconds);

			// Assert.False(true);
		}
	}
}

