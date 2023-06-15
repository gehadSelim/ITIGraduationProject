using graduationProject.Shared.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace graduationProject.DAL.Data.Models
{
    public class Order
    {
        public int Id { get; set; }
        public OrderType OrderType { get; set; }

        [ForeignKey("ShippingType")]
        public byte ShippingTypeId { get; set; }
        public virtual ShippingType? ShippingType { get; set; }

        public string ClientName { get; set; } = string.Empty;

        public string Phone1 { get; set; } = string.Empty;

        public string? Phone2 { get; set; }

        public string Email { get; set; } = string.Empty;

        [ForeignKey("City")]
        public int CityId { get; set; }
        public virtual City? City { get; set; }

        [ForeignKey("State")]
        public byte StateId { get; set; }
        public virtual State? State { get; set; }

        public PaymentType PaymentType { get; set; }

        [ForeignKey("Branch")]
        public byte BranchId { get; set; }
        public virtual Branch? Branch { get; set; }

        public string AdressDetails { get; set; } = string.Empty;

        public bool IsVillage { get; set; } = false;

        public double OrderShipingCost { get; set; }
        public double OrderCost { get; set; }
        public double TotalCost { get; set; } 
        public double TotalWeight { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        [ForeignKey("Trader")]
        public string TraderId { get; set; } = string.Empty;
        public virtual Trader? Trader { get; set; }

        public OrderStatus OrderStatus { get; set; } = OrderStatus.New;

        [ForeignKey("Representative")]
        public string RepresentativeID { get; set; } = string.Empty;
        public virtual Representative? Representative { get; set; }
        public double? ReceivedCost { get; set; }
        public double? ReceivedShipingCost { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; } = new HashSet<OrderItem>();

    }
}
