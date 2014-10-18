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
        public string DescriptiveSentence { get; set;}
        public Position StartPoint { get; set; }

        public CaptchaBasicImage(string imagePath, int XCoordinate, int Ycoordinate)
        {
            ImagePath = imagePath;
            StartPoint = new Position(XCoordinate, Ycoordinate);
            DescriptiveSentence = "Trace the lines of the arrow from the start point";
        }
    }
}
