using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativeCaptcha.Domain
{
    public class CaptchaBasicImage
    {
        public string ImagePath { get; set; }

        public CaptchaBasicImage(string imagePath)
        {
            ImagePath = imagePath;
        }
    }
}
