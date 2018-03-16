using Microsoft.Owin.Cors;
using Microsoft.Owin.Hosting;
using Owin;
using Swashbuckle.Application;
using Swashbuckle.Swagger;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Dispatcher;
using System.Web.Http.OData;

namespace OwinLocalhost
{
    class Program
    {
        static NameValueCollection appSettings = ConfigurationManager.AppSettings;
        static string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
        static string contollerPath = $@"{currentDirectory}{appSettings["ControllerPath"]}";
        static string xmlCommentsPath = $@"{currentDirectory}{appSettings["SwaggerXmlPath"]}";

        static void Main(string[] args)
        {
            string port = appSettings["Port"];
            string baseAddress = $"http://+:{port}/";

            WebApp.Start<Startup>(url: baseAddress);

            Console.WriteLine("Owin strart up");
            Console.ReadKey();
        }
        public class Startup
        {
            public void Configuration(IAppBuilder appBuilder)
            {

                appBuilder.UseCors(CorsOptions.AllowAll);

                HttpConfiguration config = new HttpConfiguration();

                config.Services.Replace(typeof(IHttpControllerTypeResolver), new ControllerResolver());

                config.MapHttpAttributeRoutes();

                config.Routes.MapHttpRoute(
                    name: "Api",
                    routeTemplate: "api/{controller}/{action}/{id}",
                    defaults: new { id = RouteParameter.Optional }
                    );

                config.EnableSwagger(c =>
                {
                    //讀取指定資料夾底下的xml
                    if (Directory.Exists(xmlCommentsPath))
                    {
                        foreach (var xmlFile in Directory.GetFiles(xmlCommentsPath, "*.xml"))
                        {
                            c.IncludeXmlComments(xmlFile);
                        }
                    }

                    c.SingleApiVersion("v1", "WebAPIOdataOwinServer");
                    c.ResolveConflictingActions(x => x.First());
                    c.OperationFilter<AddDefaultResponse>();
                })
              .EnableSwaggerUi(c =>
              {
                  c.DisableValidator();
              });
                appBuilder.UseWebApi(config);
                config.EnsureInitialized();

            }
        }
        /// <summary>
        /// Swagger顯示Odata的指令
        /// </summary>
        private class AddDefaultResponse : IOperationFilter     //使swagger可以上傳檔案
        {
            public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>()
                {
                    { "$expand", "Causes related entities to be included inline in the response"},
                    { "$filter", "A function that must evaluate to true for a record to be returned"},
                    { "$select", "Specifies a subset of properties to return"},
                    { "$orderby", "Determines what values are used to order a collection of records"},
                    { "$top", "The max number of records"},
                    { "$skip", "The number of records to skip"}
                };

                //檢查Action是否用EnableQueryAttribute
                if (apiDescription.GetControllerAndActionAttributes<EnableQueryAttribute>().Count() != 0)
                {
                    operation.parameters = new List<Parameter>();

                    foreach (var pair in parameters)
                    {
                        operation.parameters.Add(new Parameter
                        {
                            name = pair.Key,
                            required = false,
                            type = "string",
                            @in = "query",
                            description = pair.Value

                        });
                    }
                }
            }
        }
        /// <summary>
        /// 讀取指定資料夾底下的dll
        /// </summary>
        public class ControllerResolver : DefaultHttpControllerTypeResolver
        {
            public override ICollection<Type> GetControllerTypes(IAssembliesResolver assembliesResolver)
            {
                List<Type> list = new List<Type>();
                var controllerType = typeof(System.Web.Http.Controllers.IHttpController);

                if (Directory.Exists(contollerPath))
                {
                    foreach (var dllFile in Directory.GetFiles(contollerPath, "*.dll"))
                    {
                        Assembly assembly = Assembly.LoadFrom(dllFile);
                        var types = assembly.GetExportedTypes();
                        list.AddRange(types.Where(i => controllerType.IsAssignableFrom(i)).ToList());
                    }

                }

                return list;
            }
        }
    }
}
