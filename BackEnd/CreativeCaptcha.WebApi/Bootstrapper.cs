using Nancy;
using Nancy.Bootstrapper;
using Nancy.Responses.Negotiation;
using Nancy.TinyIoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CreativeCaptcha.WebApi
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {

        protected override void RequestStartup(TinyIoCContainer container, IPipelines pipelines, NancyContext context)
        {

            //CORS Enable
            pipelines.AfterRequest.AddItemToEndOfPipeline((ctx) =>
            {
                ctx.Response.WithHeader("Access-Control-Allow-Origin", "*")
                                .WithHeader("Access-Control-Allow-Methods", "POST,GET")
                                .WithHeader("Access-Control-Allow-Headers", "Accept, Origin, Content-type");

            });
        }
        protected override NancyInternalConfiguration InternalConfiguration
        {
            get { return new NancyInternalConfigurationFactory().Build(); }
        }
    }
    public class NancyInternalConfigurationFactory
    {
        public NancyInternalConfiguration Build()
        {
            return NancyInternalConfiguration.WithOverrides(c =>
            {
                // This is optional because of Nancy's serializers autodiscovery and priority
                c.Serializers.Clear();
                c.Serializers.Add(typeof(Nancy.Serialization.JsonNet.JsonNetSerializer));
                c.ResponseProcessors.Clear();
                c.ResponseProcessors.Add(typeof(JsonProcessor));
            });
        }
    }
}