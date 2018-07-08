namespace CompanyManager.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;
    using DAL;

    internal sealed class Configuration : DbMigrationsConfiguration<CompanyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CompanyContext context)
        {
            var role = new List<Role>
            {
                new Role {RoleID = 1, RoleName = "Quản trị viên"},
                new Role {RoleID = 2, RoleName = "Thành viên"}
            };
            role.ForEach(s => context.Roles.AddOrUpdate(p => p.RoleName, s));
            context.SaveChanges();

            var user = new List<User>
            {
                new User { Username = "admin",   Password = "123", FullName = "Đinh Công Tân", Gender = true, Address = "Hải Phòng", Email = "tan.dct9x@gmail.com", HireDate = DateTime.Now, PhoneNumber = 01262559696, Status = 1 ,
                    Birthday = DateTime.Parse("2010-09-01"), RoleID = 1, Avatar = null }
            };
            user.ForEach(s => context.Users.AddOrUpdate(p => p.Username, s));
            context.SaveChanges();
        }
    }
}
