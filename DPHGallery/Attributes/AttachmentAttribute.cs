using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;

namespace DPHGallery.Attributes
{
	[AttributeUsage(AttributeTargets.Property)]
	public sealed class AttachmentAttribute : ValidationAttribute
	{
		protected override ValidationResult IsValid(object value,
		  ValidationContext validationContext)
		{
			HttpPostedFileBase file = value as HttpPostedFileBase;

			// The maximum allowed file size is 2MB.
			if (file.ContentLength > 2 * 1024 * 1024)
			{
				return new ValidationResult("Rozmiar pliku przekracza 2 MB!");
			}

			// Only PDF can be uploaded.
			string ext = Path.GetExtension(file.FileName);
			if (String.IsNullOrEmpty(ext)
				|| (!ext.Equals(".jpg", StringComparison.OrdinalIgnoreCase)
				&& !ext.Equals(".png", StringComparison.OrdinalIgnoreCase))
			)
			{
				return new ValidationResult("Dozwolone formaty plików to: PNG i JPG!");
			}

			// Everything OK.
			return ValidationResult.Success;
		}
	}
}