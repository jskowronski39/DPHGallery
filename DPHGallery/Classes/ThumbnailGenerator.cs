using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace DPHGallery.Classes
{
	public class ThumbnailGenerator
	{
		const int DefaultThumbnailHeight = 200;

		/// <summary>
		/// Creates thumbnails from given image.
		/// </summary>
		/// <param name="img">Image from which thumbnail should be created</param>
		/// <param name="maxHeight">Max image width</param>
		/// <returns>Image thumbnail</returns>
		public static Image CreateThumbnail(Image img, int maxHeight = ThumbnailGenerator.DefaultThumbnailHeight)
		{
			// TODO: This method currently does not work with vertical images.
			int width = (int)(maxHeight * ((decimal)img.Width / (decimal)img.Height));

			return img.GetThumbnailImage(width, maxHeight, () => false, IntPtr.Zero);
		}
	}
}