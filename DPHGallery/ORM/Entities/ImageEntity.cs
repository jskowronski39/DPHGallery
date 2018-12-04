using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DPHGallery.ORM.Entities
{
	[Table("Images")]
	public class ImageEntity
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public Guid Guid { get; set; }

		public Guid Owner { get; set; }

		public string Description { get; set; }

		public string ImagePath { get; set; }

		public string ThumbnailPath { get; set; }

		public string ImageHash { get; set; }

		public int DPH { get; set; }
	}
}