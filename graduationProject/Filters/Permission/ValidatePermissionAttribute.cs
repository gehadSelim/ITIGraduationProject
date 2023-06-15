using graduationProject.Bl.DTOs;
using graduationProject.Bl.Managers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security;
using System.Security.Claims;
using System.Text;

namespace graduationProject.Filters
{
    public class ValidatePermissionAttribute : ActionFilterAttribute
    {
        private readonly IConfiguration _configuration;
        private readonly IEmployeeManager _employeeManger;

        public ValidatePermissionAttribute(IEmployeeManager employeeManager, IConfiguration configuration)
        {
            _employeeManger = employeeManager;
            _configuration = configuration;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var method = context.HttpContext.Request.Method.ToLower();
            var controllerName = context.Controller.GetType().Name.ToLower();
            string operation = string.Empty;

            RolePrivilegesReadDTO permission = new RolePrivilegesReadDTO();
            var token = getToken(context);
            var userId = GetUserId(token);
            int permissionIndex = 0;
            if (!string.IsNullOrEmpty(userId))
            {
                var permissions = _employeeManger.GetRolePrivilegesByUserId(userId).Result;
                if (permissions != null)
                {
                    permission = permissions.Where(p => controllerName.Contains(p.PermissionName.ToLower())).FirstOrDefault();
                }
            }
            switch (method)
            {
                case "post":
                    permissionIndex = 0;
                    operation = "Add";
                    break;
                case "get":
                    permissionIndex = 1;
                    operation = "View";
                    break;
                case "put":
                    permissionIndex = 2;
                    operation = "Edit";
                    break;
                case "delete":
                    permissionIndex = 3;
                    operation = "Delete";
                    break;
            }
            if (permission == null || permission.Permissions[permissionIndex] == false)
            {
                context.ModelState.AddModelError(controllerName, $"not authorized to {operation} {permission?.PermissionName}");
                context.Result = new BadRequestObjectResult(context.ModelState);
            }
        }

        string getToken(ActionExecutingContext context)
        {
            return context.HttpContext.Request.Headers["Authorization"][0].Split(" ")[1];
        }


        string GetUserId(string token)
        {
            var secret = _configuration["SecretKey"] ?? string.Empty;
            var key = Encoding.ASCII.GetBytes(secret);
            var handler = new JwtSecurityTokenHandler();
            var validations = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false
            };
            var userId = handler.ValidateToken(token, validations, out var tokenSecure).Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).Select(c => c.Value).ElementAt(0);
            return userId;
        }
    }
}
