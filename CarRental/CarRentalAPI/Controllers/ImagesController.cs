using CarRentalAPI.Model.Domain;
using CarRentalAPI.Model.DTO;
using CarRentalAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        public ImagesController(ImagesRepository imagesRepository)
        {
            ImagesRepository = imagesRepository;
        }

        public ImagesRepository ImagesRepository { get; }

        //POST: /api/Images/Upload
        [HttpPost]
        [Route("Upload")]
        public async Task<IActionResult> Upload([FromForm] ImageModel model)
        {
            ValidateFileUpload(model);

            if (ModelState.IsValid)
            {
                //Convert DTO to damain model
                var imageDomainModel = new Images
                {
                    File = model.File,
                    FileExtension = Path.GetExtension(model.File.FileName),
                    FileSizeInBytes = model.File.Length,
                    FileName = model.FileName,
                    FileDescription = model.FileDescription,
                };

                //use repository to upload images

                await ImagesRepository.Upload(imageDomainModel);

                return Ok(imageDomainModel);
            }
            return BadRequest(ModelState);
        }

        private void ValidateFileUpload(ImageModel model)
        {
            //validate the fileExtention
            var allowedExtentions = new string[] { ".jpg", ".jpeg", ".png" };

            if(!allowedExtentions.Contains(Path.GetExtension(model.File.FileName)))
            {
                ModelState.AddModelError("file", "Unsupported file");
            }
            //validate size
            if(model.File.Length > 10485760)
            {
                ModelState.AddModelError("file", "File size is more than 10MB, please upload a smaller file size.");
            }
        }
    }
}
