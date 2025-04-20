
namespace _.DTOS
{
    // For product registration
    public class ProductRegistrationRequest
    {
        public string Productname { get; set; } = string.Empty;
        public string Price { get; set; } = string.Empty;
        public string ProductDescription { get; set; } = string.Empty;
    }

    // For product update
    public class ProductUpdateRequest
    {
        public string Productname { get; set; } = string.Empty;
        public string Price { get; set; } = string.Empty;
        public string ProductDescription { get; set; } = string.Empty;
    }
}
