using CreativeCaptcha.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CreativeCaptcha.WebApi
{
    public class ValidateBasicRequest
    {
        public List<MouseGesture> Movements { get; set; }

        public int ID { get; set; }
    }
}