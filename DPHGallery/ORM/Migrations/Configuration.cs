using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Migrations;
using DPHGallery.ORM.Contexts;

namespace DPHGallery.ORM.Migrations
{
	internal sealed class Configuration: DbMigrationsConfiguration<Contexts.GalleryContext>
	{
		public Configuration()
		{
			AutomaticMigrationsEnabled = true;
			ContextKey = "DPHGallery.ORM.Contexts.GalleryContext";
		}

		protected override void Seed(GalleryContext context)
		{
			base.Seed(context);
		}
	}
}