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
            var movements = new List<MouseGesture>();
            movements.Add(new MouseGesture("SW", 100));
            movements.Add(new MouseGesture("S", 20));
            movements.Add(new MouseGesture("NE", 205));


            BasicImages = new List<CaptchaBasicImage>();
            BasicImages.Add(new CaptchaBasicImage(@"C:\Users\Emma-Ashley\Documents\CreativeCaptcha\CreativeCaptcha\Images\Basic Images\Arrow.png", 1,2, "Arrow", movements));

        }


        public CaptchaBasicImage GetBasicImage()
        {
            var random = new Random();
           // var randomNumber = random.Next(0, BasicImages.Count);

            return BasicImages.FirstOrDefault();
        }


        public CaptchaBasicImage GetImageByName(string name)
        {
            return BasicImages.FirstOrDefault(i => i.Name == name);
        }
    }
}
