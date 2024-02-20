using ReduceSizeTinify.Interface;
using TinifyAPI;

namespace ReduceSizeTinify.Service;
public class ImageService : IImageService
{
    private readonly string apiKey;
    public ImageService()
    {
        //The Tinify API offers free image compression for up to 500 images per month.
        apiKey = "your_tinify_api_key";
        Tinify.Key = apiKey;
    }
    public async Task<byte[]> CompressImageAsync(byte[] imageData)
    {
        try
        {
            using (var source = Tinify.FromBuffer(imageData))
            {
                var resized = await source.ToBuffer();
                return resized;
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Failed to compress image", ex);
        }
    }
}