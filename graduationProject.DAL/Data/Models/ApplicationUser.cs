using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graduationProject.DAL;

public class ApplicationUser : IdentityUser
{
    public bool Status { get; set; } = true;
    public string FullName { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;

}

