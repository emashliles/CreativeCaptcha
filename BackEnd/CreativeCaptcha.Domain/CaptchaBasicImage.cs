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
        public int ID { get; set; }
        public List<MouseGesture> MovementsList { get; set; }
        public string Movements { get; set; }
        public string MovementsJson { get; set; }

        public CaptchaBasicImage(string imagePath, int XCoordinate, int Ycoordinate, string direction ,int id,string description, List<MouseGesture> movements)
        {
            ImagePath = imagePath;
            ID = id;
            StartPoint = new Position(XCoordinate, Ycoordinate, direction);
            DescriptiveSentence = description;//"Trace the lines of the arrow from the start point";
            MovementsList = movements;
        }

        public CaptchaBasicImage(string imagePath, string description, string movements)
        {
            ImagePath = imagePath;
            DescriptiveSentence = description;
          MovementsJson = movements;
        }
        public CaptchaBasicImage()
        {

        }
    }
}
