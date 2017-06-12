using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;

using Microsoft.Azure.WebJobs.Host;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using SwaggerSample.FunctionApp.Models.Requests;
using SwaggerSample.FunctionApp.Models.Responses;

namespace SwaggerSample.FunctionApp
{
    /// <summary>
    /// This represents the HTTP trigger entity for the CreateProduct event.
    /// </summary>
    public static class CreateProductHttpTrigger
    {
        /// <summary>
        /// Invokes the function.
        /// </summary>
        /// <param name="req"><see cref="HttpRequestMessage"/> instance.</param>
        /// <param name="log"><see cref="TraceWriter"/> instance.</param>
        /// <returns>Returns the <see cref="HttpResponseMessage"/> instance.</returns>
        public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");

            var request = await req.Content
                                   .ReadAsAsync<CreateProductRequestModel>()
                                   .ConfigureAwait(false);

            var response = new CreateProductResponseModel()
                               {
                                   ProductId = Guid.NewGuid(),
                                   ProductName = request.ProductName,
                                   ProductDescription = request.ProductDescription,
                                   ProductPrice = request.ProductPrice
                               };

            var settings = new JsonSerializerSettings()
                               {
                                   ContractResolver = new CamelCasePropertyNamesContractResolver(),
                                   Formatting = Formatting.Indented
                               };
            var formatter = new JsonMediaTypeFormatter() { SerializerSettings = settings };

            return req.CreateResponse(HttpStatusCode.Created, response, formatter);
        }
    }
}