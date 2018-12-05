using DPHGallery.Attributes;
using DPHGallery.Classes;
using DPHGallery.ORM.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DPHGallery.Models.ViewModels
{
	public class ImageUploadViewModel
	{
		/// TODO: Custom validator that validates file format and size
		[AttachmentAttribute]
		[Required(ErrorMessage = "Upload your image!")]
		public HttpPostedFileBase File { get; set; }

		[StringLength(255, ErrorMessage = "Description is longer than 255 characters!")]
		public string Description { get; set; }

		/// <summary>
		/// Creates entity from view model.
		/// 
		/// TODO: This should be done by a mapper or some other two way converter (command?)
		/// </summary>
		/// <returns>Entity created from model</returns>
		public ImageEntity ToEntity()
		{
			string md5Hash = MD5Utils.MD5ByteHashToString(
				MD5Utils.GetMD5ByteHashFromStream(this.File.InputStream)
			);

			return new ImageEntity()
			{
				Description = this.Description,
				ImageHash = md5Hash,

			};
		}
	}
}