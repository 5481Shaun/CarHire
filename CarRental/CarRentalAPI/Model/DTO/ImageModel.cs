namespace CarRentalAPI.Model.DTO
{
    public class ImageModel
    {
        public IFormFile File { get; set; }
        public string FileName { get; set; }
        public string? FileDescription { get; set; }
    }

}
