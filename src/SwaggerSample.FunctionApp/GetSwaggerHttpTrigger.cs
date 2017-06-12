using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;

using Microsoft.Azure.WebJobs.Host;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using YamlDotNet.Serialization;

namespace SwaggerSample.FunctionApp
{
    /// <summary>
    /// This represents the HTTP trigger entity for the GetSwagger event.
    /// </summary>
    public static class GetSwaggerHttpTrigger
    {
        /// <summary>
        /// Invokes the function.
        /// </summary>
        /// <param name="req"><see cref="HttpRequestMessage"/> instance.</param>
        /// <param name="version">Swagger definition version.</param>
        /// <param name="log"><see cref="TraceWriter"/> instance.</param>
        /// <returns>Returns the <see cref="HttpResponseMessage"/> instance.</returns>
        public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, string version, TraceWriter log)
        {
            var wwwroot = Environment.GetEnvironmentVariable("WEBROOT_PATH");
            var filepath = $"{wwwroot}\\swagger-{version}.yaml";
            if (!File.Exists(filepath))
            {
                return req.CreateResponse(HttpStatusCode.NotFound);
            }

            var settings = new JsonSerializerSettings()
                               {
                                   ContractResolver = new CamelCasePropertyNamesContractResolver(),
                                   Formatting = Formatting.Indented
                               };
            var formatter = new JsonMediaTypeFormatter() { SerializerSettings = settings };

            using (var reader = File.OpenText(filepath))
            {
                var yaml = await reader.ReadToEndAsync().ConfigureAwait(false);
                var deserialiser = new DeserializerBuilder().Build();
                var deserialised = deserialiser.Deserialize<dynamic>(yaml);

                return req.CreateResponse(HttpStatusCode.OK, (object)deserialised, formatter);
            }
        }
    }
}