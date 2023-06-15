using graduationProject.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graduationProject.Bl.DTOs
{
    public class OrderUpdateStatusAndReceivedCostDto
    {
        public int Id { get; set; }
        public double ReceivedCost { get; set; }
        public double ReceivedShippingCost { get; set; }
        public OrderStatus OrderStatus { get; set; }
    }
}
