using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy.ModelBinding;
using CreativeCaptcha.Domain;

namespace CreativeCaptcha.WebApi
{
    public class AddNewCaptchaModule : NancyModule
    {
        public AddNewCaptchaModule()
        {
            Post["/add/basic"] = parameters =>
            {
                var request = this.Bind<AddBasicRequest>();
                return _Validate(request);
            };
        }

        private AddBasicConfirmationResponse _Validate(AddBasicRequest request)
        {
            var repo = new ImageRepository();
            repo.AddBasicImage(request.ImagePath, request.DescriptiveSentence, request.Movements);
            return new AddBasicConfirmationResponse()
            {
                Success = true
            };
        }

    }
}