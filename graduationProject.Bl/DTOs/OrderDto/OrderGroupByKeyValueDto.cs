using graduationProject.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graduationProject.Bl.DTOs.OrderDto
{
    public class OrderGroupByKeyValueDto
    {
        public OrderStatus OrderStatus { get; set; }
        public int NumberOrder { get; set; }
    }
}
