using CreativeCaptcha.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CreativeCaptcha.WebApi
{
    public class CaptchaResponse
    {
        //public CaptchaBasicImage Image { get; set; }

        public string ImagePath { get; set; }
        public string DescriptiveSentence { get; set; }
        public int ID { get; set; }



    }
}
