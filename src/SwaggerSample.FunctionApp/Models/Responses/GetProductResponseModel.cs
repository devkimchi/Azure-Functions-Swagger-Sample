using System;

namespace SwaggerSample.FunctionApp.Models.Responses
{
    /// <summary>
    /// This represents the response model entity to get a product.
    /// </summary>
    public class GetProductResponseModel
    {
        /// <summary>
        /// Gets or sets the product Id.
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// Gets or sets the product name.
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// Gets or sets the product description.
        /// </summary>
        public string ProductDescription { get; set; }

        /// <summary>
        /// Gets or sets the product price.
        /// </summary>
        public decimal ProductPrice { get; set; }
    }
}