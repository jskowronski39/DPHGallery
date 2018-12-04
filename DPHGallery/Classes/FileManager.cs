using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;

namespace DPHGallery.Classes
{
	public class FileManager
	{
		private string uploadDir;
		private string baseSavePath;
		private string pathGuid;

		/// <summary>
		/// Manages image store and read operations.
		/// </summary>
		/// <param name="uploadDir">Relative storegr path</param>
		public FileManager(string uploadDir = "~/Uploads")
		{
			this.uploadDir = uploadDir;
			this.baseSavePath = System.Web.Hosting.HostingEnvironment.MapPath(this.uploadDir);
			this.pathGuid = Guid.NewGuid().ToString();
		}

		/// <summary>
		/// Stores image in the filesystem under given file name.
		/// </summary>
		/// <param name="img">Image to be stored</param>
		/// <param name="fileName">Image filename</param>
		/// <returns>Universal storage path</returns>
		public string StoreImage(Image img, string fileName)
		{
			string universalPath = Path.Combine(this.pathGuid, fileName);
			string dirPath = Path.Combine(this.baseSavePath, pathGuid);
			string savePath = Path.Combine(dirPath, fileName);

			System.IO.Directory.CreateDirectory(dirPath);
			img.Save(savePath);

			return universalPath;
		}

		/// <summary>
		/// Stores image thumbnail in the filesystem under given file name.
		/// </summary>
		/// <param name="img">Image thumbnail to be stored</param>
		/// <param name="fileName">Image thumbnail filename</param>
		/// <returns>Universal storage path</returns>
		public string StoreThumbnail(Image img, string fileName)
		{
			return this.StoreImage(
				img,
				String.Format("thumbnail_{0}", fileName)
			);
		}

		/// <summary>
		/// Returns image stored in the filesystem.
		/// </summary>
		/// <param name="universalPath">Image path</param>
		/// <returns>Stored image</returns>
		public Image GetImage(string universalPath)
		{
			string savePath = Path.Combine(this.baseSavePath, universalPath);
			return Image.FromFile(savePath);
		}

		public Stream ImageToStream(Image img)
		{
			MemoryStream stream = new MemoryStream();
			img.Save(stream, img.RawFormat);
			stream.Position = 0;

			return stream;
		}

		public string GetFullPath(string universalPath)
		{
			return Path.Combine(this.baseSavePath, universalPath);
		}
	}
}