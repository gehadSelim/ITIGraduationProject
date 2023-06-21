using graduationProject.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graduationProject.Bl.DTOs.OrderDto
{
    public class OrderPaymentTypeAndOrderTypeDto
    {
        public List<EnumValue>? PaymentType { get; set; }
        public List<EnumValue>? OrderType { get; set; }
    }
}
