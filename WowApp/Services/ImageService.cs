using Microsoft.AspNetCore.Components.Forms;

using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Formats.Webp;
using SixLabors.ImageSharp.Processing;

namespace WowApp.Services
{
    public class ImageService
    {
        private readonly IWebHostEnvironment _env;

        public ImageService(IWebHostEnvironment env)
        {
            _env = env;
        }

        public async Task<string> SaveCompressedAsync(IBrowserFile file, string folder, int maxWidth = 1600, int quality = 75)
        {
            // захист
            var allowed = new[] { "image/jpeg", "image/png", "image/webp" };
            if (!allowed.Contains(file.ContentType))
                throw new InvalidOperationException("Дозволені тільки JPG/PNG/WEBP.");

            // читаємо в пам’ять (для адмінки ок)
            await using var input = file.OpenReadStream(maxAllowedSize: 10 * 1024 * 1024);
            using var image = await Image.LoadAsync(input);

            // resize тільки якщо велике
            if (image.Width > maxWidth)
            {
                var newHeight = (int)Math.Round(image.Height * (maxWidth / (double)image.Width));
                image.Mutate(x => x.Resize(maxWidth, newHeight));
            }

            // папка на диску
            folder = folder.Trim('/').Replace("\\", "/");
            var dir = Path.Combine(_env.WebRootPath, folder);
            Directory.CreateDirectory(dir);

            // унікальна назва
            var fileName = $"{Guid.NewGuid():N}.webp";
            var fullPath = Path.Combine(dir, fileName);

            // webp якість
            var encoder = new WebpEncoder { Quality = quality };
            await image.SaveAsWebpAsync(fullPath, encoder);

            // повертаємо web path
            return $"/{folder}/{fileName}";
        }

        public Task DeleteIfExistsAsync(string webPath)
        {
            if (string.IsNullOrWhiteSpace(webPath)) return Task.CompletedTask;
            var rel = webPath.TrimStart('/').Replace("/", Path.DirectorySeparatorChar.ToString());
            var full = Path.Combine(_env.WebRootPath, rel);
            if (File.Exists(full)) File.Delete(full);
            return Task.CompletedTask;
        }
    }
}
