using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace DPHGallery.Classes
{
	public class DummyPerceptualHash
	{
		Image img;

		/// <summary>
		/// Calculates DPH hash from given image.
		/// </summary>
		/// <param name="img">Image</param>
		public DummyPerceptualHash(Image img)
		{
			this.img = img;
		}

		/// <summary>
		/// Returns 8-bit image hash as byte.
		/// </summary>
		/// <returns>DPH hash</returns>
		public byte Calculate()
		{
			var r = new Random();
			int hash = r.Next(255);

			return (byte)hash;
		}
	}
}