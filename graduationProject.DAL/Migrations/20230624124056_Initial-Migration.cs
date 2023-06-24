using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace graduationProject.DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(75)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    Status = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Privileges",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(75)", nullable: false),
                    ArabicName = table.Column<string>(type: "nvarchar(75)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Privileges", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false),
                    DefaultWeight = table.Column<double>(type: "float", nullable: false),
                    OverCostPerKG = table.Column<double>(type: "float", nullable: false),
                    VillageShipingCost = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShippingTypes",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(75)", nullable: false),
                    Cost = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(75)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    BranchId = table.Column<byte>(type: "tinyint", nullable: false, defaultValue: (byte)1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Employees_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetDefault);
                });

            migrationBuilder.CreateTable(
                name: "Representatives",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DiscountType = table.Column<int>(type: "int", nullable: false),
                    CompanyOrderRatio = table.Column<double>(type: "float", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    BranchId = table.Column<byte>(type: "tinyint", nullable: false, defaultValue: (byte)1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Representatives", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Representatives_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Representatives_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetDefault);
                });

            migrationBuilder.CreateTable(
                name: "Role_Privileges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PrivilegeId = table.Column<byte>(type: "tinyint", nullable: false),
                    AddPermission = table.Column<bool>(type: "bit", nullable: false),
                    EditPermission = table.Column<bool>(type: "bit", nullable: false),
                    DeletePermission = table.Column<bool>(type: "bit", nullable: false),
                    ViewPermission = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role_Privileges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Role_Privileges_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Role_Privileges_Privileges_PrivilegeId",
                        column: x => x.PrivilegeId,
                        principalTable: "Privileges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(75)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    ShipingCost = table.Column<double>(type: "float", nullable: false),
                    StateId = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RepresentativeStates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StateId = table.Column<byte>(type: "tinyint", nullable: false),
                    RepresentativeId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepresentativeStates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RepresentativeStates_Representatives_RepresentativeId",
                        column: x => x.RepresentativeId,
                        principalTable: "Representatives",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RepresentativeStates_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Traders",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StoreName = table.Column<string>(type: "nvarchar(85)", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    StateId = table.Column<byte>(type: "tinyint", nullable: false),
                    RejectedOrderlossRatio = table.Column<double>(type: "float", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    BranchId = table.Column<byte>(type: "tinyint", nullable: false, defaultValue: (byte)1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Traders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Traders_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Traders_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetDefault);
                    table.ForeignKey(
                        name: "FK_Traders_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Traders_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderType = table.Column<int>(type: "int", nullable: false),
                    ShippingTypeId = table.Column<byte>(type: "tinyint", nullable: false),
                    ClientName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    StateId = table.Column<byte>(type: "tinyint", nullable: false),
                    PaymentType = table.Column<int>(type: "int", nullable: false),
                    BranchId = table.Column<byte>(type: "tinyint", nullable: false, defaultValue: (byte)1),
                    AdressDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsVillage = table.Column<bool>(type: "bit", nullable: false),
                    OrderShipingCost = table.Column<double>(type: "float", nullable: false),
                    OrderCost = table.Column<double>(type: "float", nullable: false),
                    TotalCost = table.Column<double>(type: "float", nullable: false),
                    TotalWeight = table.Column<double>(type: "float", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TraderId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OrderStatus = table.Column<int>(type: "int", nullable: false),
                    RepresentativeID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ReceivedCost = table.Column<double>(type: "float", nullable: true, defaultValue: 0.0),
                    ReceivedShipingCost = table.Column<double>(type: "float", nullable: true, defaultValue: 0.0),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetDefault);
                    table.ForeignKey(
                        name: "FK_Orders_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Orders_Representatives_RepresentativeID",
                        column: x => x.RepresentativeID,
                        principalTable: "Representatives",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_ShippingTypes_ShippingTypeId",
                        column: x => x.ShippingTypeId,
                        principalTable: "ShippingTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Orders_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Orders_Traders_TraderId",
                        column: x => x.TraderId,
                        principalTable: "Traders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "SpecialPackages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    StateId = table.Column<byte>(type: "tinyint", nullable: false),
                    ShippingCost = table.Column<double>(type: "float", nullable: false),
                    TraderId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialPackages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpecialPackages_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpecialPackages_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_SpecialPackages_Traders_TraderId",
                        column: x => x.TraderId,
                        principalTable: "Traders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductWeight = table.Column<double>(type: "float", nullable: false),
                    ProductQuantity = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Date", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "16676d47-ec18-4a70-9dcf-2285e7ae7fbc", null, new DateTime(2023, 6, 24, 15, 40, 54, 750, DateTimeKind.Local).AddTicks(2549), "Role", "SuperAdmin", "SUPERADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "56b84096-f76d-479c-b994-0b59d5b0407d", 0, "Banha", "148b1452-acaf-4ac4-9d0d-c8004eeaf191", "trader@shipping.com", false, "Ahmed Khaled", false, null, "TRADER@SHIPPING.COM", "TRADER", "AQAAAAIAAYagAAAAEDWVbIh9+xRh7+DaLZcotrzLO3iLr3erIgktJSD4oDtIHHxWT/gZtRqt68UurLcJUQ==", "01556968642", false, "2fe9639e-6901-41d7-a5f6-95c4fe2897ab", true, false, "Trader" },
                    { "a00237aa-f644-4b07-b8c2-c3a1c4e2b33f", 0, "Banha", "7e4e9b07-db6f-4e82-abc4-5cef9c4cb638", "super_admin@shipping.com", false, "Aya Ahmed Mahmoud", false, null, "SUPER_ADMIN@SHIPPING.COM", "SUPERADMIN", "AQAAAAIAAYagAAAAEIIHy0pwsmYreDUQasCGIOF5qP6ABtpu6qW5CxlOEf6SP45d4btuy8QYgssrnYHo6A==", "01090370531", false, "96a8dd8b-952c-4823-b9d9-0e25f5b10b4e", true, false, "SuperAdmin" },
                    { "bc97e5df-6158-4bff-9aac-55171142b2d7", 0, "Tanta", "50665093-d9e7-4299-97da-e246843fdb1d", "representative@shipping.com", false, "Mohammed Ahmed", false, null, "REPRESENTATIVE@SHIPPING.COM", "REPRESENTATIVE", "AQAAAAIAAYagAAAAEK5KLlGx/aRhLEl7t9PPl2WqGAZjomfiIV6RgNI9Ux5ZUfjIVx5KDf04KtiR/b8HlA==", "01015226007", false, "e899cca6-392d-4d99-8c43-0bae5e9cea04", true, false, "Representative" }
                });

            migrationBuilder.InsertData(
                table: "Branches",
                columns: new[] { "Id", "Date", "Name", "Status" },
                values: new object[] { (byte)1, new DateTime(2023, 6, 24, 15, 40, 54, 750, DateTimeKind.Local).AddTicks(2941), "Main Branch", true });

            migrationBuilder.InsertData(
                table: "Privileges",
                columns: new[] { "Id", "ArabicName", "Name" },
                values: new object[,]
                {
                    { (byte)1, "الصلاحيات", "Privileges" },
                    { (byte)2, "الاعدادات", "Settings" },
                    { (byte)3, "البنوك", "Banks" },
                    { (byte)4, "الخزن", "safes" },
                    { (byte)5, "الافرع", "Branches" },
                    { (byte)6, "الموظفين", "Employees" },
                    { (byte)7, "التجار", "Traders" },
                    { (byte)8, "المناديب", "Representatives" },
                    { (byte)9, "المحافظات", "States" },
                    { (byte)10, "المدن", "Cities" },
                    { (byte)11, "الطلبات", "Orders" },
                    { (byte)12, "الحسابات", "Calculations" },
                    { (byte)13, "تقارير الطلبات", "OrdersReports" }
                });

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "DefaultWeight", "OverCostPerKG", "VillageShipingCost" },
                values: new object[] { (byte)1, 0.0, 0.0, 0.0 });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "Id", "Name", "Status" },
                values: new object[] { (byte)1, "Main State", true });

            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[,]
                {
                    { 1, "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier", "a00237aa-f644-4b07-b8c2-c3a1c4e2b33f", "a00237aa-f644-4b07-b8c2-c3a1c4e2b33f" },
                    { 2, "http://schemas.microsoft.com/ws/2008/06/identity/claims/userdata", "SuperAdmin", "a00237aa-f644-4b07-b8c2-c3a1c4e2b33f" },
                    { 3, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "16676d47-ec18-4a70-9dcf-2285e7ae7fbc", "a00237aa-f644-4b07-b8c2-c3a1c4e2b33f" },
                    { 4, "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier", "56b84096-f76d-479c-b994-0b59d5b0407d", "56b84096-f76d-479c-b994-0b59d5b0407d" },
                    { 5, "http://schemas.microsoft.com/ws/2008/06/identity/claims/userdata", "Trader", "56b84096-f76d-479c-b994-0b59d5b0407d" },
                    { 6, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "Trader", "56b84096-f76d-479c-b994-0b59d5b0407d" },
                    { 7, "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier", "bc97e5df-6158-4bff-9aac-55171142b2d7", "bc97e5df-6158-4bff-9aac-55171142b2d7" },
                    { 8, "http://schemas.microsoft.com/ws/2008/06/identity/claims/userdata", "Representative", "bc97e5df-6158-4bff-9aac-55171142b2d7" },
                    { 9, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "Representative", "bc97e5df-6158-4bff-9aac-55171142b2d7" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "16676d47-ec18-4a70-9dcf-2285e7ae7fbc", "a00237aa-f644-4b07-b8c2-c3a1c4e2b33f" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name", "ShipingCost", "StateId", "Status" },
                values: new object[] { 1, "Main City", 50.0, (byte)1, true });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "ApplicationUserId", "BranchId", "Date", "RoleId" },
                values: new object[] { "a00237aa-f644-4b07-b8c2-c3a1c4e2b33f", "a00237aa-f644-4b07-b8c2-c3a1c4e2b33f", (byte)1, new DateTime(2023, 6, 24, 15, 40, 55, 12, DateTimeKind.Local).AddTicks(466), "16676d47-ec18-4a70-9dcf-2285e7ae7fbc" });

            migrationBuilder.InsertData(
                table: "Representatives",
                columns: new[] { "Id", "ApplicationUserId", "BranchId", "CompanyOrderRatio", "Date", "DiscountType" },
                values: new object[] { "bc97e5df-6158-4bff-9aac-55171142b2d7", "bc97e5df-6158-4bff-9aac-55171142b2d7", (byte)1, 50.0, new DateTime(2023, 6, 24, 15, 40, 55, 559, DateTimeKind.Local).AddTicks(626), 1 });

            migrationBuilder.InsertData(
                table: "Role_Privileges",
                columns: new[] { "Id", "AddPermission", "DeletePermission", "EditPermission", "PrivilegeId", "RoleId", "ViewPermission" },
                values: new object[,]
                {
                    { 1, true, true, true, (byte)1, "16676d47-ec18-4a70-9dcf-2285e7ae7fbc", true },
                    { 2, true, true, true, (byte)2, "16676d47-ec18-4a70-9dcf-2285e7ae7fbc", true },
                    { 3, true, true, true, (byte)3, "16676d47-ec18-4a70-9dcf-2285e7ae7fbc", true },
                    { 4, true, true, true, (byte)4, "16676d47-ec18-4a70-9dcf-2285e7ae7fbc", true },
                    { 5, true, true, true, (byte)5, "16676d47-ec18-4a70-9dcf-2285e7ae7fbc", true },
                    { 6, true, true, true, (byte)6, "16676d47-ec18-4a70-9dcf-2285e7ae7fbc", true },
                    { 7, true, true, true, (byte)7, "16676d47-ec18-4a70-9dcf-2285e7ae7fbc", true },
                    { 8, true, true, true, (byte)8, "16676d47-ec18-4a70-9dcf-2285e7ae7fbc", true },
                    { 9, true, true, true, (byte)9, "16676d47-ec18-4a70-9dcf-2285e7ae7fbc", true },
                    { 10, true, true, true, (byte)10, "16676d47-ec18-4a70-9dcf-2285e7ae7fbc", true },
                    { 11, true, true, true, (byte)11, "16676d47-ec18-4a70-9dcf-2285e7ae7fbc", true },
                    { 12, true, true, true, (byte)12, "16676d47-ec18-4a70-9dcf-2285e7ae7fbc", true },
                    { 13, true, true, true, (byte)13, "16676d47-ec18-4a70-9dcf-2285e7ae7fbc", true }
                });

            migrationBuilder.InsertData(
                table: "RepresentativeStates",
                columns: new[] { "Id", "RepresentativeId", "StateId" },
                values: new object[] { 1, "bc97e5df-6158-4bff-9aac-55171142b2d7", (byte)1 });

            migrationBuilder.InsertData(
                table: "Traders",
                columns: new[] { "Id", "ApplicationUserId", "BranchId", "CityId", "Date", "RejectedOrderlossRatio", "StateId", "StoreName" },
                values: new object[] { "56b84096-f76d-479c-b994-0b59d5b0407d", "56b84096-f76d-479c-b994-0b59d5b0407d", (byte)1, 1, new DateTime(2023, 6, 24, 12, 40, 55, 280, DateTimeKind.Utc).AddTicks(3160), 10.0, (byte)1, "Main Store" });

            migrationBuilder.InsertData(
                table: "SpecialPackages",
                columns: new[] { "Id", "CityId", "ShippingCost", "StateId", "TraderId" },
                values: new object[] { 1, 1, 40.0, (byte)1, "56b84096-f76d-479c-b994-0b59d5b0407d" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Branches_Name",
                table: "Branches",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cities_StateId",
                table: "Cities",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ApplicationUserId",
                table: "Employees",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_BranchId",
                table: "Employees",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_RoleId",
                table: "Employees",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_BranchId",
                table: "Orders",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CityId",
                table: "Orders",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_RepresentativeID",
                table: "Orders",
                column: "RepresentativeID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ShippingTypeId",
                table: "Orders",
                column: "ShippingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_StateId",
                table: "Orders",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_TraderId",
                table: "Orders",
                column: "TraderId");

            migrationBuilder.CreateIndex(
                name: "IX_Representatives_ApplicationUserId",
                table: "Representatives",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Representatives_BranchId",
                table: "Representatives",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_RepresentativeStates_RepresentativeId",
                table: "RepresentativeStates",
                column: "RepresentativeId");

            migrationBuilder.CreateIndex(
                name: "IX_RepresentativeStates_StateId",
                table: "RepresentativeStates",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Role_Privileges_PrivilegeId",
                table: "Role_Privileges",
                column: "PrivilegeId");

            migrationBuilder.CreateIndex(
                name: "IX_Role_Privileges_RoleId",
                table: "Role_Privileges",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_ShippingTypes_Name",
                table: "ShippingTypes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SpecialPackages_CityId",
                table: "SpecialPackages",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialPackages_StateId",
                table: "SpecialPackages",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialPackages_TraderId",
                table: "SpecialPackages",
                column: "TraderId");

            migrationBuilder.CreateIndex(
                name: "IX_States_Name",
                table: "States",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Traders_ApplicationUserId",
                table: "Traders",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Traders_BranchId",
                table: "Traders",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Traders_CityId",
                table: "Traders",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Traders_StateId",
                table: "Traders",
                column: "StateId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "RepresentativeStates");

            migrationBuilder.DropTable(
                name: "Role_Privileges");

            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.DropTable(
                name: "SpecialPackages");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Privileges");

            migrationBuilder.DropTable(
                name: "Representatives");

            migrationBuilder.DropTable(
                name: "ShippingTypes");

            migrationBuilder.DropTable(
                name: "Traders");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Branches");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "States");
        }
    }
}
