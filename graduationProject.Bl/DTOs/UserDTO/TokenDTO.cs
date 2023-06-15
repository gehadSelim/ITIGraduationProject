using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graduationProject.Bl.DTOs
{
    public record TokenDTO(string token, string userName, string userId, DateTime expireDate);
}
