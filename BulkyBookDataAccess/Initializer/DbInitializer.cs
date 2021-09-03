﻿using BulkyBook.DataAccess.Data;
using BulkyBook.Models;
using BulkyBook.utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBookDataAccess.Initializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser>_userManager;

        private readonly RoleManager<IdentityRole>_roleManager;
        public DbInitializer(ApplicationDbContext db, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;

        }

        public void Initialize()
        {
            try
            {
                if (_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();
                }
            }
            catch(Exception ex) 
            { 
            
            
            }
            if (_db.Roles.Any(r => r.Name == SD.Role_Admin)) return;
            
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Admin)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Employee)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Role_User_Comp)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Role_User_Indi)).GetAwaiter().GetResult();

                _userManager.CreateAsync(new ApplicationUser
                {
                    UserName = "admin@123",
                    Email = "admin@123",
                    EmailConfirmed = true,
                    Name = "arun0712"
                },"Admin123*").GetAwaiter().GetResult();
                ApplicationUser user = _db.ApplicationUsers.Where(u => u.Email == "admin@123").FirstOrDefault();
                _userManager.AddToRoleAsync(user, SD.Role_Admin).GetAwaiter().GetResult();
                   
                


            
        }
    }
}
