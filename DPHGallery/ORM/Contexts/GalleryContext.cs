using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using DPHGallery.ORM.Entities;

namespace DPHGallery.ORM.Contexts
{
	public class GalleryContext : DbContext
	{
		public GalleryContext() : base("name=DPHGalleryConnectionString")
		{

		}

		public DbSet<ImageEntity> Images { get; set; }
	}
}