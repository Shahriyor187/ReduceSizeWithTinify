using Microsoft.AspNetCore.Mvc;
using ReduceSizeTinify.Interface;

namespace ReduceSizeTinify.Controllers;

[ApiController]
[Route("[controller]")]
public class ImageController(IImageService imageService) : ControllerBase
{
    private readonly IImageService _imageService = imageService;
    [HttpPost("Compress")]
    public async Task<IActionResult> CompressImage(IFormFile file)
    {
        try
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded.");

            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                var imageData = memoryStream.ToArray();
                var compressedImageData = await _imageService.CompressImageAsync(imageData);
                return File(compressedImageData, "image/jpeg", "compressed_image.jpg");
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error compressing image: {ex.Message}");
        }
    }
}