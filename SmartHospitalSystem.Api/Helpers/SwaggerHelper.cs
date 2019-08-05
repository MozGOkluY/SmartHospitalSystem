namespace SmartHospitalSystem.Api.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text.RegularExpressions;
    using System.Xml.XPath;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.ApiExplorer;
    using Microsoft.Extensions.DependencyInjection;
    using Swashbuckle.AspNetCore.Swagger;
    using Swashbuckle.AspNetCore.SwaggerGen;
    using Swashbuckle.AspNetCore.SwaggerUI;

    /// <summary>
    ///     Swagger helper.
    /// </summary>
    public static class SwaggerHelper
    {
        private const string ROUTE_PREFIX = "swagger";

        /// <summary>
        ///     Configure generation of swagger documentation.
        /// </summary>
        /// <param name="swaggerGenOptions">Swagger code generation options.</param>
        public static void ConfigureSwaggerGen(SwaggerGenOptions swaggerGenOptions)
        {
            Assembly webApiAssembly = Assembly.GetEntryAssembly();
            AddSwaggerDocPerVersion(swaggerGenOptions, webApiAssembly);
            ApplyDocInclusions(swaggerGenOptions);
            IncludeXmlComments(swaggerGenOptions, webApiAssembly);

            swaggerGenOptions.AddSecurityDefinition(
                "Bearer",
                new ApiKeyScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = "header",
                    Type = "apiKey"
                });

            swaggerGenOptions.IgnoreObsoleteActions();
            swaggerGenOptions.DescribeAllEnumsAsStrings();
        }

        /// <summary>
        ///     Configure swagger.
        /// </summary>
        /// <param name="swaggerOptions">Swagger options.</param>
        public static void ConfigureSwagger(SwaggerOptions swaggerOptions)
        {
            swaggerOptions.RouteTemplate = ROUTE_PREFIX + "/{documentName}/swagger.json";
        }

        /// <summary>
        ///     Configures Swagger UI display.
        /// </summary>
        /// <param name="swaggerUiOptions">Swagger ui display options.</param>
        public static void ConfigureSwaggerUi(SwaggerUIOptions swaggerUiOptions)
        {
            Assembly webApiAssembly = Assembly.GetEntryAssembly();
            List<string> apiVersions = GetApiVersions(webApiAssembly);

            foreach (string apiVersion in apiVersions)
            {
                swaggerUiOptions.SwaggerEndpoint($"/{ROUTE_PREFIX}/v{apiVersion}/swagger.json", $"Api V{apiVersion} Docs");
            }

            swaggerUiOptions.RoutePrefix = ROUTE_PREFIX;
        }

        private static void AddSwaggerDocPerVersion(SwaggerGenOptions swaggerGenOptions, Assembly webApiAssembly)
        {
            List<string> apiVersions = GetApiVersions(webApiAssembly);
            string assemblyName = webApiAssembly.GetName().Name;

            foreach (string apiVersion in apiVersions)
            {
                swaggerGenOptions.SwaggerDoc(
                    $"v{apiVersion}",
                    new Info
                    {
                        Title = assemblyName,
                        Version = $"v{apiVersion}",
                        Description = $"{assemblyName} (ASP.NET Core 2.2.0)"
                    });
            }
        }

        private static void ApplyDocInclusions(SwaggerGenOptions swaggerGenOptions)
        {
            swaggerGenOptions.DocInclusionPredicate(
                (docName, apiDesc) =>
                {
                    MethodInfo methodInfo = GetMethodInfo(apiDesc);

                    if (methodInfo != null)
                    {
                        IEnumerable<string> versions = methodInfo.DeclaringType.GetCustomAttributes(true)
                            .OfType<RouteAttribute>()
                            .Select(attr => ExtractVersionNumber(attr.Template));

                        return versions.Any(ver => $"v{ver}" == docName);
                    }

                    return false;
                });
        }

        private static MethodInfo GetMethodInfo(ApiDescription apiDescription)
        {
            apiDescription.TryGetMethodInfo(out MethodInfo methodInfo);
            return methodInfo;
        }

        private static void IncludeXmlComments(SwaggerGenOptions swaggerGenOptions, Assembly webApiAssembly)
        {
            string assemblyName = webApiAssembly.GetName().Name;
            var comments = new XPathDocument($"{AppContext.BaseDirectory}{Path.DirectorySeparatorChar}{assemblyName}.xml");
            swaggerGenOptions.OperationFilter<XmlCommentsOperationFilter>(comments);
        }

        private static List<string> GetApiVersions(Assembly webApiAssembly)
        {
            List<string> apiRoutes = webApiAssembly.DefinedTypes
                .Where(x => x.IsSubclassOf(typeof(Controller)) && x.GetCustomAttributes<RouteAttribute>().Any())
                .Select(y => y.GetCustomAttribute<RouteAttribute>())
                .Select(v => v.Template.ToLower())
                .Distinct()
                .OrderBy(x => x)
                .ToList();

            List<string> apiVersions = apiRoutes.Select(ExtractVersionNumber)
                                                .Where(x => !string.IsNullOrEmpty(x))
                                                .Distinct()
                                                .ToList();

            return apiVersions;
        }

        private static string ExtractVersionNumber(string route)
        {
            string result = string.Empty;
            MatchCollection matches = Regex.Matches(route, "/v(\\d+)/");

            if (!string.IsNullOrEmpty(route) && matches.Any())
            {
                result = matches[0].Groups[1].Value;
            }

            return result;
        }
    }
}
