using graduationProject.Shared.Enums;

namespace graduationProject.Bl.DTOs.OrderDto
{
    public class OrderUpdateStatusOnlyDto
    {
        public int Id { get; set; }
        public OrderStatus OrderStatus { get; set; }
    }
}
