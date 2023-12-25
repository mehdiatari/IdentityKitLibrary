using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

public class IdentityDbContext : IdentityDbContext<ApplicationUser>
{
    public IdentityDbContext() : base("YourConnectionStringName") { }

    // افزودن DbSet برای هر موجودیت (User، Role و غیره) به جهت ذخیره‌سازی در پایگاه داده
    // public DbSet<User> Users { get; set; }
    // public DbSet<Role> Roles { get; set; }
}

public class ApplicationUser : IdentityUser
{
    // افزودن ویژگی‌های مورد نیاز شما به کلاس کاربر
    // public string CustomProperty { get; set; }
}
