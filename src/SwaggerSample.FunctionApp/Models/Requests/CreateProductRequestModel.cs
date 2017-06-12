namespace SwaggerSample.FunctionApp.Models.Requests
{
    /// <summary>
    /// This represents the request model entity to create a product.
    /// </summary>
    public class CreateProductRequestModel
    {
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