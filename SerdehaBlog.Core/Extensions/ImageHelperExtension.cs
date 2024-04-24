using System.Text.RegularExpressions;
using System.Text;
using SixLabors.ImageSharp;
using Microsoft.AspNetCore.Http;
using SixLabors.ImageSharp.Processing;
using SerdehaBlog.Core.Enums;

namespace SerdehaBlog.Core.Extensions
{
    public static class ImageHelperExtension
    {
        public static string ClearCharacter(string text)
        {
            string newName = Regex.Replace(text, "[^\\w]", "_");
            string unaccentedText = String.Join("", newName.Normalize(NormalizationForm.FormD).Where(c => char.GetUnicodeCategory(c) != System.Globalization.UnicodeCategory.NonSpacingMark));
            return unaccentedText.Replace("ı", "i");
        }

        public static string UploadImage(IFormFile? formFile, string imgPath)
        {
            var extension = Path.GetExtension(formFile?.FileName);
            var newFileName = $"{ClearCharacter($"{DateTime.Now.Day}_{DateTime.Now.Month}_{DateTime.Now.Year}_{DateTime.Now.Millisecond}_{Path.GetFileNameWithoutExtension(formFile?.FileName)}")}{extension}";
            var path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\{imgPath}", newFileName);
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                formFile?.CopyTo(stream);
            }

            return newFileName;
        }

        public static void DeleteImage(string imageUrl, string imgPath)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\{imgPath}", imageUrl);
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

        public static async Task<string> UploadWebpImage(IFormFile? formFile, string imgPath,SectionType? sectionType)
        {
            var newFileName = $"{ClearCharacter($"{DateTime.Now.Day}_{DateTime.Now.Month}_{DateTime.Now.Year}_{DateTime.Now.Millisecond}_{Path.GetFileNameWithoutExtension(formFile?.FileName)}")}.webp";
            var directoryPath = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\{imgPath}");
            var path = Path.Combine(directoryPath, newFileName);

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                using (Image image = Image.Load(formFile!.OpenReadStream()))
                {
                    switch (sectionType)
                    {
                        case SectionType.Author:
                            image.Mutate(x => x.Resize(30, 30, KnownResamplers.Lanczos3));
                            break;
                        case SectionType.Blog:
                            image.Mutate(x => x.Resize(736, 398, KnownResamplers.Lanczos3));
                            break;
                        case SectionType.Avatar:
                            image.Mutate(x => x.Resize(50, 50, KnownResamplers.Lanczos3));
                            break;
                        case SectionType.Default:
                            break;
                    }
                    await image.SaveAsWebpAsync(stream);
                }
            }

            return formFile == null ? "" : newFileName;
        }
    }
}
