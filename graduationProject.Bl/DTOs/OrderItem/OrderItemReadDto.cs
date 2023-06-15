using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graduationProject.Bl.DTOs.OrderItem
{
    public class OrderItemReadDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public double ProductPrice { get; set; }
        public double ProductWeight { get; set; }
        public int ProductQuntity { get; set; }
    }
}
