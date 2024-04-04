using ServiceStack;
using ServiceStack.Text;

namespace SiliconWraith.Web.API.ServiceHost
{
    public class WebHost : AppHostBase
    {
        public WebHost() : base("TribeVibe Music Collaboration Platform", typeof(WebHost).Assembly) { }

        public override void Configure(Funq.Container container)
        {
            JsConfig.ExcludeTypeInfo = true;
            JsConfig.DateHandler  = DateHandler.ISO8601;
            JsConfig.AssumeUtc = true;
            JsConfig.AlwaysUseUtc = true;
            JsConfig.AppendUtcOffset = true;
            JsConfig<Guid>.SerializeFn = guid => guid.ToString("D");
            JsConfig<Guid?>.SerializeFn = guid => guid.Value.ToString("D");



            //Plugins.Add(new SharpPagesFeature());
            //Plugins.Add(new OpenApiFeature());
            //Plugins.Add(new CorsFeature());
            //Plugins.Add(new ValidationFeature());
            //Plugins.Add(new RequestLogsFeature());
            //Plugins.Add(new AutoQueryFeature { MaxLimit = 100 });

            //container.RegisterValidators(typeof(WebHost).Assembly);
            //container.RegisterValidators(typeof(SiliconWraith.Web.API.ServiceInterface.TodoValidator).Assembly);

            //container.RegisterAutoWiredAs<SiliconWraith.Web.API.ServiceInterface.TodoService, SiliconWraith.Web.API.ServiceInterface.ITodoService>();
            //container.RegisterAutoWiredAs<SiliconWraith.Web.API.ServiceInterface.TodoValidator, ServiceStack.FluentValidation.IValidator<SiliconWraith.Web.API.ServiceModel.Todo>>();

            //container.RegisterAutoWiredAs<SiliconWraith.Web.API.ServiceInterface.TodoService, ServiceStack.ServiceInterface.IService<SiliconWraith.Web.API.ServiceModel.Todo>>();
            //container.RegisterAutoWiredAs<SiliconWraith.Web.API.ServiceInterface.TodoValidator, ServiceStack.FluentValidation.IValidator<SiliconWraith.Web.API.ServiceModel.Todo>>();
        }
    }
}
