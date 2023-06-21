using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graduationProject.Bl.DTOs
{
    public class EmployeeUpdateStatusDTO
    {
        public string Id { get; set; } = string.Empty;
        public bool Status { get; set; }
    }
}
