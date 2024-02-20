namespace ReduceSizeTinify.Interface;
public interface IImageService
{
    Task<byte[]> CompressImageAsync(byte[] imageData);
}