using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;
using Nancy.Hosting;
using Nancy.ModelBinding;
using CreativeCaptcha.Domain.Validation;
using CreativeCaptcha.Domain;

namespace CreativeCaptcha.WebApi
{
    public class ValidateBasicModule : NancyModule
    {
        public ValidateBasicModule()
        {
            Post["/validate/basic"] = parameters =>
            {
                var request = this.Bind<ValidateBasicRequest>();
                return _Validate(request);
            };
        }

        public ValidateBasicResponse _Validate(ValidateBasicRequest request)
        {

            var validator = new BasicValidator();
            var repo = new ImageRepository();

            var validateResult = validator.ValidateBasic(request.ID, request.Movements);

            return new ValidateBasicResponse()
            {
                IsHuman = validateResult
            };
           
        }

    }
}