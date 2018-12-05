using DPHGallery.Classes;
using DPHGallery.Models.ViewModels;
using DPHGallery.ORM.Contexts;
using DPHGallery.ORM.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DPHGallery.Controllers
{
    [Authorize]
    public class ImageController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Submit image!";

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

            var ctx = new GalleryContext();
            string userId = User.Identity.GetUserId();
            var user = ctx.Users.Where(x => x.Id == userId).First();
            ent.Owner = user;
            ctx.Images.Add(ent);
            ctx.SaveChanges();

            return RedirectToAction("MyImages", "Gallery");
        }
    }
}