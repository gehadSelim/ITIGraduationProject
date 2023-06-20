using graduationProject.DAL.Configurations;
using graduationProject.DAL.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace graduationProject.DAL;

public class ShippingSystemContext : IdentityDbContext<ApplicationUser>
{
    public ShippingSystemContext() { }


    public ShippingSystemContext(DbContextOptions<ShippingSystemContext> options) : base(options) { }


    public DbSet<Branch> Branches { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Privilege> Privileges { get; set; }
    public DbSet<Representative> Representatives { get; set; }
    public DbSet<Role_Privileges> Role_Privileges { get; set; }
    public DbSet<Settings> Settings { get; set; }
    public DbSet<ShippingType> ShippingTypes { get; set; }
    public DbSet<SpecialPackage> SpecialPackages { get; set; }
    public DbSet<State> States { get; set; }
    public DbSet<RepresentativeState> RepresentativeStates { get; set; }
    public DbSet<Trader> Traders { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        #region add privileges
        List<Privilege> privileges = new List<Privilege>()
        {
            new Privilege()
            {
                Id = 1,
                Name = "Privileges",
                ArabicName = "الصلاحيات"
            },
            new Privilege()
            {
                Id = 2,
                Name = "Settings",
                ArabicName = "الاعدادات"
            },
            new Privilege()
            {
                Id = 3,
                Name = "Banks",
                ArabicName = "البنوك"
            },
            new Privilege()
            {
                Id = 4,
                Name = "safes",
                ArabicName = "الخزن"
            },
            new Privilege()
            {
                Id = 5,
                Name = "Branches",
                ArabicName = "الافرع"
            },
            new Privilege()
            {
                Id = 6,
                Name = "Employees",
                ArabicName = "الموظفين"
            },
            new Privilege()
            {
                Id = 7,
                Name = "Traders",
                ArabicName = "التجار"
            },
            new Privilege()
            {
                Id = 8,
                Name = "Representatives",
                ArabicName = "المناديب"
            },
            new Privilege()
            {
                Id = 9,
                Name = "States",
                ArabicName = "المحافظات"
            },
            new Privilege()
            {
                Id = 10,
                Name = "Cities",
                ArabicName = "المدن"
            },new Privilege()
            {
                Id = 11,
                Name = "Orders",
                ArabicName = "الطلبات"
            },new Privilege()
            {
                Id = 12,
                Name = "Calculations",
                ArabicName = "الحسابات"
            },new Privilege()
            {
                Id = 13,
                Name = "OrdersReports",
                ArabicName = "تقارير الطلبات"
            },
        };
        builder.Entity<Privilege>().HasData(privileges);
        #endregion

        #region add settings

        builder.Entity<Settings>().HasData(new Settings()
        {
            Id = 1,
            DefaultWeight = 0,
            OverCostPerKG = 0,
            VillageShipingCost = 0
        });
        #endregion

        #region add role
        List<Role> identityUserRole = new List<Role>()
        {
             new Role("SuperAdmin")
             {
                 NormalizedName = "SUPERADMIN",
                 Date = DateTime.Now,
             }
        };
        builder.Entity<Role>().HasData(identityUserRole);
        #endregion

        #region add role privilege
        List<Role_Privileges> RolePrivileges = new List<Role_Privileges>()
                {
                    new Role_Privileges
                    {
                        RoleId = identityUserRole[0].Id,
                        PrivilegeId = 1,
                        AddPermission = true,
                        EditPermission = true,
                        ViewPermission = true,
                        DeletePermission = true
                    },
                    new Role_Privileges
                    {
                        RoleId = identityUserRole[0].Id,
                        PrivilegeId = 2,
                        AddPermission = true,
                        EditPermission = true,
                        ViewPermission = true,
                        DeletePermission = true
                    },
                    new Role_Privileges
                    {

                        RoleId = identityUserRole[0].Id,
                        PrivilegeId = 3,
                        AddPermission = true,
                        EditPermission = true,
                        ViewPermission = true,
                        DeletePermission = true
                    },
                    new Role_Privileges
                    {
                        RoleId = identityUserRole[0].Id,
                        PrivilegeId = 4,
                        AddPermission = true,
                        EditPermission = true,
                        ViewPermission = true,
                        DeletePermission = true
                    },
                    new Role_Privileges
                    {
                        RoleId = identityUserRole[0].Id,
                        PrivilegeId = 5,
                        AddPermission = true,
                        EditPermission = true,
                        ViewPermission = true,
                        DeletePermission = true
                    },
                    new Role_Privileges
                    {
                        RoleId = identityUserRole[0].Id,
                        PrivilegeId = 6,
                        AddPermission = true,
                        EditPermission = true,
                        ViewPermission = true,
                        DeletePermission = true
                    },
                    new Role_Privileges
                    {
                        RoleId = identityUserRole[0].Id,
                        PrivilegeId = 7,
                        AddPermission = true,
                        EditPermission = true,
                        ViewPermission = true,
                        DeletePermission = true
                    },
                    new Role_Privileges
                    {
                        RoleId = identityUserRole[0].Id,
                        PrivilegeId = 8,
                        AddPermission = true,
                        EditPermission = true,
                        ViewPermission = true,
                        DeletePermission = true
                    },
                    new Role_Privileges
                    {
                        RoleId = identityUserRole[0].Id,
                        PrivilegeId = 9,
                        AddPermission = true,
                        EditPermission = true,
                        ViewPermission = true,
                        DeletePermission = true
                    },
                    new Role_Privileges
                    {
                        RoleId = identityUserRole[0].Id,
                        PrivilegeId = 10,
                        AddPermission = true,
                        EditPermission = true,
                        ViewPermission = true,
                        DeletePermission = true
                    },
                    new Role_Privileges
                    {
                        RoleId = identityUserRole[0].Id,
                        PrivilegeId = 11,
                        AddPermission = true,
                        EditPermission = true,
                        ViewPermission = true,
                        DeletePermission = true
                    },
                    new Role_Privileges
                    {
                        RoleId = identityUserRole[0].Id,
                        PrivilegeId = 12,
                        AddPermission = true,
                        EditPermission = true,
                        ViewPermission = true,
                        DeletePermission = true
                    },
                    new Role_Privileges
                    {
                        RoleId = identityUserRole[0].Id,
                        PrivilegeId = 13,
                        AddPermission = true,
                        EditPermission = true,
                        ViewPermission = true,
                        DeletePermission = true
                    },
                };

        int roId = 1;

        foreach (var roleprivilege in RolePrivileges)
        {
            builder.Entity<Role_Privileges>().HasData(new Role_Privileges
            {
                Id = roId,
                AddPermission = roleprivilege.AddPermission,
                DeletePermission = roleprivilege.DeletePermission,
                EditPermission = roleprivilege.EditPermission,
                ViewPermission = roleprivilege.ViewPermission,
                RoleId = roleprivilege.RoleId,
                PrivilegeId = roleprivilege.PrivilegeId,
            });

            roId++;
        }


        #endregion

        #region add branch
        Branch branch = new()
        {
            Id = 1,
            Name = "Main Branch"
        };
        builder.Entity<Branch>().HasData(branch);
        #endregion

        #region add state 
        State state = new()
        {
            Id = 1,
            Name = "Main State",
            Status = true
        };
        builder.Entity<State>().HasData(state);
        #endregion

        #region add city 
        City city = new()
        {
            Id = 1,
            Name = "Main City",
            ShipingCost = 50,
            StateId = 1
        };
        builder.Entity<City>().HasData(city);
        #endregion

        #region add superadmin user 

        ApplicationUser superAdminUser = new ApplicationUser()
        {
            UserName = "SuperAdmin",
            NormalizedUserName = "SUPERADMIN",
            Email = "super_admin@shipping.com",
            NormalizedEmail = "SUPER_ADMIN@SHIPPING.COM",
            Address = "Banha",
            PhoneNumber = "01090370531",
            FullName = "Aya Ahmed Mahmoud"
        };

        var password = "Admin1234#";
        var passwordHasher = new PasswordHasher<ApplicationUser>();
        var hashedPassword = passwordHasher.HashPassword(superAdminUser, password);
        superAdminUser.PasswordHash = hashedPassword;

        builder.Entity<ApplicationUser>().HasData(superAdminUser);

        Employee superAdminEmployee = new Employee()
        {
            Id = superAdminUser.Id,
            ApplicationUserId = superAdminUser.Id,
            RoleId = identityUserRole[0].Id,
            BranchId = branch.Id
        };
        builder.Entity<Employee>().HasData(superAdminEmployee);

        builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>()
        {
            RoleId = identityUserRole[0].Id,
            UserId = superAdminUser.Id
        });


        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, superAdminUser.Id),
            new Claim(ClaimTypes.UserData, superAdminUser.UserName),
            new Claim(ClaimTypes.Role, identityUserRole[0].Id),
        };

        int claimid = 1; // Initial claim value

        foreach (var claim in claims)
        {
            builder.Entity<IdentityUserClaim<string>>().HasData(new IdentityUserClaim<string>()
            {
                Id = claimid, // Assign negative value
                UserId = superAdminUser.Id,
                ClaimType = claim.Type,
                ClaimValue = claim.Value
            });

            claimid++; // increment the id for the next claim
        }
        #endregion

        #region add trader user 

        ApplicationUser traderUser = new ApplicationUser()
        {
            UserName = "Trader",
            NormalizedUserName = "TRADER",
            Email = "trader@shipping.com",
            NormalizedEmail = "TRADER@SHIPPING.COM",
            Address = "Banha",
            PhoneNumber = "01556968642",
            FullName = "Ahmed Khaled"
        };

        var passwordOfTrader = "Trader1234#";
        var passwordOfTraderHasher = new PasswordHasher<ApplicationUser>();
        var hashedPasswordOfTrader = passwordOfTraderHasher.HashPassword(traderUser, passwordOfTrader);
        traderUser.PasswordHash = hashedPasswordOfTrader;

        builder.Entity<ApplicationUser>().HasData(traderUser);

        Trader Trader = new Trader()
        {
            Id = traderUser.Id,
            ApplicationUserId = traderUser.Id,
            BranchId = branch.Id,
            StateId = state.Id,
            CityId = city.Id,
            StoreName = "Main Store",
            RejectedOrderlossRatio = 10,
            Date = DateTime.UtcNow,
        };
        builder.Entity<Trader>().HasData(Trader);

        var claimsOfTrader = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, traderUser.Id),
            new Claim(ClaimTypes.UserData, traderUser.UserName),
            new Claim(ClaimTypes.Role, "Trader"),
        };

        foreach (var claim in claimsOfTrader)
        {
            builder.Entity<IdentityUserClaim<string>>().HasData(new IdentityUserClaim<string>()
            {
                Id = claimid, // Assign negative value
                UserId = traderUser.Id,
                ClaimType = claim.Type,
                ClaimValue = claim.Value
            });

            claimid++; // increment the id for the next claim
        }
        #endregion

        #region add special package of trader
        builder.Entity<SpecialPackage>().HasData(new SpecialPackage()
        {
            Id = 1,
            CityId = city.Id,
            StateId = state.Id,
            ShippingCost = 40,
            TraderId = traderUser.Id
        });
        #endregion

        #region add representative user 

        ApplicationUser representativeUser = new ApplicationUser()
        {
            UserName = "Representative",
            NormalizedUserName = "REPRESENTATIVE",
            Email = "representative@shipping.com",
            NormalizedEmail = "REPRESENTATIVE@SHIPPING.COM",
            Address = "Tanta",
            PhoneNumber = "01015226007",
            FullName = "Mohammed Ahmed"
        };

        var passwordOfRepresentative = "Representative1234#";
        var passwordOfRepresentativeHasher = new PasswordHasher<ApplicationUser>();
        var hashedPasswordOfRepresentative = passwordOfRepresentativeHasher.HashPassword(representativeUser, passwordOfRepresentative);
        representativeUser.PasswordHash = hashedPasswordOfRepresentative;

        builder.Entity<ApplicationUser>().HasData(representativeUser);

        Representative Representative = new Representative()
        {
            Id = representativeUser.Id,
            ApplicationUserId = representativeUser.Id,
            BranchId = branch.Id,
            CompanyOrderRatio = 50,
            DiscountType = DiscountType.PrecentRatio,
            Date = DateTime.Now,
        };
        builder.Entity<Representative>().HasData(Representative);

        var claimsOfRepresentative = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, representativeUser.Id),
            new Claim(ClaimTypes.UserData, representativeUser.UserName),
            new Claim(ClaimTypes.Role, "Representative"),
        };

        foreach (var claim in claimsOfRepresentative)
        {
            builder.Entity<IdentityUserClaim<string>>().HasData(new IdentityUserClaim<string>()
            {
                Id = claimid,
                UserId = representativeUser.Id,
                ClaimType = claim.Type,
                ClaimValue = claim.Value
            });

            claimid++; // increment the id for the next claim
        }
        #endregion

        #region add state of representative
        builder.Entity<RepresentativeState>().HasData(new RepresentativeState()
        {
            Id = 1,
            RepresentativeId = representativeUser.Id,
            StateId = state.Id
        });
        #endregion


        new BranchEntityTypeConfiguration().Configure(builder.Entity<Branch>());
        new CityEntityTypeConfiguration().Configure(builder.Entity<City>());
        new EmployeeEntityTypeConfiguration().Configure(builder.Entity<Employee>());
        new OrderEntityTypeConfiguration().Configure(builder.Entity<Order>());
        new PrivilegeEntityTypeConfiguration().Configure(builder.Entity<Privilege>());
        new RepresentativeEntityTypeConfiguration().Configure(builder.Entity<Representative>());
        new ShippingTypeEntityTypeConfiguration().Configure(builder.Entity<ShippingType>());
        new StateEntityTypeConfiguration().Configure(builder.Entity<State>());
        new TraderEntityTypeConfiguration().Configure(builder.Entity<Trader>());
    }


}