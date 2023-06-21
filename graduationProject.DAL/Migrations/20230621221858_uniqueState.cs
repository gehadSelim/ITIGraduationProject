using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace graduationProject.DAL.Migrations
{
    /// <inheritdoc />
    public partial class uniqueState : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8f1824df-6511-4a98-82bf-aefd767a8d7f", "f2740347-5bb0-423c-a7b6-8a05265680ef" });

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: "f2740347-5bb0-423c-a7b6-8a05265680ef");

            migrationBuilder.DeleteData(
                table: "Representatives",
                keyColumn: "Id",
                keyValue: "5d529f11-6c5e-4d04-93ed-68eeaddddb1f");

            migrationBuilder.DeleteData(
                table: "Traders",
                keyColumn: "Id",
                keyValue: "1a98dee7-83f1-4a99-a794-af3a55b4c918");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8f1824df-6511-4a98-82bf-aefd767a8d7f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a98dee7-83f1-4a99-a794-af3a55b4c918");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5d529f11-6c5e-4d04-93ed-68eeaddddb1f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f2740347-5bb0-423c-a7b6-8a05265680ef");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Date", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "74e313b6-d787-426f-8d30-4cc46cfb0516", null, new DateTime(2023, 6, 22, 1, 18, 56, 794, DateTimeKind.Local).AddTicks(8869), "Role", "SuperAdmin", "SUPERADMIN" });

            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ClaimValue", "UserId" },
                values: new object[] { "8ef7e298-678e-4219-afe5-810372be9742", "8ef7e298-678e-4219-afe5-810372be9742" });

            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserId",
                value: "8ef7e298-678e-4219-afe5-810372be9742");

            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ClaimValue", "UserId" },
                values: new object[] { "74e313b6-d787-426f-8d30-4cc46cfb0516", "8ef7e298-678e-4219-afe5-810372be9742" });

            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ClaimValue", "UserId" },
                values: new object[] { "20a31569-c3dd-44c6-8a7b-ef649b720dc2", "20a31569-c3dd-44c6-8a7b-ef649b720dc2" });

            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 5,
                column: "UserId",
                value: "20a31569-c3dd-44c6-8a7b-ef649b720dc2");

            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 6,
                column: "UserId",
                value: "20a31569-c3dd-44c6-8a7b-ef649b720dc2");

            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ClaimValue", "UserId" },
                values: new object[] { "e27be157-e95c-45d6-bdbb-ccd6cf8d5dc6", "e27be157-e95c-45d6-bdbb-ccd6cf8d5dc6" });

            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 8,
                column: "UserId",
                value: "e27be157-e95c-45d6-bdbb-ccd6cf8d5dc6");

            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 9,
                column: "UserId",
                value: "e27be157-e95c-45d6-bdbb-ccd6cf8d5dc6");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "20a31569-c3dd-44c6-8a7b-ef649b720dc2", 0, "Banha", "207832c9-8e64-4e04-beef-f94d40045c52", "trader@shipping.com", false, "Ahmed Khaled", false, null, "TRADER@SHIPPING.COM", "TRADER", "AQAAAAIAAYagAAAAEP72VlOSfZyRYi7ILnFC/OKJqtGNRF4aPKwBt73+K7i377a/bp7GfnOW1kz4XYjyDg==", "01556968642", false, "3d87e023-8c9c-401c-bbe1-21de52b9489c", true, false, "Trader" },
                    { "8ef7e298-678e-4219-afe5-810372be9742", 0, "Banha", "927c6d1a-119e-4636-b65e-9acdb6dfcf39", "super_admin@shipping.com", false, "Aya Ahmed Mahmoud", false, null, "SUPER_ADMIN@SHIPPING.COM", "SUPERADMIN", "AQAAAAIAAYagAAAAELlS4XOYOhiXT8qF8xB5Wb6CrZOO6gN4RjluPS3puZW1fdY5eFAbMe5R8KiL7ugyXg==", "01090370531", false, "b3f5cf3e-cd24-481a-ad08-46910f76e919", true, false, "SuperAdmin" },
                    { "e27be157-e95c-45d6-bdbb-ccd6cf8d5dc6", 0, "Tanta", "6f1dfcd3-41af-4a14-9726-398d02a3e211", "representative@shipping.com", false, "Mohammed Ahmed", false, null, "REPRESENTATIVE@SHIPPING.COM", "REPRESENTATIVE", "AQAAAAIAAYagAAAAEPL4iKZppr4lkwvqvmSfBPociG0h1yR49P1EvGFE7/SJ6KxSaJzmJ3r4pgLwiag69A==", "01015226007", false, "55496b5a-334f-4072-b12a-9988eaa62077", true, false, "Representative" }
                });

            migrationBuilder.UpdateData(
                table: "Branches",
                keyColumn: "Id",
                keyValue: (byte)1,
                column: "Date",
                value: new DateTime(2023, 6, 22, 1, 18, 56, 794, DateTimeKind.Local).AddTicks(9514));

            migrationBuilder.UpdateData(
                table: "RepresentativeStates",
                keyColumn: "Id",
                keyValue: 1,
                column: "RepresentativeId",
                value: "e27be157-e95c-45d6-bdbb-ccd6cf8d5dc6");

            migrationBuilder.UpdateData(
                table: "Role_Privileges",
                keyColumn: "Id",
                keyValue: 1,
                column: "RoleId",
                value: "74e313b6-d787-426f-8d30-4cc46cfb0516");

            migrationBuilder.UpdateData(
                table: "Role_Privileges",
                keyColumn: "Id",
                keyValue: 2,
                column: "RoleId",
                value: "74e313b6-d787-426f-8d30-4cc46cfb0516");

            migrationBuilder.UpdateData(
                table: "Role_Privileges",
                keyColumn: "Id",
                keyValue: 3,
                column: "RoleId",
                value: "74e313b6-d787-426f-8d30-4cc46cfb0516");

            migrationBuilder.UpdateData(
                table: "Role_Privileges",
                keyColumn: "Id",
                keyValue: 4,
                column: "RoleId",
                value: "74e313b6-d787-426f-8d30-4cc46cfb0516");

            migrationBuilder.UpdateData(
                table: "Role_Privileges",
                keyColumn: "Id",
                keyValue: 5,
                column: "RoleId",
                value: "74e313b6-d787-426f-8d30-4cc46cfb0516");

            migrationBuilder.UpdateData(
                table: "Role_Privileges",
                keyColumn: "Id",
                keyValue: 6,
                column: "RoleId",
                value: "74e313b6-d787-426f-8d30-4cc46cfb0516");

            migrationBuilder.UpdateData(
                table: "Role_Privileges",
                keyColumn: "Id",
                keyValue: 7,
                column: "RoleId",
                value: "74e313b6-d787-426f-8d30-4cc46cfb0516");

            migrationBuilder.UpdateData(
                table: "Role_Privileges",
                keyColumn: "Id",
                keyValue: 8,
                column: "RoleId",
                value: "74e313b6-d787-426f-8d30-4cc46cfb0516");

            migrationBuilder.UpdateData(
                table: "Role_Privileges",
                keyColumn: "Id",
                keyValue: 9,
                column: "RoleId",
                value: "74e313b6-d787-426f-8d30-4cc46cfb0516");

            migrationBuilder.UpdateData(
                table: "Role_Privileges",
                keyColumn: "Id",
                keyValue: 10,
                column: "RoleId",
                value: "74e313b6-d787-426f-8d30-4cc46cfb0516");

            migrationBuilder.UpdateData(
                table: "Role_Privileges",
                keyColumn: "Id",
                keyValue: 11,
                column: "RoleId",
                value: "74e313b6-d787-426f-8d30-4cc46cfb0516");

            migrationBuilder.UpdateData(
                table: "Role_Privileges",
                keyColumn: "Id",
                keyValue: 12,
                column: "RoleId",
                value: "74e313b6-d787-426f-8d30-4cc46cfb0516");

            migrationBuilder.UpdateData(
                table: "Role_Privileges",
                keyColumn: "Id",
                keyValue: 13,
                column: "RoleId",
                value: "74e313b6-d787-426f-8d30-4cc46cfb0516");

            migrationBuilder.UpdateData(
                table: "SpecialPackages",
                keyColumn: "Id",
                keyValue: 1,
                column: "TraderId",
                value: "20a31569-c3dd-44c6-8a7b-ef649b720dc2");

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "74e313b6-d787-426f-8d30-4cc46cfb0516", "8ef7e298-678e-4219-afe5-810372be9742" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "ApplicationUserId", "BranchId", "Date", "RoleId" },
                values: new object[] { "8ef7e298-678e-4219-afe5-810372be9742", "8ef7e298-678e-4219-afe5-810372be9742", (byte)1, new DateTime(2023, 6, 22, 1, 18, 56, 967, DateTimeKind.Local).AddTicks(6068), "74e313b6-d787-426f-8d30-4cc46cfb0516" });

            migrationBuilder.InsertData(
                table: "Representatives",
                columns: new[] { "Id", "ApplicationUserId", "BranchId", "CompanyOrderRatio", "Date", "DiscountType" },
                values: new object[] { "e27be157-e95c-45d6-bdbb-ccd6cf8d5dc6", "e27be157-e95c-45d6-bdbb-ccd6cf8d5dc6", (byte)1, 50.0, new DateTime(2023, 6, 22, 1, 18, 57, 333, DateTimeKind.Local).AddTicks(2291), 1 });

            migrationBuilder.InsertData(
                table: "Traders",
                columns: new[] { "Id", "ApplicationUserId", "BranchId", "CityId", "Date", "RejectedOrderlossRatio", "StateId", "StoreName" },
                values: new object[] { "20a31569-c3dd-44c6-8a7b-ef649b720dc2", "20a31569-c3dd-44c6-8a7b-ef649b720dc2", (byte)1, 1, new DateTime(2023, 6, 21, 22, 18, 57, 162, DateTimeKind.Utc).AddTicks(6910), 10.0, (byte)1, "Main Store" });

            
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_States_Name",
                table: "States");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "74e313b6-d787-426f-8d30-4cc46cfb0516", "8ef7e298-678e-4219-afe5-810372be9742" });

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: "8ef7e298-678e-4219-afe5-810372be9742");

            migrationBuilder.DeleteData(
                table: "Representatives",
                keyColumn: "Id",
                keyValue: "e27be157-e95c-45d6-bdbb-ccd6cf8d5dc6");

            migrationBuilder.DeleteData(
                table: "Traders",
                keyColumn: "Id",
                keyValue: "20a31569-c3dd-44c6-8a7b-ef649b720dc2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "74e313b6-d787-426f-8d30-4cc46cfb0516");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "20a31569-c3dd-44c6-8a7b-ef649b720dc2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8ef7e298-678e-4219-afe5-810372be9742");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e27be157-e95c-45d6-bdbb-ccd6cf8d5dc6");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Date", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "8f1824df-6511-4a98-82bf-aefd767a8d7f", null, new DateTime(2023, 6, 22, 0, 22, 9, 413, DateTimeKind.Local).AddTicks(9509), "Role", "SuperAdmin", "SUPERADMIN" });

            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ClaimValue", "UserId" },
                values: new object[] { "f2740347-5bb0-423c-a7b6-8a05265680ef", "f2740347-5bb0-423c-a7b6-8a05265680ef" });

            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserId",
                value: "f2740347-5bb0-423c-a7b6-8a05265680ef");

            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ClaimValue", "UserId" },
                values: new object[] { "8f1824df-6511-4a98-82bf-aefd767a8d7f", "f2740347-5bb0-423c-a7b6-8a05265680ef" });

            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ClaimValue", "UserId" },
                values: new object[] { "1a98dee7-83f1-4a99-a794-af3a55b4c918", "1a98dee7-83f1-4a99-a794-af3a55b4c918" });

            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 5,
                column: "UserId",
                value: "1a98dee7-83f1-4a99-a794-af3a55b4c918");

            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 6,
                column: "UserId",
                value: "1a98dee7-83f1-4a99-a794-af3a55b4c918");

            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ClaimValue", "UserId" },
                values: new object[] { "5d529f11-6c5e-4d04-93ed-68eeaddddb1f", "5d529f11-6c5e-4d04-93ed-68eeaddddb1f" });

            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 8,
                column: "UserId",
                value: "5d529f11-6c5e-4d04-93ed-68eeaddddb1f");

            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 9,
                column: "UserId",
                value: "5d529f11-6c5e-4d04-93ed-68eeaddddb1f");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1a98dee7-83f1-4a99-a794-af3a55b4c918", 0, "Banha", "be505060-036c-4b6c-ae3d-0b3f723bdbf7", "trader@shipping.com", false, "Ahmed Khaled", false, null, "TRADER@SHIPPING.COM", "TRADER", "AQAAAAIAAYagAAAAEGkt2cJ9fHkDm1CkgpMo15xzTrsK49B7KTLRrINCbhGNaJMYH29WtjZb8dC925GAzg==", "01556968642", false, "a1f47f45-70d7-487c-9f67-11e1f019b25e", true, false, "Trader" },
                    { "5d529f11-6c5e-4d04-93ed-68eeaddddb1f", 0, "Tanta", "78aed8c1-5483-4550-959a-1171afa62b3f", "representative@shipping.com", false, "Mohammed Ahmed", false, null, "REPRESENTATIVE@SHIPPING.COM", "REPRESENTATIVE", "AQAAAAIAAYagAAAAENBscMMcrs9OhR6CXopM8GXlJgQfmo31seAXgVYqZEl/NHmlP1+1U+vQTqazpgU5Aw==", "01015226007", false, "8ecc5a20-d4c6-45ae-a3e9-aa687fb5462e", true, false, "Representative" },
                    { "f2740347-5bb0-423c-a7b6-8a05265680ef", 0, "Banha", "da79ee37-470f-4881-ad07-3ada3ca41427", "super_admin@shipping.com", false, "Aya Ahmed Mahmoud", false, null, "SUPER_ADMIN@SHIPPING.COM", "SUPERADMIN", "AQAAAAIAAYagAAAAEB3BjPEkQLkcYp+E+OCA6Aq1EioOfVvJyyeJXmBlaHoQRXYPcxoaC6hkhbjy3pIDfA==", "01090370531", false, "e829acea-f82b-41b8-857a-3340556d5f2a", true, false, "SuperAdmin" }
                });

            migrationBuilder.UpdateData(
                table: "Branches",
                keyColumn: "Id",
                keyValue: (byte)1,
                column: "Date",
                value: new DateTime(2023, 6, 22, 0, 22, 9, 414, DateTimeKind.Local).AddTicks(698));

            migrationBuilder.UpdateData(
                table: "RepresentativeStates",
                keyColumn: "Id",
                keyValue: 1,
                column: "RepresentativeId",
                value: "5d529f11-6c5e-4d04-93ed-68eeaddddb1f");

            migrationBuilder.UpdateData(
                table: "Role_Privileges",
                keyColumn: "Id",
                keyValue: 1,
                column: "RoleId",
                value: "8f1824df-6511-4a98-82bf-aefd767a8d7f");

            migrationBuilder.UpdateData(
                table: "Role_Privileges",
                keyColumn: "Id",
                keyValue: 2,
                column: "RoleId",
                value: "8f1824df-6511-4a98-82bf-aefd767a8d7f");

            migrationBuilder.UpdateData(
                table: "Role_Privileges",
                keyColumn: "Id",
                keyValue: 3,
                column: "RoleId",
                value: "8f1824df-6511-4a98-82bf-aefd767a8d7f");

            migrationBuilder.UpdateData(
                table: "Role_Privileges",
                keyColumn: "Id",
                keyValue: 4,
                column: "RoleId",
                value: "8f1824df-6511-4a98-82bf-aefd767a8d7f");

            migrationBuilder.UpdateData(
                table: "Role_Privileges",
                keyColumn: "Id",
                keyValue: 5,
                column: "RoleId",
                value: "8f1824df-6511-4a98-82bf-aefd767a8d7f");

            migrationBuilder.UpdateData(
                table: "Role_Privileges",
                keyColumn: "Id",
                keyValue: 6,
                column: "RoleId",
                value: "8f1824df-6511-4a98-82bf-aefd767a8d7f");

            migrationBuilder.UpdateData(
                table: "Role_Privileges",
                keyColumn: "Id",
                keyValue: 7,
                column: "RoleId",
                value: "8f1824df-6511-4a98-82bf-aefd767a8d7f");

            migrationBuilder.UpdateData(
                table: "Role_Privileges",
                keyColumn: "Id",
                keyValue: 8,
                column: "RoleId",
                value: "8f1824df-6511-4a98-82bf-aefd767a8d7f");

            migrationBuilder.UpdateData(
                table: "Role_Privileges",
                keyColumn: "Id",
                keyValue: 9,
                column: "RoleId",
                value: "8f1824df-6511-4a98-82bf-aefd767a8d7f");

            migrationBuilder.UpdateData(
                table: "Role_Privileges",
                keyColumn: "Id",
                keyValue: 10,
                column: "RoleId",
                value: "8f1824df-6511-4a98-82bf-aefd767a8d7f");

            migrationBuilder.UpdateData(
                table: "Role_Privileges",
                keyColumn: "Id",
                keyValue: 11,
                column: "RoleId",
                value: "8f1824df-6511-4a98-82bf-aefd767a8d7f");

            migrationBuilder.UpdateData(
                table: "Role_Privileges",
                keyColumn: "Id",
                keyValue: 12,
                column: "RoleId",
                value: "8f1824df-6511-4a98-82bf-aefd767a8d7f");

            migrationBuilder.UpdateData(
                table: "Role_Privileges",
                keyColumn: "Id",
                keyValue: 13,
                column: "RoleId",
                value: "8f1824df-6511-4a98-82bf-aefd767a8d7f");

            migrationBuilder.UpdateData(
                table: "SpecialPackages",
                keyColumn: "Id",
                keyValue: 1,
                column: "TraderId",
                value: "1a98dee7-83f1-4a99-a794-af3a55b4c918");

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "8f1824df-6511-4a98-82bf-aefd767a8d7f", "f2740347-5bb0-423c-a7b6-8a05265680ef" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "ApplicationUserId", "BranchId", "Date", "RoleId" },
                values: new object[] { "f2740347-5bb0-423c-a7b6-8a05265680ef", "f2740347-5bb0-423c-a7b6-8a05265680ef", (byte)1, new DateTime(2023, 6, 22, 0, 22, 9, 641, DateTimeKind.Local).AddTicks(5201), "8f1824df-6511-4a98-82bf-aefd767a8d7f" });

            migrationBuilder.InsertData(
                table: "Representatives",
                columns: new[] { "Id", "ApplicationUserId", "BranchId", "CompanyOrderRatio", "Date", "DiscountType" },
                values: new object[] { "5d529f11-6c5e-4d04-93ed-68eeaddddb1f", "5d529f11-6c5e-4d04-93ed-68eeaddddb1f", (byte)1, 50.0, new DateTime(2023, 6, 22, 0, 22, 9, 915, DateTimeKind.Local).AddTicks(7591), 1 });

            migrationBuilder.InsertData(
                table: "Traders",
                columns: new[] { "Id", "ApplicationUserId", "BranchId", "CityId", "Date", "RejectedOrderlossRatio", "StateId", "StoreName" },
                values: new object[] { "1a98dee7-83f1-4a99-a794-af3a55b4c918", "1a98dee7-83f1-4a99-a794-af3a55b4c918", (byte)1, 1, new DateTime(2023, 6, 21, 21, 22, 9, 760, DateTimeKind.Utc).AddTicks(5669), 10.0, (byte)1, "Main Store" });
        }
    }
}
