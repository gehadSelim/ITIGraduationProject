using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace graduationProject.DAL.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Date", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "76f97cfe-5d7c-458e-8793-d79cb95adf1d", null, new DateTime(2023, 6, 19, 23, 54, 32, 701, DateTimeKind.Local).AddTicks(9984), "Role", "SuperAdmin", "SUPERADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "04762fdf-381c-42a9-8296-b6271273cf6a", 0, "Tanta", "762918ec-8624-415d-b8cc-d83af445dc3a", "representative@shipping.com", false, "Mohammed Ahmed", false, null, "REPRESENTATIVE@SHIPPING.COM", "REPRESENTATIVE", "AQAAAAIAAYagAAAAEHRQ/0C6KTaj3cfaWimWD61eM5kCBbP6p6ZlFpLXaWbZ/JxT2VHfYip48O4YbXQMow==", "01015226007", false, "be866ccd-b4ce-4a42-81b2-e102ce04b343", true, false, "Representative" },
                    { "62dbfcab-3e25-42c7-8933-2cc7f43060f3", 0, "Banha", "b47c0a19-1beb-4660-a136-05b52413539c", "super_admin@shipping.com", false, "Aya Ahmed Mahmoud", false, null, "SUPER_ADMIN@SHIPPING.COM", "SUPERADMIN", "AQAAAAIAAYagAAAAEFLRvM4hSyelVqvQnvxH63np4XwFzPMdX2jJ55GxIv5Vl3eLPNEFjNCGwx2GGco7Sg==", "01090370531", false, "6ae169d0-f029-493c-adbe-ed0818a5a9a4", true, false, "SuperAdmin" },
                    { "e4cae211-a564-4b35-b217-665ce9fee092", 0, "Banha", "89735159-d56d-46da-aa3c-fee79ffe68c2", "trader@shipping.com", false, "Ahmed Khaled", false, null, "TRADER@SHIPPING.COM", "TRADER", "AQAAAAIAAYagAAAAEA5rHJ14q2U+/rhw1JhGK5NjaB55P1gy46tnyEDBrE0x4Ampnb/oJ1CHpFkdGAT26Q==", "01556968642", false, "8450c599-5e97-4559-92ab-0bbad65576ce", true, false, "Trader" }
                });

            migrationBuilder.InsertData(
                table: "Branches",
                columns: new[] { "Id", "Date", "Name", "Status" },
                values: new object[] { (byte)1, new DateTime(2023, 6, 19, 23, 54, 32, 702, DateTimeKind.Local).AddTicks(412), "Main Branch", true });

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
                    { 1, "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier", "62dbfcab-3e25-42c7-8933-2cc7f43060f3", "62dbfcab-3e25-42c7-8933-2cc7f43060f3" },
                    { 2, "http://schemas.microsoft.com/ws/2008/06/identity/claims/userdata", "SuperAdmin", "62dbfcab-3e25-42c7-8933-2cc7f43060f3" },
                    { 3, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "76f97cfe-5d7c-458e-8793-d79cb95adf1d", "62dbfcab-3e25-42c7-8933-2cc7f43060f3" },
                    { 4, "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier", "e4cae211-a564-4b35-b217-665ce9fee092", "e4cae211-a564-4b35-b217-665ce9fee092" },
                    { 5, "http://schemas.microsoft.com/ws/2008/06/identity/claims/userdata", "Trader", "e4cae211-a564-4b35-b217-665ce9fee092" },
                    { 6, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "Trader", "e4cae211-a564-4b35-b217-665ce9fee092" },
                    { 7, "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier", "04762fdf-381c-42a9-8296-b6271273cf6a", "04762fdf-381c-42a9-8296-b6271273cf6a" },
                    { 8, "http://schemas.microsoft.com/ws/2008/06/identity/claims/userdata", "Representative", "04762fdf-381c-42a9-8296-b6271273cf6a" },
                    { 9, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "Representative", "04762fdf-381c-42a9-8296-b6271273cf6a" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "76f97cfe-5d7c-458e-8793-d79cb95adf1d", "62dbfcab-3e25-42c7-8933-2cc7f43060f3" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name", "ShipingCost", "StateId" },
                values: new object[] { 1, "Main City", 50.0, (byte)1 });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "ApplicationUserId", "BranchId", "Date", "RoleId" },
                values: new object[] { "62dbfcab-3e25-42c7-8933-2cc7f43060f3", "62dbfcab-3e25-42c7-8933-2cc7f43060f3", (byte)1, new DateTime(2023, 6, 19, 23, 54, 32, 905, DateTimeKind.Local).AddTicks(6038), "76f97cfe-5d7c-458e-8793-d79cb95adf1d" });

            migrationBuilder.InsertData(
                table: "Representatives",
                columns: new[] { "Id", "ApplicationUserId", "BranchId", "CompanyOrderRatio", "Date", "DiscountType" },
                values: new object[] { "04762fdf-381c-42a9-8296-b6271273cf6a", "04762fdf-381c-42a9-8296-b6271273cf6a", (byte)1, 50.0, new DateTime(2023, 6, 19, 23, 54, 33, 341, DateTimeKind.Local).AddTicks(303), 1 });

            migrationBuilder.InsertData(
                table: "Role_Privileges",
                columns: new[] { "Id", "AddPermission", "DeletePermission", "EditPermission", "PrivilegeId", "RoleId", "ViewPermission" },
                values: new object[,]
                {
                    { 1, true, true, true, (byte)1, "76f97cfe-5d7c-458e-8793-d79cb95adf1d", true },
                    { 2, true, true, true, (byte)2, "76f97cfe-5d7c-458e-8793-d79cb95adf1d", true },
                    { 3, true, true, true, (byte)3, "76f97cfe-5d7c-458e-8793-d79cb95adf1d", true },
                    { 4, true, true, true, (byte)4, "76f97cfe-5d7c-458e-8793-d79cb95adf1d", true },
                    { 5, true, true, true, (byte)5, "76f97cfe-5d7c-458e-8793-d79cb95adf1d", true },
                    { 6, true, true, true, (byte)6, "76f97cfe-5d7c-458e-8793-d79cb95adf1d", true },
                    { 7, true, true, true, (byte)7, "76f97cfe-5d7c-458e-8793-d79cb95adf1d", true },
                    { 8, true, true, true, (byte)8, "76f97cfe-5d7c-458e-8793-d79cb95adf1d", true },
                    { 9, true, true, true, (byte)9, "76f97cfe-5d7c-458e-8793-d79cb95adf1d", true },
                    { 10, true, true, true, (byte)10, "76f97cfe-5d7c-458e-8793-d79cb95adf1d", true },
                    { 11, true, true, true, (byte)11, "76f97cfe-5d7c-458e-8793-d79cb95adf1d", true },
                    { 12, true, true, true, (byte)12, "76f97cfe-5d7c-458e-8793-d79cb95adf1d", true },
                    { 13, true, true, true, (byte)13, "76f97cfe-5d7c-458e-8793-d79cb95adf1d", true }
                });

            migrationBuilder.InsertData(
                table: "RepresentativeStates",
                columns: new[] { "Id", "RepresentativeId", "StateId" },
                values: new object[] { 1, "04762fdf-381c-42a9-8296-b6271273cf6a", (byte)1 });

            migrationBuilder.InsertData(
                table: "Traders",
                columns: new[] { "Id", "ApplicationUserId", "BranchId", "CityId", "Date", "RejectedOrderlossRatio", "StateId", "StoreName" },
                values: new object[] { "e4cae211-a564-4b35-b217-665ce9fee092", "e4cae211-a564-4b35-b217-665ce9fee092", (byte)1, 1, new DateTime(2023, 6, 19, 20, 54, 33, 136, DateTimeKind.Utc).AddTicks(9514), 10.0, (byte)1, "Main Store" });

            migrationBuilder.InsertData(
                table: "SpecialPackages",
                columns: new[] { "Id", "CityId", "ShippingCost", "StateId", "TraderId" },
                values: new object[] { 1, 1, 40.0, (byte)1, "e4cae211-a564-4b35-b217-665ce9fee092" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "76f97cfe-5d7c-458e-8793-d79cb95adf1d", "62dbfcab-3e25-42c7-8933-2cc7f43060f3" });

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: "62dbfcab-3e25-42c7-8933-2cc7f43060f3");

            migrationBuilder.DeleteData(
                table: "RepresentativeStates",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Role_Privileges",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Role_Privileges",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Role_Privileges",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Role_Privileges",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Role_Privileges",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Role_Privileges",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Role_Privileges",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Role_Privileges",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Role_Privileges",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Role_Privileges",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Role_Privileges",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Role_Privileges",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Role_Privileges",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: (byte)1);

            migrationBuilder.DeleteData(
                table: "SpecialPackages",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "76f97cfe-5d7c-458e-8793-d79cb95adf1d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "62dbfcab-3e25-42c7-8933-2cc7f43060f3");

            migrationBuilder.DeleteData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: (byte)1);

            migrationBuilder.DeleteData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: (byte)2);

            migrationBuilder.DeleteData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: (byte)3);

            migrationBuilder.DeleteData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: (byte)4);

            migrationBuilder.DeleteData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: (byte)5);

            migrationBuilder.DeleteData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: (byte)6);

            migrationBuilder.DeleteData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: (byte)7);

            migrationBuilder.DeleteData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: (byte)8);

            migrationBuilder.DeleteData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: (byte)9);

            migrationBuilder.DeleteData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: (byte)10);

            migrationBuilder.DeleteData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: (byte)11);

            migrationBuilder.DeleteData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: (byte)12);

            migrationBuilder.DeleteData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: (byte)13);

            migrationBuilder.DeleteData(
                table: "Representatives",
                keyColumn: "Id",
                keyValue: "04762fdf-381c-42a9-8296-b6271273cf6a");

            migrationBuilder.DeleteData(
                table: "Traders",
                keyColumn: "Id",
                keyValue: "e4cae211-a564-4b35-b217-665ce9fee092");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "04762fdf-381c-42a9-8296-b6271273cf6a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e4cae211-a564-4b35-b217-665ce9fee092");

            migrationBuilder.DeleteData(
                table: "Branches",
                keyColumn: "Id",
                keyValue: (byte)1);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: (byte)1);
        }
    }
}
