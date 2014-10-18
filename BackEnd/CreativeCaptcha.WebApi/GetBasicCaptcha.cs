using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;
using Nancy.ModelBinding;
using CreativeCaptcha.Domain;


namespace CreativeCaptcha.WebApi
{
    public class GetBasicCaptcha : NancyModule
    {
        public GetBasicCaptcha()
        {
            Get["/captcha/basic"] = parameters =>
            {
                var request = this.Bind<CaptchaBasicRequest>();
                return _Get(request);
            };

        }

        public CaptchaResponse _Get(CaptchaBasicRequest request)
        {
            var repo = new ImageRepository();



            return new CaptchaResponse()
            {
                Image = repo.GetBasicImage()
            };

        }

    }
}