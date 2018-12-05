using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using DPHGallery.ORM.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DPHGallery.ORM.Contexts
{
	public class GalleryContext : IdentityDbContext<ApplicationUser>
	{
		public GalleryContext() : base("name=DPHGalleryConnectionString")
		{
			Database.SetInitializer(new MigrateDatabaseToLatestVersion<GalleryContext, Migrations.Configuration>());
		}

		public DbSet<ImageEntity> Images { get; set; }

		public static GalleryContext Create()
		{
			return new GalleryContext();
		}
	}
}