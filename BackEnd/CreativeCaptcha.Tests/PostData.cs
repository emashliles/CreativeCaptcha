using Nancy;
using Nancy.Testing;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativeCaptcha.Tests
{
    public class PostData
    {
        [Test]
        public void complete_post_data()
        {
            // Given
            var bootstrapper = new DefaultNancyBootstrapper();
            var browser = new Browser(bootstrapper);

            // When
            var response = browser.Post("/validateBasic/", (with) =>
            {
                with.HttpRequest();
                with.FormValue("Movements", "[{direction: 'SW', length: 100},{direction:'S', length: 20},{direction:'NE', length:205}]");
                with.FormValue("CaptchaImage", "Arrow");
            });

            dynamic body = JObject.Parse(response.Body.AsString());

            // Then
            Assert.IsTrue(body.IsHuman);
        }

        [Test]
        public void justname()
        {
            // Given
            var bootstrapper = new DefaultNancyBootstrapper();
            var browser = new Browser(bootstrapper);

            // When
            var response = browser.Post("/validate/basic", (with) =>
            {
                with.HttpRequest();
              //  with.FormValue("Movements", "[{direction: 'SW', length: 100},{direction:'S', length: 20},{direction:'NE', length:205}]");
                with.FormValue("CaptchaImage", "Arrow");
            });

            dynamic body = JObject.Parse(response.Body.AsString());

            // Then
            Assert.IsTrue(body.IsHuman);
        }

    }
}
