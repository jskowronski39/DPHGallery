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
		public Guid Id { get; set; }

		[ForeignKey("Owner")]
		public string OwnerId { get; set; }

		public virtual ApplicationUser Owner { get; set; }

		public string Description { get; set; }

		[Required]
		public string ImagePath { get; set; }

		[Required]
		public string ThumbnailPath { get; set; }

		[Required]
		public string ImageHash { get; set; }

		[Required]
		public int DPH { get; set; }
	}
}