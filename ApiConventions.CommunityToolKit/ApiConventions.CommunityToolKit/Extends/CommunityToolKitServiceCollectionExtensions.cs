using System.Reflection;
using ApiConventions.CommunityToolKit.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace ApiConventions.CommunityToolKit.Extends
{
    public static class CommunityToolKitServiceCollectionExtensions
    {
        /// <summary>
        /// 1.统一结果返回过滤器
        /// 2.参数校验过滤器
        /// 3.自定义异常过滤器
        /// 4.HttpResponseException异常过滤器
        /// </summary>
        /// <param name="serviceCollection"></param>
        /// <returns></returns>
        public static IServiceCollection AddResponseResultSetUp(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddMvcCore(options =>
            {
                options.Filters.Add<ApiResultFilter>();
                options.Filters.Add<ValidateModelFilter>();
                options.Filters.Add<CustomException>();
                options.Filters.Add<HttpResponseExceptionFilter>();
            });
            return serviceCollection;
        }

        /// <summary>
        /// 添加swagger文档注释
        /// </summary>
        /// <param name="serviceCollection"></param>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IServiceCollection AddSwaggerGenSetUp(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new()
                {
                    Title = Assembly.GetExecutingAssembly().GetName().Name,
                    Version = "v1",
                });
                foreach (var item in XmlCommentsFilePath)
                {
                    c.IncludeXmlComments(item);
                }
            });
            return serviceCollection;
        }

        private static List<string> XmlCommentsFilePath
        {
            get
            {
                var basePath = AppContext.BaseDirectory;
                var d = new DirectoryInfo(basePath);
                var files = d.GetFiles("*.xml");
                var configXml = files.Select(a => Path.Combine(basePath, a.FullName)).ToList();
                return configXml;
            }
        }

        
    }
}
