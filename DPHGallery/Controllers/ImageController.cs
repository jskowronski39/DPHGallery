using DPHGallery.Classes;
using DPHGallery.Models.ViewModels;
using DPHGallery.ORM.Contexts;
using DPHGallery.ORM.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DPHGallery.Controllers
{
    public class ImageController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Prześlij zdjęcie";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Upload(ImageUploadViewModel iuvm)
        {
            // In case of validation errors return view with error messages
            if (!ModelState.IsValid)
                return View("Index");
            
            // Store image
            FileManager fm = new FileManager();
            Image image = Image.FromStream(iuvm.File.InputStream);

            // Create & store thumbnail
            Image thumbnail = ThumbnailGenerator.CreateThumbnail(image);
            string imagePath = fm.StoreImage(image, iuvm.File.FileName);
            string thumbnailPath = fm.StoreThumbnail(thumbnail, iuvm.File.FileName);

            // Calculate DPH
            DummyPerceptualHash dph = new DummyPerceptualHash(image);
            int hash = (int)dph.Calculate();

            // Persist
            ImageEntity ent = iuvm.ToEntity();
            ent.ImagePath = Base64Utils.Encode(imagePath);
            ent.ThumbnailPath = Base64Utils.Encode(thumbnailPath);
            ent.DPH = hash;

            using (var ctx = new GalleryContext())
            {
                ctx.Images.Add(ent);
                ctx.SaveChanges();
            }

            return RedirectToAction("MyImages", "Gallery");
        }
    }
}