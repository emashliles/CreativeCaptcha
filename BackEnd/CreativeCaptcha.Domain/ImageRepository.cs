using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativeCaptcha.Domain
{
    public class ImageRepository
    {
        List<CaptchaBasicImage> BasicImages;

        public ImageRepository()
        {
            BasicImages = new List<CaptchaBasicImage>();
            BasicImages.Add(new CaptchaBasicImage(@"C:\Users\Emma-Ashley\Documents\CreativeCaptcha\CreativeCaptcha\Images\Basic Images\Arrow.png", 1,2, "Arrow"));

        }


        public CaptchaBasicImage GetBasicImage()
        {
            var random = new Random();
           // var randomNumber = random.Next(0, BasicImages.Count);

            return BasicImages.FirstOrDefault();
        }

    }
}
