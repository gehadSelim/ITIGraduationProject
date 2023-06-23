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
        public ShippingTypeReadDTO ShippingType { get; set; } = new ShippingTypeReadDTO();
        public string ClientName { get; set; } = string.Empty;
        public string Phone1 { get; set; } = string.Empty;
        public string? Phone2 { get; set; }
        public string Email { get; set; } = string.Empty;
        public CityReadSimpleDto City { get; set; } = new CityReadSimpleDto();
        public StateReadSimpleDTO State { get; set; } = new StateReadSimpleDTO();
        public PaymentType PaymentType { get; set; }
        public BranchReadSimpleDTO Branch { get; set; } = new BranchReadSimpleDTO();
        public string AdressDetails { get; set; } = string.Empty;
        public bool IsVillage { get; set; } = false;
        public double OrderShipingCost { get; set; }
        public double OrderCost { get; set; }
        public double TotalCost { get; set; }
        public double TotalWeight { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public TraderSimpleReadDTO Trader { get; set; } = new TraderSimpleReadDTO();
        public RepresentativeSimpleReadDTO Representative { get; set; } = new RepresentativeSimpleReadDTO();
        public string Comments { get; set; } = string.Empty;
        public OrderStatus OrderStatus { get; set; } = OrderStatus.New;
        public virtual ICollection<OrderItemReadDto> OrderItems { get; set; } = new HashSet<OrderItemReadDto>();

    }
}
