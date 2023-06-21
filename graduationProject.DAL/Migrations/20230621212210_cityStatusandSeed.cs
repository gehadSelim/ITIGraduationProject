using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace graduationProject.DAL.Migrations
{
    /// <inheritdoc />
    public partial class cityStatusandSeed : Migration
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
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    BranchId = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
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
                        onDelete: ReferentialAction.NoAction);
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
                    BranchId = table.Column<byte>(type: "tinyint", nullable: false)
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
                        onDelete: ReferentialAction.NoAction);
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
                    BranchId = table.Column<byte>(type: "tinyint", nullable: false)
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
                        onDelete: ReferentialAction.NoAction);
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
                    BranchId = table.Column<byte>(type: "tinyint", nullable: false),
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
                        onDelete: ReferentialAction.NoAction);
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
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

            migrationBuilder.CreateIndex(
                name: "IX_States_Name",
                table: "States",
                column: "Name",
                unique: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Date", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "8f1824df-6511-4a98-82bf-aefd767a8d7f", null, new DateTime(2023, 6, 22, 0, 22, 9, 413, DateTimeKind.Local).AddTicks(9509), "Role", "SuperAdmin", "SUPERADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1a98dee7-83f1-4a99-a794-af3a55b4c918", 0, "Banha", "be505060-036c-4b6c-ae3d-0b3f723bdbf7", "trader@shipping.com", false, "Ahmed Khaled", false, null, "TRADER@SHIPPING.COM", "TRADER", "AQAAAAIAAYagAAAAEGkt2cJ9fHkDm1CkgpMo15xzTrsK49B7KTLRrINCbhGNaJMYH29WtjZb8dC925GAzg==", "01556968642", false, "a1f47f45-70d7-487c-9f67-11e1f019b25e", true, false, "Trader" },
                    { "5d529f11-6c5e-4d04-93ed-68eeaddddb1f", 0, "Tanta", "78aed8c1-5483-4550-959a-1171afa62b3f", "representative@shipping.com", false, "Mohammed Ahmed", false, null, "REPRESENTATIVE@SHIPPING.COM", "REPRESENTATIVE", "AQAAAAIAAYagAAAAENBscMMcrs9OhR6CXopM8GXlJgQfmo31seAXgVYqZEl/NHmlP1+1U+vQTqazpgU5Aw==", "01015226007", false, "8ecc5a20-d4c6-45ae-a3e9-aa687fb5462e", true, false, "Representative" },
                    { "f2740347-5bb0-423c-a7b6-8a05265680ef", 0, "Banha", "da79ee37-470f-4881-ad07-3ada3ca41427", "super_admin@shipping.com", false, "Aya Ahmed Mahmoud", false, null, "SUPER_ADMIN@SHIPPING.COM", "SUPERADMIN", "AQAAAAIAAYagAAAAEB3BjPEkQLkcYp+E+OCA6Aq1EioOfVvJyyeJXmBlaHoQRXYPcxoaC6hkhbjy3pIDfA==", "01090370531", false, "e829acea-f82b-41b8-857a-3340556d5f2a", true, false, "SuperAdmin" }
                });

            migrationBuilder.InsertData(
                table: "Branches",
                columns: new[] { "Id", "Date", "Name", "Status" },
                values: new object[] { (byte)1, new DateTime(2023, 6, 22, 0, 22, 9, 414, DateTimeKind.Local).AddTicks(698), "Main Branch", true });

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
                    { 1, "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier", "f2740347-5bb0-423c-a7b6-8a05265680ef", "f2740347-5bb0-423c-a7b6-8a05265680ef" },
                    { 2, "http://schemas.microsoft.com/ws/2008/06/identity/claims/userdata", "SuperAdmin", "f2740347-5bb0-423c-a7b6-8a05265680ef" },
                    { 3, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "8f1824df-6511-4a98-82bf-aefd767a8d7f", "f2740347-5bb0-423c-a7b6-8a05265680ef" },
                    { 4, "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier", "1a98dee7-83f1-4a99-a794-af3a55b4c918", "1a98dee7-83f1-4a99-a794-af3a55b4c918" },
                    { 5, "http://schemas.microsoft.com/ws/2008/06/identity/claims/userdata", "Trader", "1a98dee7-83f1-4a99-a794-af3a55b4c918" },
                    { 6, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "Trader", "1a98dee7-83f1-4a99-a794-af3a55b4c918" },
                    { 7, "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier", "5d529f11-6c5e-4d04-93ed-68eeaddddb1f", "5d529f11-6c5e-4d04-93ed-68eeaddddb1f" },
                    { 8, "http://schemas.microsoft.com/ws/2008/06/identity/claims/userdata", "Representative", "5d529f11-6c5e-4d04-93ed-68eeaddddb1f" },
                    { 9, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "Representative", "5d529f11-6c5e-4d04-93ed-68eeaddddb1f" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "8f1824df-6511-4a98-82bf-aefd767a8d7f", "f2740347-5bb0-423c-a7b6-8a05265680ef" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name", "ShipingCost", "StateId", "Status" },
                values: new object[] { 1, "Main City", 50.0, (byte)1, true });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "ApplicationUserId", "BranchId", "Date", "RoleId" },
                values: new object[] { "f2740347-5bb0-423c-a7b6-8a05265680ef", "f2740347-5bb0-423c-a7b6-8a05265680ef", (byte)1, new DateTime(2023, 6, 22, 0, 22, 9, 641, DateTimeKind.Local).AddTicks(5201), "8f1824df-6511-4a98-82bf-aefd767a8d7f" });

            migrationBuilder.InsertData(
                table: "Representatives",
                columns: new[] { "Id", "ApplicationUserId", "BranchId", "CompanyOrderRatio", "Date", "DiscountType" },
                values: new object[] { "5d529f11-6c5e-4d04-93ed-68eeaddddb1f", "5d529f11-6c5e-4d04-93ed-68eeaddddb1f", (byte)1, 50.0, new DateTime(2023, 6, 22, 0, 22, 9, 915, DateTimeKind.Local).AddTicks(7591), 1 });

            migrationBuilder.InsertData(
                table: "Role_Privileges",
                columns: new[] { "Id", "AddPermission", "DeletePermission", "EditPermission", "PrivilegeId", "RoleId", "ViewPermission" },
                values: new object[,]
                {
                    { 1, true, true, true, (byte)1, "8f1824df-6511-4a98-82bf-aefd767a8d7f", true },
                    { 2, true, true, true, (byte)2, "8f1824df-6511-4a98-82bf-aefd767a8d7f", true },
                    { 3, true, true, true, (byte)3, "8f1824df-6511-4a98-82bf-aefd767a8d7f", true },
                    { 4, true, true, true, (byte)4, "8f1824df-6511-4a98-82bf-aefd767a8d7f", true },
                    { 5, true, true, true, (byte)5, "8f1824df-6511-4a98-82bf-aefd767a8d7f", true },
                    { 6, true, true, true, (byte)6, "8f1824df-6511-4a98-82bf-aefd767a8d7f", true },
                    { 7, true, true, true, (byte)7, "8f1824df-6511-4a98-82bf-aefd767a8d7f", true },
                    { 8, true, true, true, (byte)8, "8f1824df-6511-4a98-82bf-aefd767a8d7f", true },
                    { 9, true, true, true, (byte)9, "8f1824df-6511-4a98-82bf-aefd767a8d7f", true },
                    { 10, true, true, true, (byte)10, "8f1824df-6511-4a98-82bf-aefd767a8d7f", true },
                    { 11, true, true, true, (byte)11, "8f1824df-6511-4a98-82bf-aefd767a8d7f", true },
                    { 12, true, true, true, (byte)12, "8f1824df-6511-4a98-82bf-aefd767a8d7f", true },
                    { 13, true, true, true, (byte)13, "8f1824df-6511-4a98-82bf-aefd767a8d7f", true }
                });

            migrationBuilder.InsertData(
                table: "RepresentativeStates",
                columns: new[] { "Id", "RepresentativeId", "StateId" },
                values: new object[] { 1, "5d529f11-6c5e-4d04-93ed-68eeaddddb1f", (byte)1 });

            migrationBuilder.InsertData(
                table: "Traders",
                columns: new[] { "Id", "ApplicationUserId", "BranchId", "CityId", "Date", "RejectedOrderlossRatio", "StateId", "StoreName" },
                values: new object[] { "1a98dee7-83f1-4a99-a794-af3a55b4c918", "1a98dee7-83f1-4a99-a794-af3a55b4c918", (byte)1, 1, new DateTime(2023, 6, 21, 21, 22, 9, 760, DateTimeKind.Utc).AddTicks(5669), 10.0, (byte)1, "Main Store" });

            migrationBuilder.InsertData(
                table: "SpecialPackages",
                columns: new[] { "Id", "CityId", "ShippingCost", "StateId", "TraderId" },
                values: new object[] { 1, 1, 40.0, (byte)1, "1a98dee7-83f1-4a99-a794-af3a55b4c918" });

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

            migrationBuilder.DropIndex(
                name: "IX_States_Name",
                table: "States");
        }
    }
}
