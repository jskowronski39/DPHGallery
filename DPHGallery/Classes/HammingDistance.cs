using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DPHGallery.Classes
{
	public class HammingDistance
	{
		/// <summary>
		/// Calculates Hamming distance between two bytes.
		/// </summary>
		/// <param name="x">First byte</param>
		/// <param name="y">Second byte</param>
		/// <returns>Hamming distance</returns>
		public static int Calculate(byte x, byte y)
		{
			int bitwiseDiff = x ^ y;

			return SparseBitcount(bitwiseDiff);
		}

		/// <summary>
		/// Counts set bytes.
		/// </summary>
		/// <param name="n">Bits to count</param>
		/// <returns>Number of set bits</returns>
		static int SparseBitcount(int n)
		{
			int count = 0;
			while (n != 0)
			{
				count++;
				n &= (n - 1);
			}
			return count;
		}
	}
}