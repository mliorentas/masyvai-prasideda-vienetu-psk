using System;
using Core;
using MasyvaiPrasidedaVienetu.WebEndpoints.Models;

namespace MasyvaiPrasidedaVienetu.WebEndpoints.ExtensionMethods
{
    public static class ImageExtensions
    {
        public static ImageViewModel ToViewModel(this Image image)
        {
            ImageViewModel parsedImage;
            try
            {
                parsedImage = new ImageViewModel
                {
                    Id = image.Id,
                    ImageUrl = image.ImageUrl,
                };
            }
            catch (Exception)
            {
                parsedImage = new ImageViewModel();
            }
            return parsedImage;
        }

        public static Image ToEntity(this ImageViewModel image)
        {
            Image parsedImage;
            try
            {
                parsedImage = new Image
                {
                    Id = image.Id,
                    ImageUrl = image.ImageUrl,
                };
            }
            catch (Exception)
            {
                parsedImage = new Image();
            }
            return parsedImage;
        }
    }
}