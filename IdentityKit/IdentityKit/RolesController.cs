using System.Net.Http;

public class RolesController : Controller
{
    private ApplicationUserManager _userManager;
    private ApplicationRoleManager _roleManager;

    public RolesController()
    {
    }

    public RolesController(ApplicationUserManager userManager, ApplicationRoleManager roleManager)
    {
        UserManager = userManager;
        RoleManager = roleManager;
    }

    public ApplicationUserManager UserManager
    {
        get
        {
            return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
        }
        private set
        {
            _userManager = value;
        }
    }

    public ApplicationRoleManager RoleManager
    {
        get
        {
            return _roleManager ?? HttpContext.GetOwinContext().Get<ApplicationRoleManager>();
        }
        private set
        {
            _roleManager = value;
        }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> AddToRole(string userId, string roleName)
    {
        if (ModelState.IsValid)
        {
            var result = await UserManager.AddToRoleAsync(userId, roleName);
            if (result.Succeeded)
            {
                // موفقیت‌آمیز بوده
                return RedirectToAction("Index", "Home");
            }
            // خطا در افزودن به نقش
            AddErrors(result);
        }

        return View("Error");
    }

    // دیگر اکشن‌ها و توابع مربوط به مدیریت نقش‌ها اینجا اضافه می‌شوند.
}
