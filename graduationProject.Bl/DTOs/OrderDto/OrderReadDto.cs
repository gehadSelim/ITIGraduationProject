using graduationProject.Bl.DTOs.OrderItem;
using graduationProject.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graduationProject.Bl.DTOs.OrderDto
{
    public class OrderReadDto
    {
        public int Id { get; set; }
        public OrderType OrderType { get; set; }
        public byte ShippingTypeId { get; set; }
        public string ClientName { get; set; } = string.Empty;
        public string Phone1 { get; set; } = string.Empty;
        public string? Phone2 { get; set; }
        public string Email { get; set; } = string.Empty;
        public int CityId { get; set; }
        public byte StateId { get; set; }
        public PaymentType PaymentType { get; set; }
        public byte BranchId { get; set; }
        public string AdressDetails { get; set; } = string.Empty;
        public bool IsVillage { get; set; } = false;
        public double OrderShipingCost { get; set; }
        public double OrderCost { get; set; }
        public double TotalCost { get; set; }
        public double TotalWeight { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public string TraderId { get; set; } = string.Empty;
        public string RepresentativeID { get; set; } = string.Empty;

        public OrderStatus OrderStatus { get; set; } = OrderStatus.New;
        public virtual ICollection<OrderItemReadDto> OrderItems { get; set; } = new HashSet<OrderItemReadDto>();

    }
}
