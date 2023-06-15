﻿using graduationProject.Shared.Enums;

namespace graduationProject.Bl.DTOs.OrderDto
{
    public class OrderUpdateStatusGiveRepresentativeDto
    {
        public int Id { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public string RepresentativeID { get; set; } = string.Empty;
    }
}
