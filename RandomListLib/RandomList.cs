using System;
using System.Collections.Generic;

namespace RandomListLib
{
	/// <summary>
	/// Picks random item from a list, but never the same item twice in a row.
	/// Each item is guaranteed to appear with maximum interval equal to the length of list.
	/// 
	/// One common usage of this algorithm is playback of speech in games.
	/// It makes the game seem less repeating.
	/// </summary>
	public class RandomList<T>
	{
		// These are the items we pick from.
		private T[] m_array = null;
		// Contains marks of which items that should not be picked.
		private bool[] m_marks = null;
		// Counts the number of items left that can be picked.
		private int m_markCount = 0;
		// A random generator.
		private Random m_rnd;

		public RandomList(Random rnd, T[] array)
		{
			m_rnd = rnd;
			m_array = array;

			m_marks = new bool[array.Length];
			m_markCount = m_marks.Length;
		}

		public T RandomItem()
		{
			int listCount = m_array.Length;
			int index = 0;
			if (m_markCount <= 1) {
				// Invert the marks.
				for (int i = 0; i < listCount; i++) {
					m_marks[i] = !m_marks[i];
					if (m_marks[i]) index = i;
				}
				m_markCount = listCount-1;
				return m_array[index];
			} else {
				// Pick a random item.
				int rnd = m_rnd.Next(m_markCount);
				for (int i = 0; i < listCount; i++) {
					if (m_marks[i]) continue;
					if (rnd == 0) {
						index = i;
						break;
					}
					rnd--;
				}
				m_marks[index] = true;
				m_markCount--;
				return m_array[index];
			}
		}
	}
}

