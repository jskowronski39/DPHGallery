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
	public class SimilarImagesViewModel
	{
		public ImageEntity SourceImage { get; set; }
		public IEnumerable<ImageEntity> SimilarImages { get; set; }
	}
}