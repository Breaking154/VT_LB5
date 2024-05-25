using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using WebApplication1.Entities;

namespace WebApplication1.Controllers
{
    public class ImageController : Controller
    {
        UserManager<ApplicationUser> _userManager;
        IWebHostEnvironment _env;
        public ImageController(UserManager<ApplicationUser>
       userManager, IWebHostEnvironment env)
        {
            _userManager = userManager;
            _env = env;
        }
        public async Task<FileResult> GetAvatar()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                if (user.AvatarImage != null && user.AvatarImage.Length > 0)
                {
                    return File(user.AvatarImage, "image/...");
                }
                else
                {
                    var avatarPath = "/Images/anonymous.png";

                    return File(_env.WebRootFileProvider
                        .GetFileInfo(avatarPath)
                        .CreateReadStream(), "image/...");
                }
            }
            else
            {
                // Обработка ситуации, когда пользователь не найден
                // Например, возврат специального изображения по умолчанию
                var defaultAvatarPath = "/Images/default-avatar.png";
                return File(_env.WebRootFileProvider
                    .GetFileInfo(defaultAvatarPath)
                    .CreateReadStream(), "image/...");
            }
        }

    }
}
