using DPHGallery.Classes;
using DPHGallery.Models.ViewModels;
using DPHGallery.ORM.Contexts;
using DPHGallery.ORM.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace DPHGallery.Controllers
{
	public class GalleryController : Controller
	{
		public ActionResult Index()
		{
			ViewBag.Title = "Galeria zdjęć użytkowników";

			var ctx = new GalleryContext();
			var imagesCollection = ctx.Images.ToList();

			return View(imagesCollection);
		}

		public ActionResult MyImages()
		{
			ViewBag.Title = "Moje zdjęcia";

			var ctx = new GalleryContext();
			var imagesCollection = ctx.Images.ToList();
			
			return View(imagesCollection);
		}

		public ActionResult GetImage(string param)
		{
			string universalPath = Base64Utils.Decode(param);
			FileManager fm = new FileManager();
			Image img = fm.GetImage(universalPath);
			Stream stream = fm.ImageToStream(img);

			return base.File(stream, img.RawFormat.ToString());
		}

		public ActionResult FindSimilar(Guid param)
		{
			var ctx = new GalleryContext();
			var imagesCollection = ctx.Images.ToList();

			var img = imagesCollection.Find(x => x.Guid == param);
			var similarImages = imagesCollection.Where(
				x =>
					x.Guid != param
					&& HammingDistance.Calculate(
						(byte)img.DPH, (byte)x.DPH) <= 4
					)
				.OrderByDescending(
					x => HammingDistance.Calculate(
						(byte)img.DPH, (byte)x.DPH
					)
				)
				.ToList();

			var viewModel = new SimilarImagesViewModel()
			{
				SourceImage = img,
				SimilarImages = similarImages
			};

			return View(viewModel);
		}
	}
}